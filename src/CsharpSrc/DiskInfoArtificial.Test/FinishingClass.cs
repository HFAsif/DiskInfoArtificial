namespace DiskInfoArtificial.Test;

using Microsoft.Extensions.Logging;
using System.Reflection;
using System;
using InternalLibrary.CheckDiskInfos;
using System.Linq;
using InternalLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnvDTE80;
using Newtonsoft.Json;

internal class FinishingClass : FinishingClassBase
{
    public required string DiskInfoArtificialEndedAt;
    public required object ataLists;
    public required ILogger logger;
    public required Cac.Options Options;


    public required string[] args {  get; set; }

    [SomeElementsInfos("Coded internal")]
    [FinishingClassAttr]
    public void EndingMethod()
    {
       
        Console.Title = GetTitle();
        var prgAttr = MethodBase.GetCurrentMethod().GetCustomAttribute<FinishingClassAttr>();
        prgAttr.PrimaryWorker(logger);

        IDiskInfoArtificialCheck diskInfoArtificialManager = new DiskInfoArtificialCheck()
        {
            ataInfos = ataLists, 
            InfoType = Options.outPutInfos
        };

        diskInfoArtificialManager.ExternalRun(out var infoForCasts, out var optimizedListBuilder);

        
        //EnvDTE.DTE dte = (EnvDTE.DTE)GetActiveObject("VisualStudio.DTE");
        if(optimizedListBuilder is not null)
        {
            
            foreach (var item in optimizedListBuilder)
            {
                Console.WriteLine(Environment.NewLine + Environment.NewLine);
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2.Key + "  :  " + item2.Value);
                }
            }
            
            Task.Delay(1000);
        }
        else if (infoForCasts is not null)
        {
            Console.WriteLine(Environment.NewLine + Environment.NewLine);
            var _infoForCasts = infoForCasts;
            foreach (var item in _infoForCasts)
            {
                var json = JsonConvert.SerializeObject(item, Formatting.Indented);
                logger.LogInformation(json);
            }
            Task.Delay(1000);
        }

        var currentAsm = AppDomain.CurrentDomain.GetAssemblies().GetEnumerator();
        //var memList = currentAsm.GetType().GetMembers();

        #region MyRegion
        //var asm = (Assembly)currentAsm.Current;

        ////var types = from type in asm.GetTypes()
        ////            where Attribute.IsDefined(type, typeof(SomeElementsInfos))
        ////            select type;

        ////var tpenum = types.GetEnumerator();

        ////if (tpenum.MoveNext())
        ////{
        ////    do
        ////    {
        ////        var tpcr = tpenum.Current;
        ////        var tarGetattr = tpcr.GetCustomAttribute<SomeElementsInfos>();
        ////        smList.Add(tpcr);

        ////        foreach (var method in tpcr.GetRuntimeMethods())
        ////        {
        ////            var smm = method.GetCustomAttribute<SomeElementsInfos>();
        ////            if (smm != null)
        ////            {
        ////                smList.Add(method);
        ////            }
        ////        }
        ////    }
        ////    while (tpenum.MoveNext());
        ////}


        //foreach (var type in smTypeList)
        //{

        //    if (Attribute.IsDefined(type, typeof(SomeElementsInfos)))
        //    {
        //        smTpList.Add(type);
        //    }
        //    foreach (var method in type.GetRuntimeMethods())
        //    {
        //        var smm = method.GetCustomAttribute<SomeElementsInfos>();
        //        if (smm != null)
        //        {
        //            smMtList.Add(method);
        //        }
        //    }
        //} 
        #endregion


        List<object> smTpList = new List<object>();
        List<MethodInfo> smMtList = new List<MethodInfo>();
        
        if(currentAsm.MoveNext() )
        {
            do
            {
                var asm = (Assembly)currentAsm.Current;
                foreach (var type in asm.GetTypes())
                {
                    if (Attribute.IsDefined(type, typeof(SomeElementsInfos)))
                    {
                        smTpList.Add(type);
                    }
                    foreach (var method in type.GetRuntimeMethods())
                    {
                        var smm = method.GetCustomAttribute<SomeElementsInfos>();
                        if (smm != null)
                        {
                            smMtList.Add(method);
                        }
                    }
                }

                #region MyRegion

                //var types =  (from type in asm.GetTypes()
                //            where Attribute.IsDefined(type, typeof(SomeElementsInfos))
                //            select type).ToList().Cast<object>();

                //if (types.Count() > 0)
                //{
                //    smTpList.Add(types);
                //}


                //var methods = from type in asm.GetTypes() from method in type.GetRuntimeMethods() where method.GetCustomAttribute<SomeElementsInfos>() is not null select method;

                //if(methods.Count() > 0)
                //{
                //    smMtList = methods.ToList();
                //}
                #endregion
            }
            while (currentAsm.MoveNext());
        }

        foreach (var smUnion in smTpList.Union(smMtList))
        {
            //var smDynamic = ((dynamic)smUnion).GetCustomAttribute<SomeElementsInfos>();
            //Console.WriteLine("class name {0}, " + smDynamic.Details, Environment.NewLine + ((dynamic)smUnion).Name);

            if (smUnion is Type type)
            {
                var smtpattr = type.GetCustomAttribute<SomeElementsInfos>();
                logger.LogInformation("class name {0}, " + smtpattr.Details, Environment.NewLine + type.FullName);
            }
            else if (smUnion is MethodInfo method)
            {
                var smmattr = method.GetCustomAttribute<SomeElementsInfos>();
                logger.LogInformation("method name {0}, " + smmattr.Details, Environment.NewLine + method.Name);
            }

        }

        
    }
}


