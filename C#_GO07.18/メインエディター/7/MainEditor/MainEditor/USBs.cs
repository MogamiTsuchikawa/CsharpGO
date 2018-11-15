using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Windows;
using System.Management;
using System.Reflection;

namespace MainEditor
{
    public class USBs
    {
        public static string GetUSBdeviceID()
        {
            Assembly myAssembly = Assembly.GetEntryAssembly();
            string path = myAssembly.Location;
            string drive = path.Substring(0, 2);
            string h = "Win32_LogicalDisk=\"" + drive + "\"";
            ManagementObject mo = new System.Management.ManagementObject(h);
            return (string)mo.Properties["VolumeSerialNumber"].Value;
        }
    }
}
