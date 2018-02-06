// ts2fable 0.0.0
module rec Leisure.Import.ReactDom
open System
open Fable.Core
open Fable.Import.JS
open Leisure.Import.React.React
open Fable.Import.Browser
let [<Import("*","react-dom")>] reactDom: IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract findDOMNode: instance: ReactInstance -> Element
    abstract unmountComponentAtNode: container: Element -> bool
    abstract createPortal: children: ReactNode * container: Element -> ReactPortal
    abstract version: string
    abstract render: Renderer
    abstract hydrate: Renderer
    abstract unstable_batchedUpdates: callback: ('A -> 'B -> obj option) * a: 'A * b: 'B -> unit
    abstract unstable_batchedUpdates: callback: ('A -> obj option) * a: 'A -> unit
    abstract unstable_batchedUpdates: callback: (unit -> obj option) -> unit
    abstract unstable_renderSubtreeIntoContainer: parentComponent: Component<obj option> * element: DOMElement<DOMAttributes<'T>, 'T> * container: Element * ?callback: ('T -> obj option) -> 'T
    abstract unstable_renderSubtreeIntoContainer: parentComponent: Component<obj option> * element: CElement<'P, 'T> * container: Element * ?callback: ('T -> obj option) -> 'T
    abstract unstable_renderSubtreeIntoContainer: parentComponent: Component<obj option> * element: ReactElement<'P> * container: Element * ?callback: (U2<Component<'P, ComponentState>, Element> -> obj option) -> U3<Component<'P, ComponentState>, Element, unit>

type [<AllowNullLiteral>] Renderer =
    // [<Emit "$0($1...)">] abstract Invoke: element: DOMElement<DOMAttributes<'T>, 'T> * container: Element option * ?callback: (unit -> unit) -> 'T
    // [<Emit "$0($1...)">] abstract Invoke: element: Array<DOMElement<DOMAttributes<obj option>, obj option>> * container: Element option * ?callback: (unit -> unit) -> Element
    // [<Emit "$0($1...)">] abstract Invoke: element: U2<SFCElement<obj option>, Array<SFCElement<obj option>>> * container: Element option * ?callback: (unit -> unit) -> unit
    // [<Emit "$0($1...)">] abstract Invoke: element: CElement<'P, 'T> * container: Element option * ?callback: (unit -> unit) -> 'T
    // [<Emit "$0($1...)">] abstract Invoke: element: Array<CElement<obj option, Component<obj option, ComponentState>>> * container: Element option * ?callback: (unit -> unit) -> Component<obj option, ComponentState>
    [<Emit "$0($1...)">] abstract Invoke: element: ReactElement<'P> * container: Element * ?callback: (unit -> unit) -> U3<Component<'P, ComponentState>, Element, unit>
    // [<Emit "$0($1...)">] abstract Invoke: element: Array<ReactElement<obj>> * container: Element option * ?callback: (unit -> unit) -> U3<Component<obj option, ComponentState>, Element, unit>
    // [<Emit "$0($1...)">] abstract Invoke: parentComponent: U2<Component<obj option>, Array<Component<obj option>>> * element: SFCElement<obj option> * container: Element * ?callback: (unit -> unit) -> unit
