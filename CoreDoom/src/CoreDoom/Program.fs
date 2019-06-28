open System
open GZDoom

[<EntryPoint>]
let main argv =
    GZDoom.PlayerEntered.Add (fun args -> printfn "%A" args.Player; printfn "%A" args.FromHub)
    GZDoom.Start argv
