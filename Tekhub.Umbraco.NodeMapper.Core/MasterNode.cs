using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekhub.Extensions;

namespace Tekhub.Umbraco.NodeMapper.Core
{
    public class MasterNode
    {
        private string _pageTitle;
        public MasterNode() { }

        public MasterNode(MasterNode toCopy)
        {
            Id = toCopy.Id;
            Name = toCopy.Name;
            Url = toCopy.Url;
            PageTitle = toCopy.PageTitle;

            MetaTags = toCopy.MetaTags != null ? 
                            new NodeMetaTags(toCopy.MetaTags) : 
                            new NodeMetaTags();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public string PageTitle
        {
            get { return GetPageTitle(); }
            set { _pageTitle = value; }
        }

        public DateTime PublishedDate { get; set; }

        public NodeMetaTags MetaTags { get; set; }

        public string UrlLastSegment
        {
            get { return Url.GetLastUrlSegment(); }
        }

        public virtual void SetProperties(Dictionary<string, object> propertyValueMappings)
        {
            PageTitle = Convert.ToString(propertyValueMappings["pageTitle"]);

            if (MetaTags == null) return;

            MetaTags.SetProperties(propertyValueMappings);

            if (!MetaTags.HasTitle)
            {
                MetaTags.Title = PageTitle;
            }
        }

        private string GetPageTitle()
        {
            return string.IsNullOrEmpty(_pageTitle) ? Name : _pageTitle;
        }
    }
}
