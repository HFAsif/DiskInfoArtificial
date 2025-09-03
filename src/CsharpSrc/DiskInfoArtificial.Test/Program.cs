using CrystalDiskInfoDotnet;
using CrystalDiskInfoDotnet.CheckDiskInfos;
using DiskInfoArtificial;
using DiskInfoArtificial.Test;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;


internal partial class Program 
{
    static Program() { }

    [STAThread]
    private static void Main(string[] args)
    {
        ExtractionType extractionType = ExtractionType.NugetExtraction;

        if(extractionType == ExtractionType.NugetExtraction)
        {
            CrystalDiskInfoDotnetLoad.ExtractFullInfos(out var vals);
        }
        else
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

                var options = new Cac.Options() { args = args };
                var cmParser = new Cmd.CommandLineParser() { cacOptions = options, _logger = logger };


                cmParser.Parse(options);

                CrystalDiskInfoDotnetBase crystalDiskInfoDotnetBase = new FinishingClass()
                {
                    DiskInfoArtificialEndedAt = dcEnd.ToString(),
                    logger = loggerFactory.CreateLogger<FinishingClass>(),
                    ataInfos = ataLists,
                    outPutInfos = cmParser.cacOptions.outPutInfos,
                };

                crystalDiskInfoDotnetBase.ExtracInformation();


                //ICrystalDiskInfoDotnet crystalDiskInfoDotnet;
                //crystalDiskInfoDotnet = new CrystalDiskInfoDotnetLoad()
                //{
                //    ataLists = ataLists,
                //    DiskInfoArtificialEndedAt = dcEnd.ToString(),
                //    logger = loggerFactory.CreateLogger<CrystalDiskInfoDotnetLoad>(),
                //    Options = cmParser.cacOptions
                //};
                //crystalDiskInfoDotnet.LoadInformation();

                //if (cmParser.cacOptions.outPutInfos == OutPutInfos.NugetTest)
                //{
                //    diskInfoArtificialManager = new CrystalDiskInfoDotnet() { ataLists = ataLists, 
                //        DiskInfoArtificialEndedAt = dcEnd.ToString(), logger = loggerFactory.CreateLogger<CrystalDiskInfoDotnet>(), 
                //        Options = cmParser.cacOptions
                //    };

                //    diskInfoArtificialManager.ExternalRun();
                //}
                //else
                //{
                //    diskInfoArtificialManager = new FinishingClass()
                //    {
                //        Options = cmParser.cacOptions,
                //        logger = loggerFactory.CreateLogger<FinishingClass>(),
                //        DiskInfoArtificialEndedAt = dcEnd.ToString(),
                //        ataLists = ataLists,
                //        args = args
                //    };

                //    diskInfoArtificialManager.ExternalRun();
                //}

            }
            else
            {
                //IDiskInfoArtificialManager diskInfoArtificialManager = new IntelLibrary() { args = args };
                //diskInfoArtificialManager.ExternalRun();
            }
            Console.ReadLine();
        }
    }
}