namespace DiskInfoArtificial.Test;

using InternalLibrary;
using System.Reflection;

internal class FinishingClassBase
{
    [SomeElementsInfos("The code copied from wwh00")]
    private static T GetAssemblyAttribute<T>()
    {
        return (T)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), false)[0];
    }

    [SomeElementsInfos("The code copied from wwh00")]
    protected static string GetTitle()
    {
        string productName;
        string version;
        string copyright;
        int firstBlankIndex;
        string copyrightOwnerName;
        string copyrightYear;

        productName = GetAssemblyAttribute<AssemblyProductAttribute>().Product;
        version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        copyright = GetAssemblyAttribute<AssemblyCopyrightAttribute>().Copyright.Substring(12);
        firstBlankIndex = copyright.IndexOf(' ');
        copyrightOwnerName = copyright.Substring(firstBlankIndex + 1);
        copyrightYear = copyright.Substring(0, firstBlankIndex);
        return $"{productName} v{version} by {copyrightOwnerName} {copyrightYear}";
    }
}
