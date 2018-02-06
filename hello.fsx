type IPrintable =
   abstract member Print : unit -> unit
   abstract member PrintHello : unit -> unit

// type SomeClass1(x: int, y: float) =
//    interface IPrintable with
//       member this.Print() = printfn "%d %f" x y

let t = 
    {
        new IPrintable with 
            member this.Print() = printf "Hello"
            member this.PrintHello() = printf "Hello2"
    }      
let k = { t with Print = printf "GoGO"}    