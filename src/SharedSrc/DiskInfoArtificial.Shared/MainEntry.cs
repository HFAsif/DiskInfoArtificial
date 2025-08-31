namespace DiskInfoArtificial;

using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;

public class MainEntry
{
    [STAThread]
    public static void Run(bool nativeTest, out object ataLists , params string[] args)
    {
        ataLists = default;
        bool createdNew = false;
        string name = Assembly.GetExecutingAssembly().GetName().Name;
        using Mutex mutex = new Mutex(initiallyOwned: true, name, out createdNew);
        if (createdNew)
        {
            Dis.ATA_SMART_INFO aTA_SMART_INFO;
            Unsafe.SkipInit(out aTA_SMART_INFO);

            DiskInfoArtificialManagerAbstract diskInfoArtificialManager = default;
            if (nativeTest)
            {
                diskInfoArtificialManager = new DiskInfoArtificial_Test()
                { args = args };
                diskInfoArtificialManager.StartUp();
            }
            else
            {
                diskInfoArtificialManager = new DiskInfoArtificialManager()
                { args = args };
                var _getType = diskInfoArtificialManager.GetType();
                var diskInfoArtificialManagerattr = _getType.GetCustomAttribute<DiskInfoArtificialManagerAttr>();

                if (Attribute.IsDefined(_getType, diskInfoArtificialManagerattr.GetType()) && diskInfoArtificialManagerattr.BTAPassThroughSmart)
                {
                    if (diskInfoArtificialManager.StartUp())
                    {
                        diskInfoArtificialManager.InternalStartup();


                        ataLists = diskInfoArtificialManager.aTA_SMART_INFOs;


                    }
                    else Debugger.Break();
                }
            }
            mutex.ReleaseMutex();
        }
        else
        {
            Debug.WriteLine("An application instance is already running");
        }

        
        
    }
}
