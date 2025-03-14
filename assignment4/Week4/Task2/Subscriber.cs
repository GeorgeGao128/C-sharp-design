namespace Week4;

public class Subscriber
{
    public void OnTiktok(object sender, EventArgs e)
    {
        Console.WriteLine("Tiktok...");
    }
    public void OnAlarm(object sender, EventArgs e)
    {
        Console.WriteLine("Alarm!");
    }
}