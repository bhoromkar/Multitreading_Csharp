using System;
using System.Threading;
public class MyThread
{
    public static void Thread1()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }
    }
    public void Thread2()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(2000);
        }
    }
}
public class ThreadExample
{
    public static void Main()
    {
        Console.WriteLine("start main");
        MyThread myThread = new MyThread();
        //Thread t1 = new Thread(new ThreadStart(MyThread.Thread1));
        //Thread t2 = new Thread(new ThreadStart(MyThread.Thread1));
        //t1.Start();
        //t2.Start();

        Thread t1 = new Thread(new ThreadStart(myThread.Thread2));
        Thread t2 = new Thread(new ThreadStart(myThread.Thread2));
        t1.Start();
        t2.Start();
        try
        {
            t1.Abort();
            t2.Abort();
        }
        catch (ThreadAbortException tae)
        {
            Console.WriteLine(tae.ToString());
        }
        Console.WriteLine("end main");

    }
}

