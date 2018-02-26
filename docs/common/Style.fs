module Docs.Style
open Leisure.Helpers.ReactXP.Style
open Fable.Core.JsInterop
open Leisure.Helpers.ReactXP
let helloStyle = 
    jsOptions<TextStyle>(fun s ->
        s.color <- !>"red"
        s.fontSize <- !>25)