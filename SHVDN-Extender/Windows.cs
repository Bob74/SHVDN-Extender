using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SE
{
    class Windows
    {
        public enum VisualCVersion
        {
            Visual_2017,
            Visual_2015,
            Visual_2013,
            Visual_2012,
            Visual_2010,
            Visual_2008,
            Visual_2005,
        }

        private static readonly Dictionary<VisualCVersion, Version> visualCVersion = new Dictionary<VisualCVersion, Version>
        {
            { VisualCVersion.Visual_2017, new Version("14.1.0.0")},
            { VisualCVersion.Visual_2015, new Version("14.0.0.0")},
            { VisualCVersion.Visual_2013, new Version("12.0.0.0")},
            { VisualCVersion.Visual_2012, new Version("11.0.0.0")},
            { VisualCVersion.Visual_2010, new Version("10.0.0.0")},
            { VisualCVersion.Visual_2008, new Version("9.0.0.0")},
            { VisualCVersion.Visual_2005, new Version("8.0.0.0")}
        };

        public static bool IsVisualCVersionHigherOrEqual(VisualCVersion visualC)
        {
            Version targetVersion = visualCVersion[visualC];

            string[] filters = { "msvcp*.dll", "msvcr*.dll" };
            List<string> files = new List<string>();

            foreach (string filter in filters)
                files.AddRange(Directory.GetFiles(Environment.SystemDirectory, filter));

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(file);

                if (new Version(fileVersion.ProductVersion).CompareTo(targetVersion) >= 0)
                    return true;
            }

            return false;
        }


        public static Version GetNETFrameworkVersion()
        {
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    int releaseKey = (int)ndpKey.GetValue("Release");

                    if (releaseKey >= 461308)
                    {
                        return new Version("4.7.1.0");
                    }
                    if (releaseKey >= 460798)
                    {
                        return new Version("4.7.0.0");

                    }
                    if (releaseKey >= 394802)
                    {
                        return new Version("4.6.2.0");
                    }
                    if (releaseKey >= 394254)
                    {
                        return new Version("4.6.1.0");
                    }
                    if (releaseKey >= 393295)
                    {
                        return new Version("4.6.0.0");
                    }
                    if (releaseKey >= 379893)
                    {
                        return new Version("4.5.2.0");
                    }
                    if (releaseKey >= 378675)
                    {
                        return new Version("4.5.1.0");
                    }
                    if (releaseKey >= 378389)
                    {
                        return new Version("4.5.0.0");
                    }
                    else
                    {
                        return new Version("4.0.0.0");
                    }
                }
                else
                {
                    return new Version("0.0.0.0");
                }
            }
        }

    }
}
