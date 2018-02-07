module ReactXPSample.Web

open Elmish
open Leisure.Elmish.ReactNative
open ReactXPSample.Common

Program.mkSimple init update view
|> Program.withConsoleTrace
|> Program.withReactNative "RXApp" 
|> Program.run