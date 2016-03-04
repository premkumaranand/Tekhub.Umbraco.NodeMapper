using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekhub.Umbraco.NodeMapper.Core
{
    public static class NodePropertyExtensions
    {
        public static string GetStringPropertyValue(this Dictionary<string, object> theDictionary, string key, string defaultValue = "")
        {
            return !theDictionary.ContainsKey(key) ? defaultValue : Convert.ToString(theDictionary[key]);
        }

        public static int GetIdPropertyValue(this Dictionary<string, object> theDictionary, string key, int defaultValue = -1)
        {
            return !theDictionary.ContainsKey(key) ? defaultValue : Convert.ToInt32(theDictionary[key]);
        }

        public static List<int> GetIdListPropertyValue(this Dictionary<string, object> theDictionary, string key)
        {
            return !theDictionary.ContainsKey(key)
                ? null
                : Convert.ToString(theDictionary[key]).Split(',').Select(id => Convert.ToInt32(id)).ToList();
        }
    }
}
