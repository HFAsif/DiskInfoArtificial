
using System.Runtime.InteropServices;
namespace DiskInfoArtificial
{
    internal class DiskInfoArtificial_Test : DiskInfoArtificialManagerAbstract , IDiskInfoArtificialManager
    {

        [DllImport("DiskInfoArtificial.Native", EntryPoint = "Diskinfo_csharp_method", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        static extern int Diskinfo_csharp_method(int argc, nint[] argv);

        [DllImport("DiskInfoArtificial.Native.dll", EntryPoint = "DiskInfoArtificial_native_Test", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        static extern int DiskInfoArtificial_native_Test();

        [DllImport("DiskInfoArtificial.Native.Mfc.dll", EntryPoint = "DiskInfoArtificial_native_Test_mfc", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        static extern int DiskInfoArtificial_native_Test_mfc();

        public override bool StartUp()
        {
            DiskInfoArtificial_native_Test();
            return true;
        }

        public void ExternalRun()
        {
        }

        public override bool InternalStartup()
        {
            throw new System.NotImplementedException();
        }
    }
}
