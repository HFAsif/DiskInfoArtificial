using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiskInfoArtificial
{
    #region MyRegion
    ////512
    //var _ATA_IDENTIFY_DEVICE = Marshal.SizeOf(typeof(ATA_IDENTIFY_DEVICE));
    ////4096
    //var _NVME_IDENTIFY_DEVICE = Marshal.SizeOf(typeof(NVME_IDENTIFY_DEVICE));
    ////4096
    //var _BIN_IDENTIFY_DEVICE = Marshal.SizeOf(typeof(BIN_IDENTIFY_DEVICE));
    ////4096
    ////var _IDENTIFY_DEVICE_Data = Marshal.SizeOf(typeof(IDENTIFY_DEVICE)); 
    #endregion

    #region MyRegion
    //ObservableCollection<InfoForCast> infoForCasts = new ObservableCollection<InfoForCast>();

    //foreach (var ata in atalist)
    //{
    //    InfoForCast infoForCast = new InfoForCast();
    //    var infoFields = infoForCast.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

    //    var ataFields = ata.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

    //    foreach (var field in ataFields)
    //    {

    //    }

    //    for (int j = 0; j < ataFields.Length; j++)
    //    {
    //        var ataField = ataFields[j];

    //        var ataFieldVal = ataField.GetValue(ata);
    //        if (ataFieldVal is not null)
    //        {
    //            //infoField.SetValue(infoForCast, ataFieldVal);
    //        }

    //        ////var infoField = infoFields.ToList().Find(a => a.Name == ataField.Name);
    //        //if (infoField is not null)
    //        //{
    //        //    var ataFieldVal = ataField.GetValue(ata);
    //        //    infoField.SetValue(infoForCast, ataFieldVal);
    //        //}

    //        //foreach (var infoField in infoFields)
    //        //{
    //        //    if (infoField.Name == ataField.Name)
    //        //    {
    //        //        var ataFieldVal = ataField.GetValue(ata);
    //        //        if (ataFieldVal is not null)
    //        //        {
    //        //            infoField.SetValue(infoForCast, ataFieldVal);
    //        //        }
    //        //    }
    //        //}

    //        //var ataFieldVal = ataField.GetValue(ata);
    //        //if (ataFieldVal is not null)
    //        //{
    //        //    foreach (var infoField in infoFields)
    //        //    {
    //        //        if(infoField.Name == ataField.Name)
    //        //        {
    //        //            infoField.SetValue(infoForCast, ataFieldVal);

    //        //        }
    //        //    }
    //        //}
    //    }

    //    infoForCasts.Add(infoForCast);
    //    #region MyRegion
    //    //var a1 = atalist[i];
    //    //var a2 = a1.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
    //    //var j1 = infoForCast.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

    //    //for (int j = 0; j < a2.Length; j++)
    //    //{
    //    //    var a3 = a2[j] as dynamic;

    //    //    if (new Type[] { typeof(ushort), typeof(uint), typeof(ulong), typeof(byte), typeof(string) , typeof(int) }.Contains(a2[j].FieldType))
    //    //    {
    //    //        // unsigned.
    //    //        if (a3?.Name is not null)
    //    //        {
    //    //            for (int z = 0; z < j1.Length; z++)
    //    //            {
    //    //                var z1 = j1[z] as dynamic;

    //    //                if (a3?.Name == z1?.Name)
    //    //                {

    //    //                    var tval = a2[j].GetValue(null);
    //    //                }

    //    //            }

    //    //        }
    //    //    }



    //    //} 
    //    #endregion

    //} 
    #endregion




    //ATA_IDENTIFY_DEVICE _aTA_IDENTIFY_DEVICE;
    //Unsafe.SkipInit(out _aTA_IDENTIFY_DEVICE);

    //BIN_IDENTIFY_DEVICE _bIN_IDENTIFY_DEVICE;
    //Unsafe.SkipInit(out _bIN_IDENTIFY_DEVICE);

    //NVME_IDENTIFY_DEVICE _nVME_IDENTIFY_DEVICE;
    //Unsafe.SkipInit(out _nVME_IDENTIFY_DEVICE);

    //CopyMemory(ref _aTA_IDENTIFY_DEVICE, ref ab.Buf[0], (uint)Marshal.SizeOf(typeof(ATA_IDENTIFY_DEVICE)));
    //CopyMemory(ref _bIN_IDENTIFY_DEVICE, ref ab.Buf[0], (uint)Marshal.SizeOf(typeof(BIN_IDENTIFY_DEVICE)));
    //CopyMemory(ref _nVME_IDENTIFY_DEVICE, ref ab.Buf[0], (uint)Marshal.SizeOf(typeof(NVME_IDENTIFY_DEVICE)));

    //data.A = _aTA_IDENTIFY_DEVICE;
    //data.B = _bIN_IDENTIFY_DEVICE;
    //data.N = _nVME_IDENTIFY_DEVICE;


    //internal partial class DiskInfoArtificialManager
    //{
    //    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    static extern void CopyMemory(ref Dis.SMART_ATTRIBUTE dest, ref byte sources, uint srcsize);


    //    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    static extern void CopyMemory(ref byte dest, uint destsize, ref byte sources, uint srcsize);


    //    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    static extern void CopyMemory(ref Dis.ATA_SMART_INFO dest, ref byte sources, uint count);


    //    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    static extern void CopyMemory(ref byte dest, ref Dis.IDENTIFY_DEVICE sources, uint count);

    //    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    static extern void CopyMemory(ref Dis.CSMI_SAS_PHY_ENTITY dest, ref Dis.CSMI_SAS_PHY_ENTITY? sources, uint count);

    //    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    static extern void CopyMemory(ref Dis.IDENTIFY_DEVICE dest, ref byte sources, uint count);


    //    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    static extern void CopyMemory(ref byte dest, ref byte sources, uint count);

    //    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    [return: MarshalAs(UnmanagedType.Bool)]
    //    static extern bool CopyMemoryBoolen(ref byte dest, ref byte sources, uint count);


    //    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    static extern void CopyMemory(ref Dis.IDENTIFY_DEVICE dest, ref Dis.IDENTIFY_DEVICE identify, uint count);

    //    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    static extern void CopyMemory(ref Dis.ATA_IDENTIFY_DEVICE dest, ref byte src, uint count);

    //    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    static extern void CopyMemory(ref Dis.BIN_IDENTIFY_DEVICE dest, ref byte src, uint count);

    //    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    [MethodImpl(MethodImplOptions.ForwardRef, MethodCodeType = MethodCodeType.Runtime)]
    //    static extern void CopyMemory(ref Dis.NVME_IDENTIFY_DEVICE dest, ref byte src, uint count);

    //    ////memcpy_s(&(asi.SmartReadData), 512, nptwb.Buffer, 512);
    //    //[DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    //    // static extern void CopyMemory(ref byte[] dest, uint destsize, ref byte[] src, uint sourcsize);

    //    [DllImport("kernel32.dll", SetLastError = true)]
    //    static extern void ZeroMemory(ref Dis.ATA_SMART_INFO destination, [In] nint length);

    //    [DllImport("kernel32.dll", SetLastError = true)]
    //    static extern void ZeroMemory(ref Dis.SMART_THRESHOLD destination, [In] nint length);

    //    [DllImport("kernel32.dll", SetLastError = true)]
    //    static extern void ZeroMemory(ref Dis.SMART_ATTRIBUTE destination, [In] nint length);

    //    [DllImport("kernel32.dll", SetLastError = true)]
    //    static extern void ZeroMemory(ref Dis.ATA_PASS_THROUGH_EX_WITH_BUFFERS destination, [In] nint length);

    //    [DllImport("kernel32.dll", SetLastError = true)]
    //    static extern void ZeroMemory(ref Dis.TStorageQueryWithBuffer destination, [In] nint length);

    //    [DllImport("kernel32.dll", SetLastError = true)]
    //    static extern void ZeroMemory(ref byte[] destination, [In] nint length);

    //    [DllImport("kernel32.dll", SetLastError = true)]
    //    static extern void ZeroMemory(ref Dis.IDENTIFY_DEVICE destination, [In] nint length);
    //}



    internal class JunkCodes
    {

        //bool SendAtaCommandPd(int physicalDriveId, byte target, byte main, byte sub, byte param, ref IDENTIFY_DEVICE data, uint dataSize)
        //{
        //    bool bRet = false;
        //    IntPtr hIoCtrl = IntPtr.Zero;
        //    uint dwReturned = 0;

        //    hIoCtrl = GetIoCtrlHandle(physicalDriveId);
        //    if (hIoCtrl == IntPtr.Zero || hIoCtrl == INVALID_HANDLE_VALUE)
        //    {
        //        return false;
        //    }

        //    if (m_bAtaPassThrough)
        //    {
        //        ATA_PASS_THROUGH_EX_WITH_BUFFERS ab;
        //        Unsafe.SkipInit(out ab);

        //        //ZeroMemory(ref ab, Marshal.SizeOf(typeof(ATA_PASS_THROUGH_EX_WITH_BUFFERS)));

        //        Stm.StructToZeroStruct(ref ab);

        //        //.ZeroMemory(&ab, sizeof(ab));
        //        ab.Apt.Length = (ushort)Marshal.SizeOf(typeof(ATA_PASS_THROUGH_EX));
        //        ab.Apt.TimeOutValue = 2;
        //        uint size = (uint)Marshal.OffsetOf(typeof(ATA_PASS_THROUGH_EX_WITH_BUFFERS), "Buf");
        //        ab.Apt.DataBufferOffset = size;

        //        if (dataSize > 0)
        //        {
        //            if (dataSize > ab.Buf.Length)
        //            {
        //                return false;
        //            }
        //            ab.Apt.AtaFlags = ATA_FLAGS_DATA_IN;
        //            ab.Apt.DataTransferLength = dataSize;
        //            ab.Buf[0] = 0xCF; // magic number
        //            size += dataSize;
        //        }

        //        ab.Apt.CurrentTaskFile.bFeaturesReg = sub;
        //        ab.Apt.CurrentTaskFile.bSectorCountReg = param;
        //        ab.Apt.CurrentTaskFile.bDriveHeadReg = target;
        //        ab.Apt.CurrentTaskFile.bCommandReg = main;

        //        if (main == SMART_CMD)
        //        {
        //            ab.Apt.CurrentTaskFile.bCylLowReg = SMART_CYL_LOW;
        //            ab.Apt.CurrentTaskFile.bCylHighReg = SMART_CYL_HI;
        //            ab.Apt.CurrentTaskFile.bSectorCountReg = 1;
        //            ab.Apt.CurrentTaskFile.bSectorNumberReg = 1;
        //        }

        //        bRet = Dip.DeviceIoControlSpecific(hIoCtrl, (uint)IO_CONTROL_CODE.IOCTL_ATA_PASS_THROUGH,
        //            ref ab, size, ref ab, size, ref dwReturned, IntPtr.Zero);

        //        Dip.safeCloseHandle(hIoCtrl);

        //        if (bRet && dataSize != 0 && data.B.Bin == null)
        //        {


        //            ATA_IDENTIFY_DEVICE _aTA_IDENTIFY_DEVICE;
        //            Unsafe.SkipInit(out _aTA_IDENTIFY_DEVICE);

        //            BIN_IDENTIFY_DEVICE _bIN_IDENTIFY_DEVICE;
        //            Unsafe.SkipInit(out _bIN_IDENTIFY_DEVICE);

        //            NVME_IDENTIFY_DEVICE _nVME_IDENTIFY_DEVICE;
        //            Unsafe.SkipInit(out _nVME_IDENTIFY_DEVICE);

        //            Stm.MemCpyStructToStruct<ATA_IDENTIFY_DEVICE, BIN_IDENTIFY_DEVICE, NVME_IDENTIFY_DEVICE>(ref ab.Buf, ref data.A, ref data.B, ref data.N);
        //            //data.A = _aTA_IDENTIFY_DEVICE;
        //            //data.B = _bIN_IDENTIFY_DEVICE;
        //            //data.N = _nVME_IDENTIFY_DEVICE;

        //            ////var tSize = Marshal.SizeOf((uint)Marshal.SizeOf(typeof(ATA_IDENTIFY_DEVICE)));
        //            //////var fSize = Marshal.SizeOf((uint)Marshal.SizeOf(typeof(BIN_IDENTIFY_DEVICE)));
        //            //var zSize = Marshal.SizeOf((uint)Marshal.SizeOf(typeof(NVME_IDENTIFY_DEVICE)));

        //            //var tallocSrc = Marshal.AllocHGlobal(zSize);
        //            //var fallocSrc = Marshal.AllocHGlobal(zSize);
        //            //var zallocSrc = Marshal.AllocHGlobal(zSize);

        //            //Marshal.Copy(ab.Buf, 0, tallocSrc, zSize);
        //            //Marshal.Copy(ab.Buf, 0, fallocSrc, zSize);
        //            //Marshal.Copy(ab.Buf, 0, zallocSrc, zSize);

        //            //data.A = Marshal.PtrToStructure<ATA_IDENTIFY_DEVICE>(tallocSrc);
        //            //data.B = Marshal.PtrToStructure<BIN_IDENTIFY_DEVICE>(fallocSrc);
        //            //data.N = Marshal.PtrToStructure<NVME_IDENTIFY_DEVICE>(zallocSrc);


        //            ////Stm.MemCpyTripleStruct2(ref ab.Buf[0], ref _aTA_IDENTIFY_DEVICE, ref _bIN_IDENTIFY_DEVICE, ref _nVME_IDENTIFY_DEVICE);

        //            ////CopyMemory(ref _aTA_IDENTIFY_DEVICE, ref ab.Buf[0], (uint)Marshal.SizeOf(typeof(ATA_IDENTIFY_DEVICE)));
        //            ////CopyMemory(ref _bIN_IDENTIFY_DEVICE, ref ab.Buf[0], (uint)Marshal.SizeOf(typeof(BIN_IDENTIFY_DEVICE)));
        //            ////CopyMemory(ref _nVME_IDENTIFY_DEVICE, ref ab.Buf[0], (uint)Marshal.SizeOf(typeof(NVME_IDENTIFY_DEVICE)));

        //            ////data.A = _aTA_IDENTIFY_DEVICE;
        //            ////data.B = _bIN_IDENTIFY_DEVICE;
        //            ////data.N = _nVME_IDENTIFY_DEVICE;

        //            //////CopyMemory(ref data, ref ab.Buf[0] , dataSize);
        //        }
        //    }


        //    return bRet;
        //}

        //bool CopyMemV(ref IDENTIFY_DEVICE data, byte buf)
        //{
        //    ATA_IDENTIFY_DEVICE _aTA_IDENTIFY_DEVICE;
        //    Unsafe.SkipInit(out _aTA_IDENTIFY_DEVICE);

        //    BIN_IDENTIFY_DEVICE _bIN_IDENTIFY_DEVICE;
        //    Unsafe.SkipInit(out _bIN_IDENTIFY_DEVICE);

        //    NVME_IDENTIFY_DEVICE _nVME_IDENTIFY_DEVICE;
        //    Unsafe.SkipInit(out _nVME_IDENTIFY_DEVICE);

        //    CopyMemory(ref _aTA_IDENTIFY_DEVICE, ref buf, (uint)Marshal.SizeOf(typeof(ATA_IDENTIFY_DEVICE)));
        //    CopyMemory(ref _bIN_IDENTIFY_DEVICE, ref buf, (uint)Marshal.SizeOf(typeof(BIN_IDENTIFY_DEVICE)));
        //    CopyMemory(ref _nVME_IDENTIFY_DEVICE, ref buf, (uint)Marshal.SizeOf(typeof(NVME_IDENTIFY_DEVICE)));

        //    data.A = _aTA_IDENTIFY_DEVICE;
        //    data.B = _bIN_IDENTIFY_DEVICE;
        //    data.N = _nVME_IDENTIFY_DEVICE;
        //    return true;
        //}


        //bool DoIdentifyDeviceNVMeStorageQuery(int physicalDriveId, int scsiPort, int scsiTargetId, ref IDENTIFY_DEVICE data, ref uint diskSize)
        //{
        //    ////512
        //    //var _ATA_IDENTIFY_DEVICE = Marshal.SizeOf(typeof(ATA_IDENTIFY_DEVICE));
        //    ////4096
        //    //var _NVME_IDENTIFY_DEVICE = Marshal.SizeOf(typeof(NVME_IDENTIFY_DEVICE));
        //    ////4096
        //    //var _BIN_IDENTIFY_DEVICE = Marshal.SizeOf(typeof(BIN_IDENTIFY_DEVICE));
        //    ////4096
        //    ////var _IDENTIFY_DEVICE_Data = Marshal.SizeOf(typeof(IDENTIFY_DEVICE));


        //    string path;
        //    path = string.Format("\\\\.\\PhysicalDrive{0}", physicalDriveId);

        //    IntPtr hIoCtrl = Dip.CreateFile(path, (uint)(GENERIC_READ | GENERIC_WRITE),
        //        FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);

        //    TStorageQueryWithBuffer nptwb;
        //    Unsafe.SkipInit(out nptwb);
        //    bool bRet = false;

        //    //#if NET8_0_OR_GREATER

        //    //            nptwb = Stm.StructToZeroStruct<TStorageQueryWithBuffer>();

        //    //#elif NET48_OR_GREATER
        //    //            ZeroMemory(ref nptwb, Marshal.SizeOf(nptwb));
        //    //#else
        //    //            throw new InvalidOperationException("the framework not supported ");

        //    //#endif

        //    nptwb = Stm.StructToZeroStruct<TStorageQueryWithBuffer>();

        //    nptwb.ProtocolSpecific.ProtocolType = TStroageProtocolType.ProtocolTypeNvme;
        //    nptwb.ProtocolSpecific.DataType = (uint)TStorageProtocolNVMeDataType.NVMeDataTypeIdentify;
        //    nptwb.ProtocolSpecific.ProtocolDataOffset = (uint)Marshal.SizeOf(typeof(TStorageProtocolSpecificData));
        //    nptwb.ProtocolSpecific.ProtocolDataLength = 4096;
        //    nptwb.ProtocolSpecific.ProtocolDataRequestValue = 0;
        //    nptwb.ProtocolSpecific.ProtocolDataRequestSubValue = 1;
        //    nptwb.Query.PropertyId = TStoragePropertyId.StorageAdapterProtocolSpecificProperty;
        //    nptwb.Query.QueryType = TStorageQueryType.PropertyStandardQuery;
        //    uint dwReturned = 0;

        //    bRet = Dip.DeviceIoControlSpecific(hIoCtrl, (uint)(IOCTL_STORAGE_QUERY_PROPERTY),
        //    ref nptwb, (uint)Marshal.SizeOf(nptwb), ref nptwb, (uint)Marshal.SizeOf(nptwb), ref dwReturned, IntPtr.Zero);

        //    if (bRet)
        //    {
        //        ulong totalLBA = BitConverter.ToUInt64(nptwb.Buffer, 0);
        //        int sectorSize = 1 << nptwb.Buffer[130];
        //        diskSize = (uint)((totalLBA * (uint)sectorSize) / 1000 / 1000);
        //    }

        //    //ZeroMemory(ref nptwb, Marshal.SizeOf(nptwb));

        //    //#if NET8_0_OR_GREATER

        //    //            nptwb = Stm.StructToZeroStruct<TStorageQueryWithBuffer>();

        //    //#elif NET48_OR_GREATER
        //    //            ZeroMemory(ref nptwb, Marshal.SizeOf(nptwb));
        //    //#else
        //    //            throw new InvalidOperationException("the framework not supported ");

        //    //#endif

        //    nptwb = Stm.StructToZeroStruct<TStorageQueryWithBuffer>();

        //    //ZeroMemory(&nptwb, sizeof(nptwb));
        //    nptwb.ProtocolSpecific.ProtocolType = TStroageProtocolType.ProtocolTypeNvme;
        //    nptwb.ProtocolSpecific.DataType = (uint)TStorageProtocolNVMeDataType.NVMeDataTypeIdentify;
        //    nptwb.ProtocolSpecific.ProtocolDataOffset = (uint)Marshal.SizeOf(typeof(TStorageProtocolSpecificData));
        //    nptwb.ProtocolSpecific.ProtocolDataLength = 4096;
        //    nptwb.Query.PropertyId = TStoragePropertyId.StorageAdapterProtocolSpecificProperty;
        //    nptwb.Query.QueryType = TStorageQueryType.PropertyStandardQuery;
        //    nptwb.ProtocolSpecific.ProtocolDataRequestValue = 1; /*NVME_IDENTIFY_CNS_CONTROLLER*/
        //    nptwb.ProtocolSpecific.ProtocolDataRequestSubValue = 0;
        //    dwReturned = 0;

        //    bRet = Dip.DeviceIoControlSpecific(hIoCtrl, (uint)(IOCTL_STORAGE_QUERY_PROPERTY),
        //        ref nptwb, (uint)Marshal.SizeOf(nptwb), ref nptwb, (uint)Marshal.SizeOf(nptwb), ref dwReturned, IntPtr.Zero);

        //    Dip.safeCloseHandle(hIoCtrl);
        //    Stm.MemCpyTripleStruct<ATA_IDENTIFY_DEVICE, BIN_IDENTIFY_DEVICE, NVME_IDENTIFY_DEVICE>(ref nptwb.Buffer, ref data.A, ref data.B, ref data.N);

        //    #region MyRegion
        //    //ATA_IDENTIFY_DEVICE _aTA_IDENTIFY_DEVICE;
        //    //Unsafe.SkipInit(out _aTA_IDENTIFY_DEVICE);

        //    //BIN_IDENTIFY_DEVICE _bIN_IDENTIFY_DEVICE;
        //    //Unsafe.SkipInit(out _bIN_IDENTIFY_DEVICE);

        //    //NVME_IDENTIFY_DEVICE _nVME_IDENTIFY_DEVICE;
        //    //Unsafe.SkipInit(out _nVME_IDENTIFY_DEVICE);



        //    //data.A = _aTA_IDENTIFY_DEVICE;
        //    //data.B = _bIN_IDENTIFY_DEVICE;
        //    //data.N = _nVME_IDENTIFY_DEVICE;



        //    //#if NET8_0_OR_GREATER
        //    //            Stm.MemCpyTripleStruct<ATA_IDENTIFY_DEVICE, BIN_IDENTIFY_DEVICE, NVME_IDENTIFY_DEVICE>(ref nptwb.Buffer, ref _aTA_IDENTIFY_DEVICE, ref _bIN_IDENTIFY_DEVICE, ref _nVME_IDENTIFY_DEVICE);

        //    //            data.A = _aTA_IDENTIFY_DEVICE;
        //    //            data.B = _bIN_IDENTIFY_DEVICE;
        //    //            data.N = _nVME_IDENTIFY_DEVICE;
        //    //#elif NET48_OR_GREATER


        //    //            //IDENTIFY_DEVICE _iDENTIFY_DEVICE;
        //    //            //Unsafe.SkipInit(out _iDENTIFY_DEVICE);


        //    //            CopyMemory(ref _aTA_IDENTIFY_DEVICE, ref nptwb.Buffer[0], (uint)Marshal.SizeOf(typeof(ATA_IDENTIFY_DEVICE)));
        //    //            CopyMemory(ref _bIN_IDENTIFY_DEVICE, ref nptwb.Buffer[0], (uint)Marshal.SizeOf(typeof(BIN_IDENTIFY_DEVICE)));
        //    //            CopyMemory(ref _nVME_IDENTIFY_DEVICE, ref nptwb.Buffer[0], (uint)Marshal.SizeOf(typeof(NVME_IDENTIFY_DEVICE)));

        //    //            data.A = _aTA_IDENTIFY_DEVICE;
        //    //            data.B = _bIN_IDENTIFY_DEVICE;
        //    //            data.N = _nVME_IDENTIFY_DEVICE;

        //    //#else
        //    //            throw new InvalidOperationException("the framework not supported ");

        //    //#endif 
        //    #endregion


        //    return bRet;
        //}
    }
}
