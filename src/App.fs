module ReactXPSample

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.ReactXP
let init() =
    RX.App.initialize(true,true)
    RX.UserInterface.setMainView <| 
        RX.Text[][str "Hello"]
init()