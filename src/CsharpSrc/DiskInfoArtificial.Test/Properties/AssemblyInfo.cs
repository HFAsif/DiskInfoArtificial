#if EnvDTE
global using Dip = HelperClass.NativeCallerExternal;
#endif

global using Cmd = CrystalDiskInfoDotnet.CommandLineViewModule;
global using Cac = CrystalDiskInfoDotnet.CmdArgClass;

using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
//[assembly : InternalsVisibleTo("DiskInfoArtificial.Test")]

//[assembly: ComVisible(false)]
//[assembly: CLSCompliant(true)]
//[assembly: SecurityPermission(SecurityAction.RequestMinimum, UnmanagedCode = true)]


[assembly: AssemblyTitle("DiskInfoArtificial.Test")]
[assembly: AssemblyDescription("Test project")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("DiskInfoArtificial.Test")]
[assembly: AssemblyCopyright("Copyright ©  2025")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
//[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]
[assembly: AssemblyFileVersion("1.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.MainAssembly)]
[assembly: AssemblyVersion("1.0.0.0")]

//[assembly:System.Reflection.AssemblySignatureKeyAttribute(
//"002400000c80000094000000060200000024000052534131000400000100010051c9dfa857768e18a2616a91f06107afd66e88cf73dfa85b9442f815425009971ba3f7c60eed5a2cdfda7e557d950b69dafb26cff48ecfc5d067a6f6067cd0f23658b299612a541dc5fbe0a3e8f2aec639177dea2ac14831240dbcefe4062b8f09f89d6a7328a08b5db40d984bc165bfb1d1011e9d9f55d2260cca98e23196cf",
//"4ffac4ebdb295943f3b89c758fd19d680fee981e990f404256390fa0f8027e96950a80b9a3f6165beb6836bc7aa91ba71aae1fcd0e65fcd82e6d3146c32fb621dfe481a8748e003f38bd863c679b2925d111843bb7f770989614449e81a416349a59777d638570ab221ba0bb1909b086fd38389faa624fefdb7a861411dca393"
//)]