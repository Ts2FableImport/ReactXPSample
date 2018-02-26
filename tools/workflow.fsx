#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget Fake.Core.Environment
nuget Microsoft.EntityFrameworkCore
nuget Humhei.CliHelper
nuget Fake.Core.Target //"
#load "./.fake/workflow.fsx/intellisense.fsx"
open System
open Fake.Core
open Fake.IO.FileSystemOperators
let run' timeout (cmd:string) dir args  =
    if Process.ExecProcess (fun info ->
        { info with 
            FileName = cmd
            WorkingDirectory = 
                if not (String.IsNullOrWhiteSpace dir) then dir else info.WorkingDirectory  
                |> fun s -> 
                    Printf.ksprintf Trace.trace "Working Dir Is %s" s
                    s
            Arguments = args
        }
    ) timeout <> 0 then
        failwithf "Error while running '%s' with args: %s " cmd args

let run = run' System.TimeSpan.MaxValue

let platformTool tool = 
    Process.tryFindFileOnPath tool
    |> function Some t -> t | _ -> failwithf "%s not found" tool
    
let reactNativeTool = platformTool "react-native"
let yarnTool = platformTool "yarn"
let mutable dotnetExePath = "dotnet"
let toolDir = "./tools" 
let splitterConfig = toolDir </> "splitter.config.js"
let runDotnet workingDir args =
    let result =
        Process.ExecProcess (fun info ->
        { info with 
            FileName = dotnetExePath
            WorkingDirectory = workingDir 
            Arguments =  args }) TimeSpan.MaxValue
    if result <> 0 then failwithf "dotnet %s failed" args 

Target.Create "Splitter" (fun _ ->
    run yarnTool toolDir <| sprintf "fable-splitter -c %s -w " splitterConfig
)

Target.Create "Build" (fun _ ->
    runDotnet toolDir "fable webpack -- -p --config webpack.config.prod.js "
)

Target.Create "Start" (fun _ ->
    runDotnet toolDir "fable webpack-dev-server -- --config webpack.config.dev.js"
)

Target.Create "RunWindows" (fun _ ->

    let runSplitter = async { run yarnTool toolDir <| sprintf "fable-splitter -c %s -w " splitterConfig }
    let runFableDaemon = async { runDotnet toolDir "fable start" }
    let runNative = async { run reactNativeTool "./" "run-windows" }
    [runSplitter; runFableDaemon; runNative]
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
)

Target.Create "RunAndroid" (fun _ ->
    let runFableDaemon = async { runDotnet toolDir "fable start" }
    let runHaul = async { run yarnTool toolDir "haul --platform android --config tools/webpack.haul.js" }
    let runNative = async { run reactNativeTool "./" "run-android" }
    [runHaul; runFableDaemon; runNative]
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
)


Target.RunOrDefault "Start"
