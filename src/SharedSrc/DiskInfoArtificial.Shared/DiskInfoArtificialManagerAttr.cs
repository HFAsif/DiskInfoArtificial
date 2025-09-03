

namespace DiskInfoArtificial;
using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
class DiskInfoArtificialManagerAttr : Attribute
{
    public bool BTAPassThroughSmart { get; private set; }

    public DiskInfoArtificialManagerAttr()
    {
        BTAPassThroughSmart = true;
    }
}
