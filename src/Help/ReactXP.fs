module Leisure.Helper.ReactXP
open Fable.Core
open Leisure.Import.React'.React
open Leisure.Helpers.React.Props

let private rx = Leisure.Import.ReactXP.reactXP
[<Import("createElement", from="reactxp")>]
let createElement(comp: obj, props: obj, [<ParamList>] children: obj) = jsNative
let inline domEl (``type``: obj) (props: IHTMLProp list) (children: ReactElement<obj> list): ReactElement<obj> =
    createElement(``type``,props,children)

let inline voidEl (``type``: obj) (props: IHTMLProp list) : ReactElement<obj> =
    createElement(``type``,props,[])

let inline str (s: string): ReactElement<obj> = unbox s

[<RequireQualifiedAccessAttribute>]
module RX = 
    let Text b c = domEl rx.Text b c
    let UserInterface = rx.UserInterface
    let App = rx.App
    
    