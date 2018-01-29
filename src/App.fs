module ReactXPSample

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Reactxp'
let init() =
    let t = div[][str "Hello"]
    reactXP.UserInterface.setMainView t
    // let t =UserInterface.contentSizeMultiplierChangedEvent
    ()
init()