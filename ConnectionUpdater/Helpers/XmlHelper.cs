using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConnectionUpdater.Helpers
{
    public static class XmlHelper
    {
        public static XmlNode RemoveNodeIfExists(this XmlNode node, string name)
        {
            var childNote = node.SelectSingleNode(name);
            if (childNote != null)
                node.RemoveChild(childNote);

            return node;
        }
    }
}
