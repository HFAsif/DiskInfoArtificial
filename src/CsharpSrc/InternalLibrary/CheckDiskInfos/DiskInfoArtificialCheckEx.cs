namespace InternalLibrary.CheckDiskInfos;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

internal class DiskInfoArtificialCheckEx : IDiskInfoArtificialCheck
{
    public required OutPutInfos InfoType { get; set; }
    public required object ataInfos {  get; set; }
    public string[] args { get ; set ; }

    //async Task AsysRunEx()
    //{
        
    //    //using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
    //    //ILogger logger = factory.CreateLogger("DiskInfoArtificialCheck");

    //    //if (ExtendInfos)
    //    //{
    //    //    ObservableCollection<ExtendedInfos> infoForCasts = new ObservableCollection<ExtendedInfos>();
    //    //}
    //    //else
    //    //{
    //    //    var OptimizedListBuilder = new ReadOnlyCollectionBuilder<ObservableCollection<KeyValuePair<string, string>>>();
    //    //    Unsafe.SkipInit(out OptimizedListBuilder);
    //    //}
        

    //    //if (ataInfos is not null and IList ataList)
    //    //{
            

    //    //    foreach (var ata in ataList)
    //    //    {
    //    //        var OptimizedInfos = new ObservableCollection<KeyValuePair<string, string>>();

    //    //        ExtendedInfos infoForCast = new ExtendedInfos();
    //    //        var infoFields = infoForCast.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
    //    //        var ataFields = ata.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

    //    //        foreach (var afield in ataFields)
    //    //        {
    //    //            var ataFieldVal = afield.GetValue(ata);
    //    //            if (ataFieldVal is not null)
    //    //            {
    //    //                if (ExtendInfos)
    //    //                {
    //    //                    var infoField = infoFields.ToList().Find(a => a.Name == afield.Name);
    //    //                    if (infoField is not null)
    //    //                    {
    //    //                        infoField.SetValue(infoForCast, ataFieldVal);
    //    //                    }
    //    //                }
    //    //                else
    //    //                {
    //    //                    if (new Type[] { typeof(ushort), typeof(uint), typeof(ulong), typeof(byte), typeof(string), typeof(int) }.Contains(afield.FieldType) 
    //    //                        && !string.IsNullOrEmpty(ataFieldVal.ToString()) )
    //    //                    {
    //    //                        if (ataFieldVal.ToString().Contains("-")) continue;
    //    //                        if (ataFieldVal.ToString().All(Char.IsDigit) && int.TryParse(ataFieldVal.ToString(), out var rs) && rs is 0) continue;

    //    //                        OptimizedInfos.Add(new KeyValuePair<string, string>(afield.Name, ataFieldVal.ToString()));
    //    //                    }
                                
    //    //                }
    //    //            }

                    
    //    //        }

    //    //        if (ExtendInfos)
    //    //            infoForCasts.Add(infoForCast);
    //    //        else
    //    //            OptimizedListBuilder.Add(OptimizedInfos);
    //    //    }
    //    //}



    //    ////var json = JsonConvert.SerializeObject(infoForCast, Formatting.Indented);
    //    ////logger.LogInformation(json);
    //    //////Console.WriteLine(json);
    //    //await Task.Delay(100); // Wait for logs to be written
    //}

    bool OptimizedInfosMethod(FieldInfo fieldInfo, object val, ref ObservableCollection<KeyValuePair<string, string>> OptimizedInfos)
    {
        if (new Type[] { typeof(ushort), typeof(uint), typeof(ulong), typeof(byte), typeof(string), typeof(int) }.Contains(fieldInfo.FieldType)
                                && !string.IsNullOrEmpty(val.ToString()))
        {
            if (val.ToString().Contains("-")) return false;
            if (val.ToString().All(Char.IsDigit) && int.TryParse(val.ToString(), out var rs) && rs is 0) return false;

            OptimizedInfos.Add(new KeyValuePair<string, string>(fieldInfo.Name, val.ToString()));
            return true;
        }
        return false;
    }

    bool ExtendInfosMethod(FieldInfo fieldInfo, object val, ref ExtendedInfosStruct extendedInfos)
    {
        var infoFields = extendedInfos.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

        var infoField = infoFields.ToList().Find(a => a.Name == fieldInfo.Name);
        if (infoField is not null)
        {
            infoField.SetValue(extendedInfos, val);
            return true;
        }
        return false;
    }

    void ExtractInfosEx(OutPutInfos InfoType)
    {
        ObservableCollection<ExtendedInfosStruct> infoForCasts;
        ReadOnlyCollectionBuilder<ObservableCollection<KeyValuePair<string, string>>> OptimizedListBuilder;

        Unsafe.SkipInit(out infoForCasts);
        Unsafe.SkipInit(out OptimizedListBuilder);

        if (InfoType == OutPutInfos.ExtendedInfos)
        {
            infoForCasts = new();
        }
        else if (InfoType == OutPutInfos.OptimizedInfos)
        {
            OptimizedListBuilder = new();
        }
        else goto ErrorCode;

        if (ataInfos is not null and IList ataList)
        {
            foreach (var ata in ataList)
            {
                ExtendedInfosStruct extendedInfos;
                ObservableCollection<KeyValuePair<string, string>> optimizedInfos;
                Unsafe.SkipInit(out  extendedInfos);
                Unsafe.SkipInit(out optimizedInfos);

                if (InfoType == OutPutInfos.ExtendedInfos)
                {
                    extendedInfos = new();
                }
                else if (InfoType == OutPutInfos.OptimizedInfos)
                {
                    optimizedInfos = new();
                }
                else goto ErrorCode;

                var ataFields = ata.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

                foreach (var afield in ataFields)
                {
                    var ataFieldVal = afield.GetValue(ata);
                    if (ataFieldVal is not null)
                    {
                        if (InfoType == OutPutInfos.ExtendedInfos)
                        {

                            if (!ExtendInfosMethod(afield, ataFieldVal, ref extendedInfos)) continue;
                        }
                        else if (InfoType == OutPutInfos.OptimizedInfos)
                        {
                            if (!OptimizedInfosMethod(afield, ataFieldVal, ref optimizedInfos)) continue;
                        }
                        else goto ErrorCode;

                        //InfoType == OutPutInfos.ExtendedInfos ? ExtendInfos(afield, ataFieldVal, out var extendedInfos) : OptimizedInfos(afield, ataFieldVal, out var optimizedInfos);
                    }


                }

                if (InfoType == OutPutInfos.ExtendedInfos)
                    infoForCasts.Add(extendedInfos);
                else if (InfoType == OutPutInfos.OptimizedInfos)
                    OptimizedListBuilder.Add(optimizedInfos);
                else goto ErrorCode;
            }
        }

        //foreach (var info in infoForCasts)
        //{
        //    var json = JsonConvert.SerializeObject(info, Formatting.Indented);
        //    Console.WriteLine(json);
        //}
        return;

    ErrorCode:
        GetingError();
    }


    //interface IExtendOptimizedInfos
    //{
    //    FieldInfo fieldInfo { get; set; }

    //    object fieldVal { get; set; }
    //}


    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class ExtendOptimizedAttr : Attribute
    {
        public void AtaFieldInfos(Action GetingError, object ataInfos, out ReadOnlyCollectionBuilder<ObservableCollection<KeyValuePair<FieldInfo, object>>> FiledsInfosBuild)
        {
            FiledsInfosBuild = [];

            if (ataInfos is not null and IList ataList)
            {
                var enumerator = ataList.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    do
                    {
                        var ataClass = enumerator.Current;
                        var ataFields = ataClass.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
                        ObservableCollection<KeyValuePair<FieldInfo, object>> FiledValuePairs = [];
                        foreach (var atafield in ataFields)
                        {
                            if (atafield.GetValue(ataClass) is not null and object ataFieldVal)
                            {
                                FiledValuePairs.Add(new KeyValuePair<FieldInfo, object>(atafield, ataFieldVal));
                            }
                        }
                        FiledsInfosBuild.Add(FiledValuePairs);
                    }
                    while (enumerator.MoveNext());
                }
            }
            else goto ErrorCode;
            return;

        ErrorCode:
            GetingError();
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    sealed class ExtendOptimizedWorker: Attribute
    {
        public ExtendedInfosStruct extendedInfos;
        public ObservableCollection<KeyValuePair<string, string>> optimizedInfos;
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class ExtendOptimizedDetails : Attribute
    {
        public readonly string  Details;

        public ExtendOptimizedDetails(string details) 
        {
            Details = details;
        }

        
    }

    
    abstract class ExtendOptimizedAbstract
    {
        [ExtendOptimizedWorker]
        public abstract void Infos(FieldInfo fieldInfo, ref readonly object fieldVal);

    }

    [ExtendOptimizedAttr]
    [ExtendOptimizedDetails("It does contains a full infos without null value")]
    class ExtendedInfosInternal : ExtendOptimizedAbstract
    {
        public required object extendedInfos { get; set; }

        public  override void Infos(FieldInfo fieldInfo, ref readonly object fieldVal)
        {
            var infoFields = extendedInfos.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

            var infoField = infoFields.ToList().Find(a => a.Name == fieldInfo.Name);
            if (infoField is not null)
            {
                infoField.SetValue(extendedInfos, fieldVal);
            }
        }
    }

    [ExtendOptimizedAttr]
    [ExtendOptimizedDetails("It does contains all infos except 0 and bool value")]
    class OptimizedInfosInternal : ExtendOptimizedAbstract
    {
        public required dynamic OptimizedInfos { get; set; }

        public override void Infos(FieldInfo fieldInfo, ref readonly object fieldVal)
        {
            //if (OptimizedInfos != typeof(ObservableCollection<KeyValuePair<string, string>>))
            //    throw new InvalidOperationException("null object");

            if (new Type[] { typeof(ushort), typeof(uint), typeof(ulong), typeof(byte), typeof(string), typeof(int) }.Contains(fieldInfo.FieldType)
                                && !string.IsNullOrEmpty(fieldVal.ToString()))
            {
                if (fieldVal.ToString().Contains("-")) return;
                if (fieldVal.ToString().All(Char.IsDigit) && int.TryParse(fieldVal.ToString(), out var rs) && rs is 0) return;

                OptimizedInfos.Add(new KeyValuePair<string, string>(fieldInfo.Name, fieldVal.ToString()));
            }
        }
    }


    class ExtendOptimizedMain
    {
        void Distribution(ObservableCollection<KeyValuePair<FieldInfo, object>> ataEnumerator, ExtendedInfosStruct extendedInfos = null, 
            ObservableCollection<KeyValuePair<string, string>> optimizedInfos = null)
        {

        }
    }

    void AtaFieldInfos(out ReadOnlyCollectionBuilder<ObservableCollection<KeyValuePair<FieldInfo, object>>> FiledsInfosBuild)
    {
        //if (InfoType == OutPutInfos.ExtendedInfos)
        //{
        //    ObservableCollection<ExtendedInfos> infoForCasts;
        //    Unsafe.SkipInit(out infoForCasts);
        //}
        //else if ((InfoType == OutPutInfos.OptimizedInfos))
        //{
        //    ReadOnlyCollectionBuilder<ObservableCollection<KeyValuePair<string, string>>> OptimizedListBuilder;
        //    Unsafe.SkipInit(out OptimizedListBuilder);
        //}
        //else goto ErrorCode;

        FiledsInfosBuild = [];

        if (ataInfos is not null and IList ataList)
        {
            var enumerator = ataList.GetEnumerator();
            if (enumerator.MoveNext())
            {
                do
                {
                    var ataClass = enumerator.Current;
                    var ataFields = ataClass.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
                    ObservableCollection<KeyValuePair<FieldInfo, object>> FiledValuePairs = [];
                    foreach (var atafield in ataFields)
                    {
                        if (atafield.GetValue(ataClass) is not null and object ataFieldVal)
                        {
                            FiledValuePairs.Add(new KeyValuePair<FieldInfo, object>(atafield, ataFieldVal));
                        }
                    }
                    FiledsInfosBuild.Add(FiledValuePairs);
                }
                while (enumerator.MoveNext());
            }
        }
        else goto ErrorCode;
        return;

        ErrorCode:
        GetingError();
    }


    //void Distribution(
    //    [In] ObservableCollection<KeyValuePair<FieldInfo, object>> ataEnumerator,
    //    [Out] ExtendedInfos extendedInfos = null) => Distribution(ataEnumerator, extendedInfos, null);

    //void Distribution(
    //     [In] ObservableCollection<KeyValuePair<FieldInfo, object>> ataEnumerator,
    //    [Out] ObservableCollection<KeyValuePair<string, string>> optimizedInfos = null)
    //    => Distribution(ataEnumerator, null, optimizedInfos);

    void Distribution(
        [In] ObservableCollection<KeyValuePair<FieldInfo, object>> ataEnumerator, out object Extraction)
    {
        var Abstractmethod = typeof(ExtendOptimizedAbstract).GetMethods(BindingFlags.Instance | BindingFlags.Public).ToList().Find(a => a.IsAbstract);
        Extraction = Abstractmethod.GetCustomAttribute<ExtendOptimizedWorker>();
        ExtendOptimizedAbstract extendOptimizedAbstract;
        Unsafe.SkipInit(out  extendOptimizedAbstract);  

        if (Extraction is not null and ExtendOptimizedWorker attr)
        {
            if (InfoType == OutPutInfos.ExtendedInfos)
            {
                extendOptimizedAbstract = new ExtendedInfosInternal()
                { extendedInfos = attr.extendedInfos == null ? attr.extendedInfos = new() : throw new InvalidOperationException() };
            }
            else if (InfoType == OutPutInfos.OptimizedInfos)
            {
                extendOptimizedAbstract = new OptimizedInfosInternal()
                { OptimizedInfos = attr.optimizedInfos == null ? attr.optimizedInfos = new ObservableCollection<KeyValuePair<string, string>>() : throw new InvalidOperationException() };
            }
            else GetingError();

            foreach (var ataValuePair in ataEnumerator)
            {
                var FieldKey = ataValuePair.Key;
                var FieldValule = ataValuePair.Value;
                extendOptimizedAbstract.Infos(FieldKey, ref FieldValule);
            }
        }

        #region MyRegion
        //if (Extraction is not null and ExtendOptimizedWorker attr)
        //{
        //    foreach (var ataValuePair in ataEnumerator)
        //    {
        //        var FieldKey = ataValuePair.Key;
        //        var FieldValule = ataValuePair.Value;

        //        //if (InfoType == OutPutInfos.ExtendedInfos)
        //        //{
        //        //    extendOptimizedAbstract = new ExtendedInfosInternal()
        //        //    { extendedInfos = new() };
        //        //    extendOptimizedAbstract.Infos(FieldKey, ref FieldValule);
        //        //}
        //        //else if (InfoType == OutPutInfos.OptimizedInfos)
        //        //{
        //        //    extendOptimizedAbstract = new OptimizedInfosInternal()
        //        //    { OptimizedInfos = attr.extendedInfos };
        //        //    extendOptimizedAbstract.Infos(FieldKey, ref FieldValule);
        //        //}
        //        //else GetingError();

        //        #region MyRegion
        //        //ExtendOptimizedAbstract extendOptimizedAbstract;


        //        //Unsafe.SkipInit(out  extendOptimizedAbstract);



        //        //if (infos is ExtendedInfos)
        //        //{
        //        //    extendOptimizedAbstract = new ExtendedInfosInternal()
        //        //    { extendedInfos = infos };
        //        //    extendOptimizedAbstract.Infos(FieldKey, ref FieldValule);
        //        //}
        //        //else if (infos is ObservableCollection<KeyValuePair<string, string>>)
        //        //{
        //        //    extendOptimizedAbstract = new OptimizedInfosInternal()
        //        //    { OptimizedInfos = infos };
        //        //    extendOptimizedAbstract.Infos(FieldKey, ref FieldValule);
        //        //}
        //        //else GetingError();


        //        //if (InfoType == OutPutInfos.ExtendedInfos)
        //        //{
        //        //    ExtendOptimizedAbstract extendOptimizedAbstract = new ExtendedInfosInternal()
        //        //    { fieldInfo = FieldKey, fieldVal = FieldValule };
        //        //    extendOptimizedAbstract.Infos();
        //        //}
        //        //else if (InfoType == OutPutInfos.OptimizedInfos)
        //        //{
        //        //}
        //        //else GetingError(); 
        //        #endregion


        //    }
        //} 
        #endregion
        else GetingError();

        
    }

    public void ExternalRun(out ObservableCollection<ExtendedInfosStruct> infoForCasts, out ReadOnlyCollectionBuilder<ObservableCollection<KeyValuePair<string, string>>> OptimizedListBuilder)
    {
        Unsafe.SkipInit(out infoForCasts);
        Unsafe.SkipInit(out OptimizedListBuilder);

        if (InfoType == OutPutInfos.ExtendedInfos)
            infoForCasts = new();
        else if (InfoType == OutPutInfos.OptimizedInfos)
            OptimizedListBuilder = [];
        else GetingError();


        if (Attribute.IsDefined(typeof(OptimizedInfosInternal), typeof(ExtendOptimizedAttr)))
        {
            var attr = typeof(OptimizedInfosInternal).GetCustomAttribute<ExtendOptimizedAttr>();
            attr.AtaFieldInfos(GetingError, ataInfos, out var filedsInfosBuild);

            var enumerator = filedsInfosBuild.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var ataEnumerator = enumerator.Current;

                Distribution(ataEnumerator, out var ExtractedInfos);


                if (ExtractedInfos is ExtendOptimizedWorker worker)
                {
                    if (worker.extendedInfos is not null)
                        infoForCasts.Add(worker.extendedInfos);
                    if (worker.optimizedInfos is not null)
                        OptimizedListBuilder.Add(worker.optimizedInfos);
                }
                    
                



                //if (ExtractedInfos is ExtendOptimizedWorker optimizedInfos) OptimizedListBuilder.Add(optimizedInfos);
            }
        }

        //Task.Run( () => { ExtractInfos(); }).Wait();

    }

    void GetingError()
    {
        Debugger.Break();
        //not setted or Invalid Operation so
        throw new InvalidOperationException("not setted");
    }
}
