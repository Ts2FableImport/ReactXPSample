module Docs.Native

open Elmish
open Leisure.Elmish.ReactNative
open Docs.Common
Program.mkSimple init update view
|> Program.withConsoleTrace
|> Program.withReactNative "RXApp" 
|> Program.run