namespace CrystalDiskInfoDotnet.CheckDiskInfos;

using DiskInfoArtificial;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

[SomeElementsInfos("Load information")]
[SomeElementsInfos("Internal coded")]
public class CrystalDiskInfoDotnetLoad 
{
    public static readonly string extractTime;
    static readonly object ataLists;
    static CrystalDiskInfoDotnetLoad()
    {
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        MainEntry.Run(out ataLists);
        stopwatch.Stop();
        extractTime = stopwatch.Elapsed.ToString();
    }

    public static void ExtractOptimizedInfos(out ReadOnlyCollectionBuilder<ObservableCollection<KeyValuePair<string, string>>> OptimizedListBuilder)
    {
        DynamicCast(OutPutInfos.OptimizedInfos, out OptimizedListBuilder);
    }

    public static void ExtractFullInfos(out ObservableCollection<ExtendedInfosStruct> vals)
    {
        DynamicCast(OutPutInfos.ExtendedInfos, out vals);
    }

    static void DynamicCast<T>(OutPutInfos outPutInfos, out T vals)
    {
        ExtracIFullInfos(outPutInfos, out var OptimizedListBuilder, out var extendedInfos);

        if (outPutInfos == OutPutInfos.OptimizedInfos && OptimizedListBuilder is T optList)
        {
            vals = optList;
        }
        else if (outPutInfos == OutPutInfos.ExtendedInfos && extendedInfos is T exInfos)
        {
            vals = exInfos;
        }
        else throw new GettingExceptions("invalid typecast ");
    }

    static void ExtracIFullInfos(OutPutInfos outPutInfos, out ReadOnlyCollectionBuilder<ObservableCollection<KeyValuePair<string, string>>> OptimizedListBuilder, out ObservableCollection<ExtendedInfosStruct> extendedInfos)
    {
        var crystalDiskInfoDotnet = new CrystalDiskInfoDotnetLoadInformation()
        { ataInfos = ataLists, InfoType = outPutInfos };
        crystalDiskInfoDotnet.LoadInformation(out extendedInfos, out OptimizedListBuilder);
    }

    //public static void ExtracIFullInfos(out ObservableCollection<ExtendedInfosStruct> infoForCasts)
    //{

    //}

    //public static void ExtracIOptimizedInfos(out ReadOnlyCollectionBuilder<ObservableCollection<KeyValuePair<string, string>>> OptimizedListBuilder)
    //{
    //    Unsafe.SkipInit(out vals);


    //    var crystalDiskInfoDotnet = new CrystalDiskInfoDotnetLoadInformation()
    //    { ataInfos = ataLists , InfoType = infosType };

    //    crystalDiskInfoDotnet.LoadInformation(out var infoForCasts, out var OptimizedListBuilder);
    //    if (infoForCasts is not null)
    //    {
    //        vals = infoForCasts;
    //    }
    //    else if (OptimizedListBuilder is not null)
    //    {
    //        vals = OptimizedListBuilder;
    //    }

    //    //if (OptimizedListBuilder is not null)
    //    //{
    //    //    var build = OptimizedListBuilder.ToReadOnlyCollection();
    //    //    foreach (var item in build)
    //    //    {
    //    //        if (item is not null)
    //    //        {
    //    //            foreach (var item2 in item)
    //    //            {

    //    //            }
    //    //        }

    //    //    }
    //    //}
    //    //else if (infoForCasts is not null)
    //    //{
    //    //    var _infoForCasts = infoForCasts;
    //    //    foreach (var item in _infoForCasts)
    //    //    {

    //    //    }
    //    //    Task.Delay(1000);
    //    //}

    //}
}
