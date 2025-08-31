namespace InternalLibrary.CheckDiskInfos;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

public interface IDiskInfoArtificialCheck
{
    //string[] args { get; set; }

    void ExternalRun(out ObservableCollection<ExtendedInfosStruct> infoForCasts, out ReadOnlyCollectionBuilder<ObservableCollection<KeyValuePair<string, string>>> OptimizedListBuilder);
}
