using System;

//使用事件机制，模拟实现一个闹钟功能。
//闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。
//在闹钟走时时或者响铃时，在控制台显示提示信息。

namespace Week4
{
    public class Program
    {
        static void Main()
        {

            Publisher publisher = new Publisher();

            Subscriber subscriber = new Subscriber();

            publisher.Tiktok += subscriber.OnTiktok;
            publisher.Alarm += subscriber.OnAlarm;
            for (;;)
            {
                for (int i = 0; i<5; i ++)
                {
                    publisher.RaiseTiktok();
                    Thread.Sleep(500);
                }
                publisher.RaiseAlarm();
                Thread.Sleep(500);
            }
            return;
        }
    }
}