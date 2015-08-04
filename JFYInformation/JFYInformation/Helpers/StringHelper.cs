using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JFYInformation.Helpers
{
    public class StringHelper
    {
        public static string GetMidTxt(string src, string l, string r)
        {
            try
            {
                var begin = src.IndexOf(l) + l.Length;
                var end = src.IndexOf(r);
                return src.Substring(begin, end - begin);
            }
            catch
            {
                return "";
            }
        }

        public static List<string> RegMatchUrl(string html)
        {
            List<string> links = new List<string>();
            MatchCollection matches = Regex.Matches(html, "href\\s*=\\s*(?:[\"'](?<1>[^\"']*)[\"']|(?<1>\\S+))", RegexOptions.IgnoreCase);
            for (var i = 0; i < matches.Count; i++)
            {
                string s = matches[i].Groups[1].Value;
                links.Add(s);
            }
            return links;
        }
    }
}
