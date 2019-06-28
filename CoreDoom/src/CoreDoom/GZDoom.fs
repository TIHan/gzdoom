namespace GZDoom

#nowarn "9"

open FSharp.NativeInterop

[<RequireQualifiedAccess>]
module GZDoom =

    [<Struct>]
    type Player =
        private {
            num: int
        }

    [<Struct>]
    type PlayerEnteredArgs (player: Player, isFromHub: bool) =

        member __.Player = player

        member __.FromHub = isFromHub

    let evt_DStaticEventHandler_PlayerEntered = Event<PlayerEnteredArgs> ()
    let del_DStaticEventHandler_PlayerEntered =
        GZDoomNative.DStaticEventHandler_PlayerEntered (fun num fromhub ->
            evt_DStaticEventHandler_PlayerEntered.Trigger (PlayerEnteredArgs ({ num = num }, fromhub))
        )

    let Start (argv: string []) =
        if argv.Length > 0 then
            use argvPtr = fixed argv.[0]
            GZDoomNative.extern_main (argv.Length, argvPtr)
        else
            GZDoomNative.extern_main (0, System.IntPtr.Zero |> NativePtr.ofNativeInt)

    let PlayerEntered = evt_DStaticEventHandler_PlayerEntered.Publish

    do
        GZDoomNative.set_externCallback_DStaticEventHandler_PlayerEntered (del_DStaticEventHandler_PlayerEntered)