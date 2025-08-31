namespace InternalLibrary.CheckDiskInfos;
using System.Linq;
using System.Reflection;

[ExtendOptimizedAttr]
[SomeElementsInfos("It does contains a full infos without null value")]
class ExtendedInfos : ExtendOptimizedAbstract
{
    public required object extendedInfos { get; set; }

    public override void Infos(FieldInfo fieldInfo, ref readonly object fieldVal)
    {
        var infoFields = extendedInfos.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);

        var infoField = infoFields.ToList().Find(a => a.Name == fieldInfo.Name);
        if (infoField is not null)
        {
            infoField.SetValue(extendedInfos, fieldVal);
        }
    }
}
