
namespace DiskInfoArtificial
{
    using WinC = Library.WindowsVersionChecker;
    using Cta = Library.CAtaSmartArtificial;
    using System;
    using System.Collections.ObjectModel;
    using static DiskInfoArtificial.Library.DiskInfoArtificialManager_Structures;

    internal abstract class DiskInfoArtificialManagerAbstract 
    {
        //string[] args { get; set; }

        public required string[] args { get; set; }

        public ObservableCollection< Dis.ATA_SMART_INFO> aTA_SMART_INFOs { get; protected set; }
        public abstract bool StartUp();

        public abstract bool InternalStartup();

        //protected Dis.SMART_ATTRIBUTE[] SMART_ATTRIBUTE_LIST = new Dis.SMART_ATTRIBUTE[MAX_ATTRIBUTE];

        protected nint hMutexJMicron { get; set; }
        protected bool m_bAtaPassThrough;
        protected bool m_bAtaPassThroughSmart;
        protected bool m_bNVMeStorageQuery;



        protected bool FlagUsbMemory = false;
        protected bool IsAdvancedDiskSearch = false;
        protected bool IsWorkaroundHD204UI = false;

        protected bool FlagNvidiaController = false;
        protected bool FlagMarvellController = false;

        //[DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        //[MethodImpl(MethodImplOptions.ForwardRef, MethodCodeType = MethodCodeType.Runtime)]
        //protected static extern void RtlZeroMemory_CopyMemory(ref Dis.ATA_IDENTIFY_DEVICE dest, ref byte src, uint count);

        //SMART_ATTRIBUTE

        public virtual bool Initialize()
        {
            aTA_SMART_INFOs = new ObservableCollection<ATA_SMART_INFO>();

            m_bAtaPassThrough = false;
            m_bAtaPassThroughSmart = false;
            m_bNVMeStorageQuery = false;

            if (WinC.IsWindowsVersionOrGreaterFx(10, 0))
            {
                m_bAtaPassThrough = true;
                m_bAtaPassThroughSmart = true;
                m_bNVMeStorageQuery = true;
            }
            else if (WinC.IsWindowsVersionOrGreaterFx(6, 0) || WinC.IsWindowsVersionOrGreaterFx(5, 2))
            {
                m_bAtaPassThrough = true;
                m_bAtaPassThroughSmart = true;
            }
            else if (WinC.IsWindowsVersionOrGreaterFx(5, 1))
            {
                if (WinC.IsWindowsVersionOrGreaterFx(5, 1, 2))
                {
                    m_bAtaPassThrough = true;
                    m_bAtaPassThroughSmart = true;
                }
            }

            //// 2023/02/24 Lock Handle: Compatible with SIV
            
            hMutexJMicron = Cta.CreateWorldMutex("Access_JMicron_SMART");

            return true;
        }

        protected IntPtr AllocMethod(int size)
        {
            // Allocate the memory, zeroing it in the progress
            IntPtr memPtr = Dip.LocalAlloc((uint)Inm.LocalMemoryFlags.LPTR, new UIntPtr((uint)size));
            // Throw an OutOfMemoryException if out of memory
            if (memPtr == IntPtr.Zero)
                throw new OutOfMemoryException();
            return memPtr;
        }

        protected uint GetPowerOnHours(uint rawValue, uint timeUnitType)
        {
            switch (timeUnitType)
            {
                case (uint)Inm.POWER_ON_HOURS_UNIT.POWER_ON_UNKNOWN:
                    return 0;
                    //break;
                case (uint)Inm.POWER_ON_HOURS_UNIT.POWER_ON_HOURS:
                    return rawValue;
                    //break;
                case (uint)Inm.POWER_ON_HOURS_UNIT.POWER_ON_MINUTES:
                    return rawValue / 60;
                    //break;
                case (uint)Inm.POWER_ON_HOURS_UNIT.POWER_ON_HALF_MINUTES:
                    return rawValue / 120;
                    //break;
                case (uint)Inm.POWER_ON_HOURS_UNIT.POWER_ON_SECONDS:
                    return rawValue / 60 / 60;
                    //break;
                case (uint)Inm.POWER_ON_HOURS_UNIT.POWER_ON_10_MINUTES:
                    return rawValue / 6;
                    //break;
                case (uint)Inm.POWER_ON_HOURS_UNIT.POWER_ON_MILLI_SECONDS:
                    return rawValue;
                    //break;
                default:
                    return rawValue;
                    //break;
            }
        }

        //protected uint GetPowerOnHoursEx(uint i, uint timeUnitType)
        //{
        //    uint rawValue = vars[i].PowerOnRawValue;
        //    switch (timeUnitType)
        //    {
        //        case (uint)POWER_ON_HOURS_UNIT.POWER_ON_UNKNOWN:
        //            return 0;
        //            break;
        //        case (uint)POWER_ON_HOURS_UNIT.POWER_ON_HOURS:
        //            return rawValue;
        //            break;
        //        case (uint)POWER_ON_HOURS_UNIT.POWER_ON_MINUTES:
        //            return rawValue / 60;
        //            break;
        //        case (uint)POWER_ON_HOURS_UNIT.POWER_ON_HALF_MINUTES:
        //            return rawValue / 120;
        //            break;
        //        case (uint)POWER_ON_HOURS_UNIT.POWER_ON_SECONDS:
        //            return rawValue / 60 / 60;
        //            break;
        //        case (uint)POWER_ON_HOURS_UNIT.POWER_ON_10_MINUTES:
        //            return rawValue / 6;
        //            break;
        //        case (uint)POWER_ON_HOURS_UNIT.POWER_ON_MILLI_SECONDS:
        //            return rawValue;
        //            break;
        //        default:
        //            return rawValue;
        //            break;
        //    }
        //}

        protected ulong B8toB64(byte b0, byte b1, byte b2, byte b3, byte b4, byte b5 = 0, byte b6 = 0, byte b7 = 0)
        {
            ulong data =
                  ((ulong)b7 << 56)
                + ((ulong)b6 << 48)
                + ((ulong)b5 << 40)
                + ((ulong)b4 << 32)
                + ((ulong)b3 << 24)
                + ((ulong)b2 << 16)
                + ((ulong)b1 << 8)
                + ((ulong)b0 << 0);

            return data;
        }

        protected uint B8toB32(byte b0, byte b1, byte b2, byte b3)
        {
            uint data =
                  ((uint)b3 << 24)
                + ((uint)b2 << 16)
                + ((uint)b1 << 8)
                + ((uint)b0 << 0);

            return data;
        }

        protected string GetModelSerial(ref string model, ref string serialNumber)
        {
            string modelSerial;
            modelSerial = model + serialNumber;
            modelSerial.Replace(("\\"), (""));
            modelSerial.Replace(("/"), (""));
            modelSerial.Replace((":"), (""));
            modelSerial.Replace(("*"), (""));
            modelSerial.Replace(("?"), (""));
            modelSerial.Replace(("\""), (""));
            modelSerial.Replace(("<"), (""));
            modelSerial.Replace((">"), (""));
            modelSerial.Replace(("|"), (""));

            return modelSerial;
        }
    }
}
