using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;   //This namespace is used to work with WMI classes. For using this namespace add reference of System.Management.dll .
using Microsoft.Win32;     //This namespace is used to work with Registry editor.


namespace ConsoleApplication1

{
    

    class TestProgram
    {
        
        static void Main(string[] args)
        {
            SystemInfo si = new SystemInfo();       //Create an object of SystemInfo class.
            si.getOperatingSystemInfo();            //Call get operating system info method which will display operating system information.
            si.getProcessorInfo();                  //Call get  processor info method which will display processor info.
            Console.ReadLine();                     //Wait for user to accept input key.
        }
    }
    public class SystemInfo
    {
        public void getOperatingSystemInfo()
        {
            Console.WriteLine("Displaying operating system info....\n");
            //Create an object of ManagementObjectSearcher class and pass query as parameter.
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {

                Globals.operating_system = managementObject["Caption"].ToString() + " " + managementObject["OSArchitecture"].ToString();

                Console.WriteLine(Globals.operating_system);
            
            }
        }

        public void getProcessorInfo()
        {
        
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    Globals.cpu_name = processor_name.GetValue("ProcessorNameString").ToString();   //Display processor ingo.
                    Console.WriteLine(Globals.cpu_name);
                }
            }
        }

        public void 
    }
}