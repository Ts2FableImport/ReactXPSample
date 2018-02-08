module Docs.Common

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Leisure.Helpers.ReactXP
open Elmish
open Leisure.Helpers.React
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

let view _ (dispatch:Dispatch<Msg>) =
    RX.Text[][str "Hello6"] 