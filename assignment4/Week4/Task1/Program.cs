using Week4;

public class Program
{
    static void Main()
    {
        GenericList<int> _list = new GenericList<int>();
        _list.Add(2);
        _list.Add(1);
        _list.Add(4);
        _list.Add(3);
        _list.Add(5);

        int totalSum = 0;
        int max=0;
        int min=5;

        Console.WriteLine("链表内元素为：");
        action<int> action1 = new action<int>();
        //调用printNumber
        _list.ForEach(action1.printNumber);
        
        //直接通过匿名函数实现功能
        _list.ForEach(x => 
        {
            totalSum += x; 
        });
        _list.ForEach(x => 
        {
            max=max>x?max:x; 
        });
        _list.ForEach(x => 
        {
            min=min>x?x:min; 
        });
        Console.WriteLine($"元素总和为{totalSum}，最大值为{max}，最小值为{min}");
    }
}