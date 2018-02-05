namespace Elmish.ReactXP

open Fable.Core
open Elmish
open React'.React
open Fable.Core.JsInterop
open Fable.Helpers.ReactXP


type [<Pojo>] LazyProps<'model> = {
    model:'model
    render:unit->ReactElement<obj>
    equal:'model->'model->bool
}

module Components =
    importAll "./commontest.fs"

    type LazyView<'model>() =
        member val props = jsNative
        interface Component<LazyProps<'model>,obj> with 
            member this.forceUpdate(_) = jsNative

            member val props = jsNative with get,set
            member this.render() = this.props.render ()
            member val context = jsNative with get,set
            member val refs = jsNative with get,set
            member val state = jsNative with get,set
            member this.setState(_,_) = jsNative
            member this.componentWillMount() = jsNative
            member this.componentDidMount() = jsNative
            member this.componentWillReceiveProps(_,_) = jsNative
            member this.shouldComponentUpdate(nextProps,nextState,_) = 
                not <| this.props.equal this.props.model nextProps.model
            member this.componentDidUpdate(_,_,_) = jsNative
            member this.componentWillUpdate(_,_,_) = jsNative
            member this.componentWillUnmount() = jsNative
            member this.componentDidCatch(_,_) = jsNative
            

[<AutoOpen>]
module Common =
    /// Avoid rendering the view unless the model has changed.
    /// equal: function to compare the previous and the new states
    /// view: function to render the model
    /// state: new state to render
    let lazyViewWith (equal:'model->'model->bool)
                     (view:'model->ReactElement<obj>)
                     (state:'model) =
        ofType<Components.LazyView<_>,_,_>
            { render = fun () -> view state
              equal = equal
              model = state }
            []

//     /// Avoid rendering the view unless the model has changed.
//     /// equal: function to compare the previous and the new states
//     /// view: function to render the model using the dispatch
//     /// dispatch: dispatch function
//     /// state: new state to render
//     let lazyView2With (equal:'model->'model->bool)
//                       (view:'msg Dispatch->'model->ReactElement<obj>) 
//                       (dispatch:'msg Dispatch) =
//         lazyViewWith equal (view dispatch)

//     /// Avoid rendering the view unless the model has changed.
//     /// equal: function to compare the previous and the new model (a tuple of two states)
//     /// view: function to render the model using the dispatch
//     /// dispatch: dispatch function
//     /// state1: new state to render
//     /// state2: new state to render
//     let lazyView3With (equal:_->_->bool)
//                       (view:'msg Dispatch->_->_->ReactElement<obj>)
//                       (dispatch:'msg Dispatch) =
//         let view' = view dispatch
//         fun state1 state2 ->
//             ofType<Components.LazyView<_>,_,_>
//                 { render = fun () -> view' state1 state2
//                   equal = equal
//                   model = (state1,state2) }
//                 []

//     /// Avoid rendering the view unless the model has changed.
//     /// view: function of model to render the view
//     let lazyView (view:'model->ReactElement<obj>) =
//         lazyViewWith (=) view

//     /// Avoid rendering the view unless the model has changed.
//     /// view: function of two arguments to render the model using the dispatch
//     let lazyView2 (view:'msg Dispatch->'model->ReactElement<obj>) =
//         lazyView2With (=) view

//     /// Avoid rendering the view unless the model has changed.
//     /// view: function of three arguments to render the model using the dispatch
//     let lazyView3 (view:'msg Dispatch->_->_->ReactElement<obj>) =
//         lazyView3With (=) view 


[<RequireQualifiedAccess>]
module Program =
    open Components

    /// Setup rendering of root ReactNative component
    let withReactXP (program:Program<_,_,_,_>) =
        let render dispatch =
            let viewWithDispatch = program.view dispatch
            ignore
            
        { program with setState = render }
