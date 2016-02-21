using System.Reflection;
using System.Runtime.InteropServices;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Flags;
using xZune.Bass.Modules;

[assembly: AssemblyTitle("xZune.Bass.Flac")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("xZune.Bass.Flac")]
[assembly: AssemblyCopyright("Copyright ©  2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: Guid("ae57f2b6-74d3-4fc3-87c2-d22cd8264119")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: BassPluginAssembly(BassPlugin.BassFlac,typeof(FlacModule))]