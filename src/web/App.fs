module ReactXPSample.Web

open Elmish
open Leisure.Elmish.React
open ReactXPSample.Common

Program.mkSimple init update view
|> Program.withConsoleTrace
|> Program.withReact "app-container" 
|> Program.run