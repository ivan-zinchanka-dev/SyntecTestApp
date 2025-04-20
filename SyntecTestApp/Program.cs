using System;
using Syntec.MMICommon;
using Syntec.OpenCNC;
using Syntec.Remote;
using SyntecRemote;

public static class Program
{
    public static void Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledExceptionCaught;
        
        try
        {
            var syntecRemote = new SyntecRemoteCNC("192.168.0.100");
            bool isUsb = syntecRemote.isUSBExist();
            Console.WriteLine("Is USB: " + isUsb);
            
            var plc = Cnc.PLC;
            Console.WriteLine("PLC: " + plc);
            
            /*Init.MMI_Phase1();
            Console.WriteLine("MMI Phase 1");*/

            /*var synRemObj = new SyntecRemoteObj("192.168.0.100", 1000);
            Console.WriteLine("Is connected: " + synRemObj.IsConnected());*/
        }
        catch (DllNotFoundException importLibException)
        {
            Console.WriteLine(importLibException);
        }
        catch (Exception commonException)
        {
            Console.WriteLine(commonException);
        }
        
    }

    private static void OnUnhandledExceptionCaught(object sender, UnhandledExceptionEventArgs eventArgs)
    {
        if (eventArgs.ExceptionObject is Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}