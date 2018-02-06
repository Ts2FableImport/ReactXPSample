namespace Leisure.Elmish.ReactXP

open Fable.Core
open Elmish
open Leisure.Import.React'.React

type [<Pojo>] LazyProps<'model> = {
    model:'model
    render:unit->ReactElement<obj>
    equal:'model->'model->bool
}
module Components =
    JsInterop.importAll "./react-native.fs"

    type LazyView<'model>(props) =
        inherit ComponentAbstract<LazyProps<'model>,obj>(props)

        override this.shouldComponentUpdate(nextProps, _nextState) =
            not <| this.props.equal this.props.model nextProps.model

        override this.render () =
            this.props.render ()
            

[<AutoOpen>]
module Common =
    /// Avoid rendering the view unless the model has changed.
    /// equal: function to compare the previous and the new states
    /// view: function to render the model
    /// state: new state to render
    let lazyViewWith (equal:'model->'model->bool)
                     (view:'model->ReactElement<obj>)
                     (state:'model) =
        Components.LazyView<_>(
            { render = fun () -> view state
              equal = equal
              model = state 
            })

    /// Avoid rendering the view unless the model has changed.
    /// equal: function to compare the previous and the new states
    /// view: function to render the model using the dispatch
    /// dispatch: dispatch function
    /// state: new state to render
    let lazyView2With (equal:'model->'model->bool)
                      (view:'msg Dispatch->'model->ReactElement<obj>) 
                      (dispatch:'msg Dispatch) =
        lazyViewWith equal (view dispatch)

   /// Avoid rendering the view unless the model has changed.
   /// equal: function to compare the previous and the new model (a tuple of two states)
   /// view: function to render the model using the dispatch
   /// dispatch: dispatch function
   /// state1: new state to render
   /// state2: new state to render
    let lazyView3With (equal:_->_->bool)
                      (view:'msg Dispatch->_->_->ReactElement<obj>)
                      (dispatch:'msg Dispatch) =
        let view' = view dispatch
        fun state1 state2 -> Components.LazyView<_>(
            { 
                render = fun () -> view' state1 state2
                equal = equal
                model = (state1,state2)
            }
        )        
   /// Avoid rendering the view unless the model has changed.
   /// view: function of model to render the view
    let lazyView (view:'model->ReactElement<obj>) =
        lazyViewWith (=) view

    /// Avoid rendering the view unless the model has changed.
    /// view: function of two arguments to render the model using the dispatch
    let lazyView2 (view:'msg Dispatch->'model->ReactElement<obj>) =
        lazyView2With (=) view
 
    /// Avoid rendering the view unless the model has changed.
    /// view: function of three arguments to render the model using the dispatch
    let lazyView3 (view:'msg Dispatch->_->_->ReactElement<obj>) =
        lazyView3With (=) view 


[<RequireQualifiedAccess>]
module Program =

    /// Setup rendering of root ReactNative component
    let withReactXP (program:Program<_,_,_,_>) =
        let render dispatch =
            let viewWithDispatch = program.view dispatch
            ignore
            
        { program with setState = render }
