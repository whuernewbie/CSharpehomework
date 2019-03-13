using System;
using System.Xml;

public class XMLUtil
{
	public static String getChartType()
	{
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile1.xml");

            //  XmlNodeList nl = doc.SelectNodes("chartType");
            XmlNode classNode = doc.SelectSingleNode("config");
            String str = (classNode.SelectSingleNode("chartType")).InnerText;
            return str;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
	}
}
