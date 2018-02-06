module ReactXPSample

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Leisure.Helpers.ReactXP
open Elmish
open Leisure.Elmish.ReactXP
type Model = int


type Msg =
  | Increment
  | Decrement

let init () =
  printf "Init2"
  0
let update (msg:Msg) count =
    printf "Update2"
    match msg with
    | Increment ->
        count + 1

    | Decrement ->
        count - 1

let view count (dispatch:Dispatch<Msg>) =
    let onClick msg =
      fun () -> msg |> dispatch 
    RX.Text[][str "Hello2"]      

Program.mkSimple init update view
|> Program.withConsoleTrace
|> Program.withReactXP
|> Program.run
