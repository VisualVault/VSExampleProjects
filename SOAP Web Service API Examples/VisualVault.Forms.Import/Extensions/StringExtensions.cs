using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VisualVault.Forms.Import.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the string not exceeding more than the specified length 
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string Shorten(this string s, int length)
        {
            if (String.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            if (s.Length > length)
            {
                return s.Substring(0, length);
            }

            return s;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ReverseString(this string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        
        /// <summary>
        /// If string value is a date returns true and assigns value to dateTime out parameter.
        /// If string value is not a date returns false and assigns DateTime.MinValue to dateTime out parameter.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsDate(this string s, out DateTime dateTime)
        {
            dateTime = DateTime.MinValue;

            if (s == null)
            {
                return false;
            }

            if (s.Length <= 0)
            {
                return false;
            }

            if (s.IndexOf(@"/") <= 0)
            {
                return false;
            }

            return DateTime.TryParse(s, out dateTime);
        }
        
        ///<summary>
        /// Tests to see if the string is Null or Empty
        ///</summary>
        ///<param name="input"></param>
        ///<returns></returns>
        public static bool IsNullOrEmpty(this string input)
        {
            return (String.IsNullOrEmpty(input));
        }

        /// <summary>
        /// Returns true if the string contains a valid email address format
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValidEmailAddress(this string s)
        {
            var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        /// <summary>
        /// Replaces the pattern in the string, case insensitive.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="replacement">The replacement.</param>
        /// <returns></returns>
        public static string ReplaceEx(this string original, string pattern, string replacement)
        {
            int position0, position1;
            int count = position0 = 0;
            string upperString = original.ToUpper();
            string upperPattern = pattern.ToUpper();
            int inc = (original.Length / pattern.Length) * (replacement.Length - pattern.Length);
            var chars = new char[original.Length + Math.Max(0, inc)];
            while ((position1 = upperString.IndexOf(upperPattern, position0)) != -1)
            {
                for (int i = position0; i < position1; ++i)
                {
                    chars[count++] = original[i];
                }
                for (int i = 0; i < replacement.Length; ++i)
                {
                    chars[count++] = replacement[i];
                }
                position0 = position1 + pattern.Length;
            }
            if (position0 == 0)
            {
                return original;
            }
            for (int i = position0; i < original.Length; ++i)
            {
                chars[count++] = original[i];
            }
            return new string(chars, 0, count);
        }

        /// <summary>
        /// Returns true if the string contains a Guid value
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsGuid(this string s)
        {
            bool result = false;

            if (!String.IsNullOrEmpty(s) && s.Length == 36 && !s.Equals(Guid.Empty.ToString()))
            {
                var isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);

                if (isGuid.IsMatch(s))
                {
                    result = true;
                }

            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="allowEmptyGuid"></param>
        /// <returns></returns>
        public static bool IsGuid(this string s, bool allowEmptyGuid)
        {
            bool result = false;

            if (!String.IsNullOrEmpty(s) && s.Length == 36)
            {
                if (!s.Equals(Guid.Empty.ToString()))
                {
                    var isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);

                    if (isGuid.IsMatch(s))
                    {
                        result = true;
                    }
                }
                else
                {
                    if (allowEmptyGuid)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsAlphaNumeric(this string s)
        {
            bool result = true;
            CharEnumerator charEnumerator = s.GetEnumerator();

            while (charEnumerator.MoveNext())
            {
                if (char.IsLetterOrDigit(charEnumerator.Current) == false)
                {
                    if (charEnumerator.Current != '_' && charEnumerator.Current != '-' && charEnumerator.Current != ' ')
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string deHack(this string s)
        {
            return deHack(s, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="forTextBoxDisplay"></param>
        /// <returns></returns>
        public static string deHack(this string s, bool forTextBoxDisplay)
        {
            string strReplacement = string.Empty;
            //Dim oRegEx As New System.Text.RegularExpressions.Regex("(script)|(<)|(>)|(%3c)|(%3e)|(SELECT) |(UPDATE) |(INSERT) |(DELETE)|(GRANT) |(REVOKE)|(UNION)|(&lt;)|(&gt;)")
            //s = oRegEx.Replace(s, String.Empty)

            if (s.ToLower().Contains("--"))
            {
                s = strReplacement;
            }
            if (s.ToLower().Contains("xp_cmdshell"))
            {
                s = strReplacement;
            }
            if (s.ToLower().Contains("\' or"))
            {
                s = strReplacement;
            }
            if (s.ToLower().Contains("@@servername"))
            {
                s = strReplacement;
            }
            if (s.ToLower().Contains("sysobjects"))
            {
                s = strReplacement;
            }
            if (s.ToLower().Contains("1=1"))
            {
                s = strReplacement;
            }
            if (s.ToLower().Contains("1 = 1"))
            {
                s = strReplacement;
            }
            if (s.ToLower().Contains("sp_executesql"))
            {
                s = strReplacement;
            }
            if (s.ToLower().Contains("exec "))
            {
                s = strReplacement;
            }
            if (forTextBoxDisplay == false)
            {
                s = s.Replace("\'", "\'\'");
            }

            return s;
        }

        /// <summary>
        /// Returns string cast to integer or 0 if cast fails
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this string s)
        {
            int value;
            int.TryParse(s, out value);
            return value;
        }

        /// <summary>
        /// Returns a list of token items found in the string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="startToken"></param>
        /// <param name="endToken"></param>
        /// <returns></returns>
        public static List<String> GetTokens(this string s, string startToken, string endToken)
        {
            var tokens = new List<String>();

            var output = new System.Text.StringBuilder();

            var start = 0;
            var end = s.Length;
            var count = end - start;

            int tokenLength = startToken.Length;


            while (start <= end)
            {
                int index = s.IndexOf(startToken, start, count);

                if (index == -1)
                {
                    //No more tokens, add rest of message
                    output.Append(s, start, count);
                    break;
                }

                //Add to message text form either begining or from last token
                output.Append(s, start, index - start);

                //Advance placeholders
                start = index + tokenLength;


                count = s.Length - start;

                //Look for end of token
                index = s.IndexOf(endToken, start, count);

                if (index == -1)
                {
                    //Didn't find end of token, add rest of message
                    output.Append(s, start, count);
                    break;
                }

                //Grab Token
                var token = s.Substring(start, (index - start));

                //save token to list
                tokens.Add(token);

                output.Append(token);

                //Advance placeholders
                start = index + 1;
                count = s.Length - start;
            }

            return tokens;
        }
    }
}
