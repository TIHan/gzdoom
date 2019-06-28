[<RequireQualifiedAccess>] 
module GZDoom.GZDoomNative

open System.Runtime.InteropServices

[<UnmanagedFunctionPointer (CallingConvention.Cdecl)>]
type DStaticEventHandler_PlayerEntered = delegate of int * bool -> unit

[<Literal>] let DllName = "gzdoom.dll"

[<DllImport (DllName, CallingConvention = CallingConvention.Cdecl)>]
extern int extern_main(int argc, char* argv)

[<DllImport (DllName, CallingConvention = CallingConvention.Cdecl)>]
extern void set_externCallback_DStaticEventHandler_PlayerEntered(DStaticEventHandler_PlayerEntered)