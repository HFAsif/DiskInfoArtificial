using DiskInfoArtificial;
using DiskInfoArtificial.Test;
using InternalLibrary;
using InternalLibrary.CheckDiskInfos;
using Microsoft.Extensions.Logging;
using System;
using System.IO.MemoryMappedFiles;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;


internal partial class Program : ProgramBase
{
    static Program() { }

    [STAThread]
    private static void Main(string[] args)
    {

        bool DiskInfosCheck = true;
        Unsafe.SkipInit(out DiskInfosCheck);

        if (DiskInfosCheck)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            bool NativeTest = false;

            MainEntry.Run(NativeTest, out var ataLists, args);
            stopwatch.Stop();
            var dcEnd = stopwatch.Elapsed;

            using var loggerFactory = LoggerFactory.Create(static builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("DiskInfoArtificial.Test.Program", LogLevel.Debug)
                    .AddConsole();
            });

            var logger = loggerFactory.CreateLogger<Program>();

            logger.LogInformation($"Infos Extracted Ended in {dcEnd}");

            var options = new Cac.Options();
            var cmParser = new Cmd.CommandLineParser() { _logger = logger, args = args };


            cmParser.Parse(options);

            var _inishingClas = new FinishingClass() { Options = cmParser.cacOptions, logger = loggerFactory.CreateLogger<FinishingClass>(), DiskInfoArtificialEndedAt = dcEnd.ToString() ,
                ataLists = ataLists, args = args
            };

            _inishingClas.EndingMethod();
        }
        else
        {
            IDiskInfoArtificialManager diskInfoArtificialManager = new IntelLibrary() { args = args };
            diskInfoArtificialManager.ExternalRun();
        }
    }
}