namespace GZDoom

#nowarn "9"

open FSharp.NativeInterop

[<RequireQualifiedAccess>]
module GZDoom =

    let Start (argv: string []) =
        if argv.Length > 0 then
            use argvPtr = fixed argv.[0]
            GZDoomNative.extern_main (argv.Length, argvPtr)
        else
            GZDoomNative.extern_main (0, System.IntPtr.Zero |> NativePtr.ofNativeInt)