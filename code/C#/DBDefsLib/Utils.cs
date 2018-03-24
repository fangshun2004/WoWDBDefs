﻿using System;
using System.Collections.Generic;
using System.Text;
using static DBDefsLib.Structs;

namespace DBDefsLib
{
    public class Utils
    {
        [Obsolete("Use of the Utils.ParseBuild() method is deprecated, it will be removed in an upcoming version. Use Build(build) instead.")]
        public static Build ParseBuild(string build)
        {
            return new Build(build);
        }

        [Obsolete("Use of the Utils.BuildToString() method is deprecated, it will be removed in an upcoming version. Use Build.ToString() instead.")]
        public static string BuildToString(Build build)
        {
            return build.ToString();
        }

        public static string NormalizeColumn(string col, bool fixFirst = false)
        {
            var thingsToUpperCase = new List<string> { "ID", "WMO" };

            // ugh
            var filteredOut = new List<string> { "mid" };

            var cleaned = col;

            foreach(var thingToUpperCase in thingsToUpperCase)
            {
                if (filteredOut.Contains(col))
                {
                    continue;
                }

                if (cleaned.StartsWith(thingToUpperCase, StringComparison.CurrentCultureIgnoreCase))
                {
                    cleaned = thingToUpperCase + cleaned.Substring(thingToUpperCase.Length);
                }

                if (cleaned.EndsWith(thingToUpperCase, StringComparison.CurrentCultureIgnoreCase))
                {
                    cleaned = cleaned.Substring(0, cleaned.Length - thingToUpperCase.Length) + thingToUpperCase;
                }
            }

            if (fixFirst)
            {
                var arr = cleaned.ToCharArray();
                arr[0] = char.ToUpper(arr[0]);
                cleaned = new string(arr);
            }

            return cleaned;
        }
    }
}

