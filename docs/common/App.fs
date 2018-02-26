module Docs.Common

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Leisure.Helpers.ReactXP
open Elmish
open Docs.Style

        
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
    RX.Text[helloStyle][str "Hello19"] 
    // a[Style [Padding "0 20px"]][str "Hello19"] 