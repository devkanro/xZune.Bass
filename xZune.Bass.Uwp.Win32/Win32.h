#pragma once
using namespace Platform;

#ifdef _WIN64
        typedef int64 MyIntPtr;
#else
        typedef int32 MyIntPtr;
#endif

namespace xZune
{
	namespace Bass
	{
		namespace Interop
		{
			public ref class Win32 sealed
			{
			public:
				static MyIntPtr LoadPackedLibrary(String^ path);
				static Boolean FreePackedLibrary(IntPtr handle);
				static MyIntPtr GetFuncAddress(MyIntPtr module,String^ path);
			};
		}
	}
}
