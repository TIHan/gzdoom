#ifndef __CORECLR_INTEROP_H__
#define __CORECLR_INTEROP_H__

#if defined(_WIN32)
#	define CLR_IMPORT		__declspec(dllimport)
#	define CLR_EXPORT		__declspec(dllexport)
#	define CLR_DECL		    __cdecl
#elif defined(__GNUC__)
#	define CLR_EXPORT		__attribute__((visibility("default")))
#	define CLR_IMPORT
#	define CLR_DECL		    __attribute__((cdecl))
#else
#	error Compiler not supported.
#endif

#endif //__CORECLR_INTEROP_H__