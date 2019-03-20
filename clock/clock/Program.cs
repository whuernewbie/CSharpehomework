using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clock
{
    class Program
    {
        static void Main(string[] args)
        {
           string  nowTime = System.DateTime.Now.ToString();
            Console.WriteLine(nowTime);
            Dingding dingding = new Dingding();//实列化事件发布者
            Clock clock = new Clock();//实例化事件订阅者
            clock.ding += new Clock.getClock(dingding.ding);//订阅事件
            String timeSet=clock.SetClock();//设置闹钟事件
            clock.Begin(timeSet);//引发事件
            Console.ReadKey();
        }
    }
}
