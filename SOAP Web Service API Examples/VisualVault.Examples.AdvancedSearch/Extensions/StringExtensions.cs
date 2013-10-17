using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace VisualVault.Examples.AdvancedSearch.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a String array into a single value containing a delimted list
        /// </summary>
        /// <param name="stringArray"></param>
        /// <param name="separator"></param>
        /// <param name="replaceValueInEachItem"></param>
        /// <returns></returns>
        public static string ToString(this string[] stringArray, char separator, string replaceValueInEachItem)
        {
            int count = stringArray.Length;

            string[] stringArray2 = new string[count];

            if (replaceValueInEachItem.Length > 0)
            {

                for (int i = 0; i < count; i++)
                {
                    stringArray2[i] = stringArray[i].Split(separator)[0].ToLower().Replace(replaceValueInEachItem, "");
                }
            }
            else
            {
                stringArray2 = stringArray;
            }

            return String.Join(separator.ToString(CultureInfo.InvariantCulture), stringArray2);
        }

        /// <summary>
        /// Returns true if the string contains a Guid value
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsGuid(this string s)
        {
            bool result = false;

            if (!String.IsNullOrEmpty(s))
            {
                if ((s != Guid.Empty.ToString()))
                {
                    var isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);

                    if (isGuid.IsMatch(s))
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// If string is a valid Guid return String converted to Guid
        /// else returns an empty Guid (all zeros)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string s)
        {
            if (s.IsGuid())
            {
                return new Guid(s);
            }

            return new Guid(Guid.Empty.ToString());
        }

        /// <summary>
        /// Returns true if string evaluates to True
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ToBool(this string s)
        {
            bool result;

            try
            {
                result = bool.Parse(s);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}