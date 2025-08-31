
namespace DiskInfoArtificial.Library
{
    using System.Runtime.InteropServices;
    using static Impp;
    internal class WindowsVersionChecker : WindowsVersionCheckerBase
    {
        public static bool IsWindowsVersionOrGreaterFx(ushort wMajorVersion, ushort wMinorVersion, ushort wServicePackMajor = 0)
        {
            OSVERSIONINFOEXW osvi = new OSVERSIONINFOEXW
            {
                dwOSVersionInfoSize = (uint)Marshal.SizeOf(typeof(OSVERSIONINFOEXW)),
                dwMajorVersion = 0,
                dwMinorVersion = 0,
                dwBuildNumber = 0,
                dwPlatformId = 0,
                szCSDVersion = new char[128],
                wServicePackMajor = 0,
                wServicePackMinor = 0,
                wSuiteMask = 0,
                wProductType = 0,
                wReserved = 0

            };

            var dwlConditionMask = VerSetConditionMask(
                VerSetConditionMask(
                    VerSetConditionMask(
                        0, VER_MAJORVERSION, VER_GREATER_EQUAL),
                    VER_MINORVERSION, VER_GREATER_EQUAL),
                VER_SERVICEPACKMAJOR, VER_GREATER_EQUAL);

            osvi.dwMajorVersion = wMajorVersion;
            osvi.dwMinorVersion = wMinorVersion;
            osvi.wServicePackMajor = wServicePackMajor;

            return VerifyVersionInfoW(ref osvi, VER_MAJORVERSION | VER_MINORVERSION | VER_SERVICEPACKMAJOR, dwlConditionMask) != false;
        }
    }
}
