namespace Week4;

public class Publisher
{
    public event EventHandler<EventArgs> Tiktok;
    public event EventHandler<EventArgs> Alarm;
    public void RaiseTiktok()
    {
        if (Tiktok != null)
        {
            Tiktok(this, EventArgs.Empty);
        }
    }
    public void RaiseAlarm()
    {
        if (Alarm != null)
        {
            Alarm(this, EventArgs.Empty);
        }
    }
}