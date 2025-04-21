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
            using (var syntecRemote = new SyntecRemoteCNC("192.168.0.100"))
            {

                bool isUsb = syntecRemote.isUSBExist();
                Console.WriteLine("Is USB exist: {0}", isUsb);
                
                short remoteTimeCode = syntecRemote.READ_remoteTime(out DateTime remoteTime);
                Console.WriteLine("Remote time. Code: {0}, Data: {1}", remoteTimeCode, remoteTime);

                short plcVersionCode = syntecRemote.READ_plc_ver(out string version);
                Console.WriteLine("PLC Version. Code: {0}, Data: {1}", plcVersionCode, version);
                
            }
            
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