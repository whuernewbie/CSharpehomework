using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clock
{
    class Clock
    {
        //定义委托
        public delegate void getClock();
        //定义事件
        public event getClock ding;
        //引发事件的方法
        public void Begin(String timeSet)
        {
            String nowTime;
            //System.DateTime dateTime = new System.DateTime();
            while (true)//判断当前时间是否达到设置的时间
            {
                nowTime = System.DateTime.Now.ToString();
                if (string.Equals(nowTime, timeSet))
                {
                    ding();
                    break;
                }
            }
        }

        public String SetClock()
        {
            String timeSet;
            int year;
            int m;
            int d;
            int h;
            int mi;
            int se;
            Console.WriteLine("请设置闹钟时间的日期：");
            Console.WriteLine("输入年份：");
            while (!int.TryParse(Console.ReadLine(), out year)) Console.WriteLine("error,again!"); ;
            Console.WriteLine("输入月份：");
            while (!(int.TryParse(Console.ReadLine(), out m)&&m>0&&m<=12)) Console.WriteLine("无效输入，请重新输入！"); ;
            Console.WriteLine("输入日期：");
            while (!(int.TryParse(Console.ReadLine(), out d) && d <= 31 && d > 0)) Console.WriteLine("无效输入，请重新输入！"); 
            Console.WriteLine("请继续设置闹钟具体时间（如20:02:08)");
            Console.WriteLine("输入小时：");
            while (!(int.TryParse(Console.ReadLine(), out h) && h <= 24 && h >=0)) Console.WriteLine("无效输入，请重新输入！");
            Console.WriteLine("输入分钟：");
            while (!(int.TryParse(Console.ReadLine(), out mi) && mi <= 60 && mi >= 0)) Console.WriteLine("无效输入，请重新输入！");
            Console.WriteLine("输入秒数：");
            while (!(int.TryParse(Console.ReadLine(), out se) && se <= 60 && se >= 0)) Console.WriteLine("无效输入，请重新输入！");
            timeSet = year.ToString() + "/" + m.ToString() + "/" + d.ToString() + " " + h.ToString() + ":" + mi.ToString() + ":" + se.ToString();
            Console.WriteLine(timeSet);
            return timeSet;
        }
    }

    class Dingding
    {
        public void ding()
        {
            Console.WriteLine("时间到！！！");
        }
    }






}
