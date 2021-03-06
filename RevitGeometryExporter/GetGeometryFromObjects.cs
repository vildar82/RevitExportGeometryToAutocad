﻿using System;
using System.Xml.Linq;
using Autodesk.Revit.DB;

namespace RevitGeometryExporter
{
    internal static class GetGeometryFromObjects
    {
        internal static XElement GetXElementFromLine(Line line)
        {
            try
            {
                XElement lineXElement = new XElement("Line");
                XElement startPointXElement = new XElement("StartPoint");
                startPointXElement.SetAttributeValue("X", line.GetEndPoint(0).X);
                startPointXElement.SetAttributeValue("Y", line.GetEndPoint(0).Y);
                startPointXElement.SetAttributeValue("Z", line.GetEndPoint(0).Z);
                lineXElement.Add(startPointXElement);
                XElement endPointXElement = new XElement("EndPoint");
                endPointXElement.SetAttributeValue("X", line.GetEndPoint(1).X);
                endPointXElement.SetAttributeValue("Y", line.GetEndPoint(1).Y);
                endPointXElement.SetAttributeValue("Z", line.GetEndPoint(1).Z);
                lineXElement.Add(endPointXElement);
                return lineXElement;
            }
            catch (Exception)
            {
                return null;
            }
        }
        internal static XElement GetXElementFromArc(Arc arc)
        {
            try
            {
                XElement arcXElement = new XElement("Arc");
                XElement element = new XElement("StartPoint");
                element.SetAttributeValue("X", arc.GetEndPoint(0).X);
                element.SetAttributeValue("Y", arc.GetEndPoint(0).Y);
                element.SetAttributeValue("Z", arc.GetEndPoint(0).Z);
                arcXElement.Add(element);
                element = new XElement("EndPoint");
                element.SetAttributeValue("X", arc.GetEndPoint(1).X);
                element.SetAttributeValue("Y", arc.GetEndPoint(1).Y);
                element.SetAttributeValue("Z", arc.GetEndPoint(1).Z);
                arcXElement.Add(element);
                element = new XElement("PointOnArc");
                element.SetAttributeValue("X", arc.Tessellate()[1].X);
                element.SetAttributeValue("Y", arc.Tessellate()[1].Y);
                element.SetAttributeValue("Z", arc.Tessellate()[1].Z);
                arcXElement.Add(element);
                return arcXElement;
            }
            catch (Exception)
            {
                return null;
            }
        }
        internal static XElement GetXElementFromPoint(XYZ point)
        {
            XElement pointXElement = new XElement("Point");
            pointXElement.SetAttributeValue("X", point.X);
            pointXElement.SetAttributeValue("Y", point.Y);
            pointXElement.SetAttributeValue("Z", point.Z);
            return pointXElement;
        }
    }
}
