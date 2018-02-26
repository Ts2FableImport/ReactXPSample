module Leisure.Helpers.ReactXP
open Fable.Core
open Leisure.Import.React.React
open Leisure.Helpers.React.Props
open Leisure.Import.ReactXP
open Fable.Core.JsInterop

#nowarn "0064"

type Ext = Ext
    with
        static member Bar (_ : Ext, i : int) = float i |> Some 
        static member Bar (_ : Ext, s : string) = Some s
let inline (!>) (x : ^a) =
    ((^b or ^a ) : (static member Bar :^b * ^a -> ^c) (Ext,x))

module Types =  ___common_Types

module Style = 

    type TextStyle = Types.TextStyle

open Style
    
let private rx = Leisure.Import.ReactXP.reactXP

[<Import("createElement", from="reactxp")>]
let createElement(comp: obj, props: obj, [<ParamList>] children: obj) = jsNative
let inline domEl (``type``: obj) (props: TextStyle list) (children: ReactElement<obj> list): ReactElement<obj> =
    let style = props.[0]   
    let prop = jsOptions<Types.TextProps>(fun s ->
        s.style <- style)    
    createElement(``type``,prop,children)

let inline voidEl (``type``: obj) (props: IHTMLProp list) : ReactElement<obj> =
    createElement(``type``,props,[])

let inline str (s: string): ReactElement<obj> = unbox s

[<RequireQualifiedAccessAttribute>]
module RX = 
    
    let Text b c = domEl rx.Text b c
    let UserInterface = rx.UserInterface
    let App = rx.App
    
    let Platform = rx.Platform