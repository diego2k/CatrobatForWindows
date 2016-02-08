﻿using System.Xml.Linq;
using Catrobat.IDE.Core.Utilities.Helpers;
using Catrobat_Player.NativeComponent;

namespace Catrobat.IDE.Core.Xml.XmlObjects
{
    public partial class XmlLook : XmlObjectNode, ILook
    {
        public string FileName { get; set; }

        public string Name { get; set; }

        public XmlLook() { }

        public XmlLook(string name)
        {
            Name = name;
            FileName = FileNameGenerationHelper.Generate() + Name;
        }

        internal XmlLook(XElement xElement)
        {
            LoadFromXml(xElement);
        }

        internal override void LoadFromXml(XElement xRoot)
        {
            FileName = xRoot.Element("fileName").Value;
            Name = xRoot.Element("name").Value;
        }

        internal override XElement CreateXml()
        {
            var xRoot = new XElement("look");

            xRoot.Add(new XElement("fileName", FileName));

            xRoot.Add(new XElement("name", Name));

            return xRoot;
        }
    }
}