[<RequireQualifiedAccess>] 
module GZDoom.GZDoomNative

open System.Runtime.InteropServices

[<Literal>] let DllName = "gzdoom.dll"

[<DllImport (DllName, CallingConvention = CallingConvention.Cdecl)>]
extern int extern_main(int argc, char* argv)