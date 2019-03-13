using System;

class Client
{
    public static void Main(string[] args)
    {
        Chart chart;
        string type = XMLUtil.getChartType();
        if(type!=null)
        {
            chart = ChartFactory.GetChart(type);
            chart.Display();
        }
        else
        {
            Console.WriteLine( "读取文件错误");
        }
    }

}
