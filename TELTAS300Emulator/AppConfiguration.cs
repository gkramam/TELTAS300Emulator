using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TELTAS300Emulator
{
    public class AppConfiguration
    {
        public static readonly int tcpWorkerLoopIdleTime;
        public static readonly int Port1;
        public static readonly int Port2;
        public static readonly int Port3;
        public static readonly int Port4;
        public static readonly int NumberOfSlotsInCasette;
        public static readonly Dictionary<string, int> CommandDelayLookup;
        public static Dictionary<NAKParams, string> NAKParamDescriptions;
        public static Dictionary<NAKWarnings, string> NAKWarningDescriptions;
        public static Dictionary<BeforeInterLocks, string> BeforeInterLockDescriptions;
        public static Dictionary<AfterInterLocks, string> AfterInterLockDescriptions;
        static AppConfiguration()
        {
            tcpWorkerLoopIdleTime = Convert.ToInt32(ConfigurationManager.AppSettings["tcpWorkerLoopIdleTime"]);
            Port1 = Convert.ToInt32(ConfigurationManager.AppSettings["Port1"]);
            Port2 = Convert.ToInt32(ConfigurationManager.AppSettings["Port2"]);
            Port3 = Convert.ToInt32(ConfigurationManager.AppSettings["Port3"]);
            Port4 = Convert.ToInt32(ConfigurationManager.AppSettings["Port4"]);
            NumberOfSlotsInCasette = Convert.ToInt32(ConfigurationManager.AppSettings["numberOfSlotsInCasette"]);

            NameValueCollection commandDelayCollection = (NameValueCollection)ConfigurationManager.GetSection("CommandDelays");
            CommandDelayLookup = commandDelayCollection.AllKeys.
                Select(k => new { key = k, value = Convert.ToInt32(commandDelayCollection[k]) }).ToDictionary(kvp => kvp.key, kvp => kvp.value);

            NAKParamDescriptions = new Dictionary<NAKParams, string>();
            NAKParamDescriptions.Add(NAKParams.CKSUM, "Checksum Error");
            NAKParamDescriptions.Add(NAKParams.CMDER, "Command Error");
            NAKParamDescriptions.Add(NAKParams.INTER, "Interlock Error");

            NAKWarningDescriptions = new Dictionary<NAKWarnings, string>();
            NAKWarningDescriptions.Add(NAKWarnings.CMDER, "Command Error");
            NAKWarningDescriptions.Add(NAKWarnings.CBUSY, "Communication Busy");
            NAKWarningDescriptions.Add(NAKWarnings.FPILG, "Foup Loading Error");
            NAKWarningDescriptions.Add(NAKWarnings.LATCH, "Latch Key Error");
            NAKWarningDescriptions.Add(NAKWarnings.YPOSI, "Y-Axis Position Error");
            NAKWarningDescriptions.Add(NAKWarnings.DPOSI, "Door Open/Close Position Error");
            NAKWarningDescriptions.Add(NAKWarnings.MPARM, "Mapper Arm Storage Error");
            NAKWarningDescriptions.Add(NAKWarnings.ZPOSI, "Z-Axis Position Error");
            NAKWarningDescriptions.Add(NAKWarnings.MPSTP, "Mapper Stopper Position Error");
            NAKWarningDescriptions.Add(NAKWarnings.DVACM, "Door - Being vaccumed");
            NAKWarningDescriptions.Add(NAKWarnings.ERROR, "Error");
            NAKWarningDescriptions.Add(NAKWarnings.ORGYT, "Initialization Incomplete");
            NAKWarningDescriptions.Add(NAKWarnings.CLDDK, "CLDDK Command is Incomplete");
            NAKWarningDescriptions.Add(NAKWarnings.CULDK, "CULDK Command is Incomplete");
            NAKWarningDescriptions.Add(NAKWarnings.CLOAD, "CLOAD Command is Incomplete");
            NAKWarningDescriptions.Add(NAKWarnings.RMPOS, "REMAP not ready");

            AfterInterLockDescriptions = new Dictionary<AfterInterLocks, string>();
            AfterInterLockDescriptions.Add(AfterInterLocks.AIRSN, "Main Air Error");
            AfterInterLockDescriptions.Add(AfterInterLocks.CLCLS, "FOUP Clamp Close Error");
            AfterInterLockDescriptions.Add(AfterInterLocks.DLMIT, "FOUP Coor close Error");
            AfterInterLockDescriptions.Add(AfterInterLocks.DRCLS, "Latch Cy close Error");
            AfterInterLockDescriptions.Add(AfterInterLocks.FANST, "Fan Operation Error");
            AfterInterLockDescriptions.Add(AfterInterLocks.INTCL, "Timeout Error Foup Closed");
            AfterInterLockDescriptions.Add(AfterInterLocks.INTOP, "Timeout Error Foup Opened");
            AfterInterLockDescriptions.Add(AfterInterLocks.MPBAR, "Mapper Arm Position Error");
            AfterInterLockDescriptions.Add(AfterInterLocks.MPEDL, "Mapping End position Error");
            AfterInterLockDescriptions.Add(AfterInterLocks.PROTS, "Wafer Protrusion");
            AfterInterLockDescriptions.Add(AfterInterLocks.SAFTY, "Interlock Circuit Failure");
            AfterInterLockDescriptions.Add(AfterInterLocks.VACCS, "Vacuum On Error");
            AfterInterLockDescriptions.Add(AfterInterLocks.YLMIT, "Y-axis Position Error");

            BeforeInterLockDescriptions = new Dictionary<BeforeInterLocks, string>();
            BeforeInterLockDescriptions.Add(BeforeInterLocks.CBUSY, "Communication Busy");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.CLDDK, "CLDDK Command Incomplete");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.CLOAD, "CLOAD Command Incomplete");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.CULDK, "CULDK Command Incomplete");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.DPOSI, "Door Open/ Close Position Error");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.DVACM, "Door -Being vaccumed");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.ERROR, "Error");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.FPILG, "Foup Loading Error");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.LATCH, "Latch Key Error");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.MPARM, "Mapper Arm Storage Error");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.MPSTP, "Mapper Stopper Position Error");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.ORGYT, "Initialization Incomplete");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.YPOSI, "Y-Axis Position Error");
            BeforeInterLockDescriptions.Add(BeforeInterLocks.ZPOSI, "Z-Axis Position Error");
        }
    }
}
