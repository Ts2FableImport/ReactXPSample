module ReactXPSample

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.ReactXP
let init() =
    RX.UserInterface.setMainView <| (RX.Text[][str "Hello"])
    // let t =UserInterface.contentSizeMultiplierChangedEvent
    ()
init()