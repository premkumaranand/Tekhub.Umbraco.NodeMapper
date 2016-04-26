using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekhub.Umbraco.NodeMapper.Core;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace Tekhub.Umbraco.NodeMapper
{
    public class MasterRenderModel<T>:RenderModel where T:MasterNode, new()
    {
        public T NodeContent { get; set; }

        public MasterRenderModel(IPublishedContent content) : base(content)
        {
            NodeContent = NodeMapper.Map<T>(content);
        }

        public MasterRenderModel(T nodeContent, IPublishedContent content)
            : base(content)
        {
            NodeContent = nodeContent;
        }

        public static implicit operator MasterRenderModel<MasterNode>(MasterRenderModel<T> toCopy)
        {
            return new MasterRenderModel<MasterNode>(toCopy.Content)
            {
                NodeContent = toCopy.NodeContent
            };
        }
    }
}
