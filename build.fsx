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
let webPath = "docs/web"

Target "Restore" (fun _ ->
    Yarn (fun p -> { p with Command = Install Standard})
    DotNetCli.Restore (fun p ->{ p with WorkingDir = webPath})        
)

Target "Default" DoNothing

"Restore" 
==> "Default"
RunTargetOrDefault "Default"
