```C#
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
        

        public static string GetGamePath(string key = "SOFTWARE\\WOW6432Node\\Rockstar Games\\Grand Theft Auto V")
        {
            object value = null;

            RegistryKey reg = Registry.LocalMachine.OpenSubKey(key, false);
            if (reg != null)
                value = reg.GetValue("InstallFolder");

            if (value != null)
                return value.ToString();
            else
                return null;
        }

        public static string GetWindowsVersion()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            return name != null ? name.ToString() : "Unknown windows version";
        }

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



        

        public static string GetNETFrameworkVersions()
        {
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    return CheckFor45DotVersion((int)ndpKey.GetValue("Release"));
                }
                else
                {
                    return "";
                }
            }
        }

        // Checking the version using >= will enable forward compatibility, 
        // however you should always compile your code on newer versions of
        // the framework to ensure your app works the same.
        private static string CheckFor45DotVersion(int releaseKey)
        {
            if (releaseKey >= 461308)
            {
                return "4.7.1 or later";
            }
            if (releaseKey >= 460798)
            {
                return "4.7 or later";
            }
            if (releaseKey >= 394802)
            {
                return "4.6.2 or later";
            }
            if (releaseKey >= 394254)
            {
                return "4.6.1 or later";
            }
            if (releaseKey >= 393295)
            {
                return "4.6 or later";
            }
            if (releaseKey >= 379893)
            {
                return "4.5.2 or later";
            }
            if (releaseKey >= 378675)
            {
                return "4.5.1 or later";
            }
            if (releaseKey >= 378389)
            {
                return "4.5 or later";
            }

            // This line should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return "No 4.5 or later version detected";
        }
```
