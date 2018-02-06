namespace Leisure.Elmish.ReactXP
open Fable.Core
open Elmish
open Leisure.Import.React.React
open Leisure.Import.ReactXP
open Leisure.Helpers.React
open Leisure.Helpers.ReactXP
module RXTypes = ___common_Types
[<RequireQualifiedAccess>]
module Program =

    /// Setup rendering of root ReactNative component
    let withReactXP (program:Program<_,_,_,_>) =
        match RX.Platform.getType() with 
        | RXTypes.PlatformType.Web -> Program.withReact "app-container" program
        | _ -> Program.withReactNative "RXApp" program

