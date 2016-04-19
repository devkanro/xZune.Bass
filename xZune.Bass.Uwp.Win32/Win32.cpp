#include "pch.h"
#include "Win32.h"
#include <kernelspecs.h>

using namespace xZune::Bass::Interop;
using namespace Platform;

MyIntPtr Win32::LoadPackedLibrary(String^ path)
{
	auto result = LoadPackagedLibrary(path->Data(), 0);
	return (MyIntPtr)result;
}

Boolean Win32::FreePackedLibrary(IntPtr handle)
{
	BOOL result = FreeLibrary((HMODULE)handle.ToInt32());
	return result;
}

MyIntPtr Win32::GetFuncAddress(MyIntPtr module, String^ path)
{
	std::wstring fooW(path->Begin());
	std::string fooA(fooW.begin(), fooW.end());

	auto result = GetProcAddress((HMODULE)module, fooA.c_str());

	return (MyIntPtr)result;
}