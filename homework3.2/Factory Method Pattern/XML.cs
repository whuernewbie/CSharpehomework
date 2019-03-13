using System;
using System.Reflection;
using System.Xml;

public class XML
{
    public static object Getbean()
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("XMLFile1.xml");

            //  XmlNodeList nl = doc.SelectNodes("chartType");
            XmlNode classNode = doc.SelectSingleNode("config");
            String str = (classNode.SelectSingleNode("classname")).InnerText;
            //class C=class.private forname(str);
            Assembly C = Assembly.LoadFile("..//");
            object obj = C.CreateInstance(str);
            return obj;
         }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}
