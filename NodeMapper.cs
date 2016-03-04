using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archetype.Models;
using Tekhub.Umbraco.Extensions;
using Tekhub.Umbraco.NodeMapper.Core;
using Umbraco.Core;
using Umbraco.Core.Models;

namespace Tekhub.Umbraco.NodeMapper
{
    public class NodeMapper
    {
        public static T Map<T>(IPublishedContent nodeContent) where T : MasterNode, new()
        {
            var propertiesMapping = new Dictionary<string, object>();
            nodeContent.Properties.ForEach(p =>
            {
                if (p.Value != null)
                    propertiesMapping[p.PropertyTypeAlias] = p.Value.GetType() == typeof (ArchetypeModel)
                                                                    ? MapArchetypeModel(p)
                                                                    : p.Value;
                else
                {
                    propertiesMapping[p.PropertyTypeAlias] = null;
                }
            });

            var mappedNode = new T();

            mappedNode.SetProperties(propertiesMapping);

            mappedNode.Name = nodeContent.Name;
            mappedNode.Url = nodeContent.Url;
            mappedNode.Id = nodeContent.Id;
            mappedNode.PublishedDate = nodeContent.CreateDate;

            return mappedNode;
        }

        private static List<Dictionary<string, object>> MapArchetypeModel(IPublishedProperty p)
        {
            var archeTypeModel = p.Value as ArchetypeModel;
            return MapArchetypeModel(archeTypeModel);
        }

        public static List<Dictionary<string, object>> MapArchetypeModel(ArchetypeModel archeTypeModel)
        {
            var mappedProps = new List<Dictionary<string, object>>();

            foreach (var fieldSetIter in archeTypeModel.Fieldsets)
            {
                var mappedPropIter = new Dictionary<string, object>();
                foreach (var propIter in fieldSetIter.Properties)
                {
                    mappedPropIter[propIter.Alias] = propIter.Value;
                }

                mappedProps.Add(mappedPropIter);
            }
            return mappedProps;
        }

        public static T Map<T>(IContent nodeContent) where T : MasterNode, new()
        {
            var propertiesMapping = new Dictionary<string, object>();
            nodeContent.Properties.ForEach(p =>
            {
                propertiesMapping[p.Alias] = p.Value;
            });

            var mappedNode = new T();

            mappedNode.SetProperties(propertiesMapping);

            mappedNode.Name = nodeContent.Name;
            mappedNode.Url = nodeContent.RelativeUrl();
            mappedNode.Id = nodeContent.Id;

            return mappedNode;
        }
    }
}
