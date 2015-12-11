using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekhub.Umbraco.NodeMapper
{
    public class MasterNode
    {
        public MasterNode() { }

        public MasterNode(MasterNode toCopy)
        {
            Id = toCopy.Id;
            Name = toCopy.Name;
            Url = toCopy.Url;
            PageTitle = toCopy.PageTitle;
            DescriptionMeta = toCopy.DescriptionMeta;
            TitleMeta = toCopy.TitleMeta;
            KeyWordsMeta = toCopy.KeyWordsMeta;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public string PageTitle { get; set; }
        public string DescriptionMeta { get; set; }
        public string TitleMeta { get; set; }
        public string KeyWordsMeta { get; set; }
        public DateTime PublishedDate { get; set; }

        public string UrlLastSegment
        {
            get { return Url.GetLastUrlSegment(); }
        }

        public virtual void SetProperties(Dictionary<string, object> propertyValueMappings)
        {
            PageTitle = Convert.ToString(propertyValueMappings["pageTitle"]);
            DescriptionMeta = Convert.ToString(propertyValueMappings["descriptionMeta"]);
            TitleMeta = Convert.ToString(propertyValueMappings["titleMeta"]);
            KeyWordsMeta = Convert.ToString(propertyValueMappings["keyWordsMeta"]);
        }
    }
}
