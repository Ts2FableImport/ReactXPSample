module Docs.Web

open Elmish
open Leisure.Elmish.React
open Docs.Common

Program.mkSimple init update view
|> Program.withConsoleTrace
|> Program.withReact "app-container" 
|> Program.run