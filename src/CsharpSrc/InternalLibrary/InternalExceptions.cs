namespace InternalLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class InternalExceptions : Exception
{
    
    public readonly int code;
    public InternalExceptions(int code) => this.code = code;

    public InternalExceptions(string msd)
    {
        if (string.IsNullOrEmpty(msd))
        {
            Debugger.Break();
        }
    }
}