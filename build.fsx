// include Fake libs
#r "./packages/build/FAKE/tools/FakeLib.dll"
#r "System.IO.Compression.FileSystem" 

open System
open System.IO
open Fake
open Fake.YarnHelper
open Fake.ReleaseNotesHelper
open Fake.Git
open Fake.DotNetCli
let dotnetcliVersion = DotNetCli.GetDotNetSDKVersionFromGlobalJson()
let mutable dotnetExePath = "dotnet"

Target "InstallDotNetCore" (fun _ ->
    dotnetExePath <- DotNetCli.InstallDotNetSDK dotnetcliVersion
)

let runDotnet workingDir args =
    let result =
        ExecProcess (fun info ->
            info.FileName <- dotnetExePath
            info.WorkingDirectory <- workingDir
            info.Arguments <- args) TimeSpan.MaxValue
    if result <> 0 then failwithf "dotnet %s failed" args
let webDir = "./docs/web" |> FullName

Target "Restore" (fun _ ->
    Yarn (fun p -> { p with Command = Install Standard})
    runDotnet webDir "restore"       
)

Target "Default" DoNothing
"InstallDotNetCore"
==> "Restore" 
==> "Default"
RunTargetOrDefault "Default"
