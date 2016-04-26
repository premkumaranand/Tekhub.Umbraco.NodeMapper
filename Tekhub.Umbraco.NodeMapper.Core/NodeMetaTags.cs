using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekhub.Umbraco.NodeMapper.Core
{
    public class NodeMetaTags
    {
        public NodeMetaTags() { }

        public NodeMetaTags(NodeMetaTags toCopy)
        {
            Title = toCopy.Title;
            Description = toCopy.Description;
            Keywords = toCopy.Keywords;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }

        public bool HasTitle
        {
            get { return !string.IsNullOrEmpty(Title); }
        }

        public void SetProperties(Dictionary<string, object> propertyValueMappings)
        {
            if (propertyValueMappings.ContainsKey("titleMeta"))
            {
                Title = Convert.ToString(propertyValueMappings["titleMeta"]);
            }

            if (propertyValueMappings.ContainsKey("descriptionMeta"))
            {
                Description = Convert.ToString(propertyValueMappings["descriptionMeta"]);
            }

            if (propertyValueMappings.ContainsKey("keywordsMeta"))
            {
                Keywords = Convert.ToString(propertyValueMappings["keywordsMeta"]);
            }
        }
    }
}
