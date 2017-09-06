using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FxSocket;
using FxSocket.FileSystem;
using FxSocket.Net;
using Microsoft.Win32;

namespace FxSocketSamples
{
    static class Common
    {
        /// <summary>
        /// format datetime to readable form in the panels
        /// </summary>
        /// <param name="dt">datetime</param>
        /// <returns>formatted string</returns>
        public static string FormatTime(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm");
        }

        public static string FormatTime(DateTime? dt)
        {
            return dt != null ? dt.Value.ToString("yyyy-MM-dd HH:mm") : null;
        }

        public static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        #region Save and Get Registry Values

        public static void SetKey(string keyName, object value)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\FxSocket\\" + Assembly.GetExecutingAssembly().GetName().Name);
                key.SetValue(keyName, value);
            }
            catch
            {
                return;
            }
        }

        public static object GetKey(string keyName, object defaultValue)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\FxSocket\\" + Assembly.GetExecutingAssembly().GetName().Name);
                return key.GetValue(keyName, defaultValue);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static object GetKey(string keyName)
        {
            return GetKey(keyName, (object)null);
        }

        public static int GetKey(string keyName, int defaultValue)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\FxSocket\\" + Assembly.GetExecutingAssembly().GetName().Name);
                return int.Parse(key.GetValue(keyName, defaultValue).ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static long GetKey(string keyName, long defaultValue)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\FxSocket\\" + Assembly.GetExecutingAssembly().GetName().Name);
                return long.Parse(key.GetValue(keyName, defaultValue).ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool GetKey(string keyName, bool defaultValue)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\FxSocket\\" + Assembly.GetExecutingAssembly().GetName().Name);
                return key.GetValue(keyName, defaultValue).ToString() == "True";
            }
            catch
            {
                return defaultValue;
            }
        }

        #endregion
    }

    public enum ComparisonMethod
    {
        Name,
        Ext,
        Size,
        Date,
        Permissions
    }

    public class ListViewColumnSorter : IComparer
    {
        private bool _ascending;
        private ComparisonMethod _comparisonMethod;

        public ListViewColumnSorter()
        {
            _ascending = true;
        }

        public bool Ascending
        {
            get { return _ascending; }
            set { _ascending = value; }
        }

        public ComparisonMethod ComparisonMethod
        {
            get { return _comparisonMethod; }
            set { _comparisonMethod = value; }
        }

        int CompareTime(DateTime x, DateTime y)
        {
            if (x == y)
                return 0;
            if (_ascending)
                return x > y ? 1 : -1;

            return x < y ? 1 : -1;
        }

        int IComparer.Compare(object x, object y)
        {
            ListViewItem listViewX = (ListViewItem)x;
            ListViewItem listViewY = (ListViewItem)y;

            ListItemInfo itemX = (ListItemInfo)listViewX.Tag;
            ListItemInfo itemY = (ListItemInfo)listViewY.Tag;

            if (itemX.IsDirectory && !itemY.IsDirectory)
                return -1;

            if (!itemX.IsDirectory && itemY.IsDirectory)
                return 1;

            if (itemX.IsUpper && !itemY.IsUpper)
                return -1;

            if (!itemX.IsUpper && itemY.IsUpper)
                return 1;

            switch (_comparisonMethod)
            {
                case ComparisonMethod.Name:
                    string xname = Path.GetFileName(itemX.FullPath);
                    string yname = Path.GetFileName(itemY.FullPath);
                    return _ascending ? string.CompareOrdinal(xname, yname) : string.CompareOrdinal(yname, xname);

                case ComparisonMethod.Ext:
                    string xext = Path.GetExtension(itemX.FullPath);
                    string yext = Path.GetExtension(itemY.FullPath);
                    return _ascending ? string.CompareOrdinal(xext, yext) : string.CompareOrdinal(yext, xext);

                case ComparisonMethod.Size:
                    return _ascending ? (int)(itemX.Size - itemY.Size) : (int)(itemY.Size - itemX.Size);

                case ComparisonMethod.Date:
                    return _ascending ? CompareTime(itemX.Time, itemY.Time) : CompareTime(itemY.Time, itemX.Time);
            }

            return 0;
        }
    }
}
