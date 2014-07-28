﻿using System.Xml.Linq;
using Catrobat.Data.Utilities.Helpers;

namespace Catrobat.Data.Xml.XmlObjects.Bricks.ControlFlow
{
    public class XmlIfLogicBeginBrickReference : XmlObject
    {
        private string _reference;

        public XmlIfLogicBeginBrick IfLogicBeginBrick { get; set; }

        public XmlIfLogicBeginBrickReference()
        {
        }

        public XmlIfLogicBeginBrickReference(XElement xElement)
        {
            LoadFromXml(xElement);
        }

        public override void LoadFromXml(XElement xRoot)
        {
            _reference = xRoot.Attribute("reference").Value;
        }

        public override XElement CreateXml()
        {
            var xRoot = new XElement("ifBeginBrick");

            xRoot.Add(new XAttribute("reference", ReferenceHelper.GetReferenceString(this)));

            return xRoot;
        }

        public override void LoadReference()
        {
            if(IfLogicBeginBrick == null)
                IfLogicBeginBrick = ReferenceHelper.GetReferenceObject(this, _reference) as XmlIfLogicBeginBrick;
            if (string.IsNullOrEmpty(_reference))
                _reference = ReferenceHelper.GetReferenceString(this);
        }
    }
}