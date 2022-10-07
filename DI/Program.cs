using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumCalculation
{

    #region Constructor Injection

    public interface IAdd
    {
        int Add(int a, int b);
        int Mul(int a, int b);
    }

    class calculation : IAdd
    {
        public calculation()
        {}

        public calculation(int val1, int val2)
        {}

        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Mul(int a, int b)
        {
            return a * b;
        }
    }

    // constructor injection
    public class constructorinjection
    {
        private IAdd _IAdd;

        public constructorinjection()
        {
            _IAdd=new calculation();
        }
        public constructorinjection(IAdd c1)
        {
            this._IAdd = c1;
        }
        public int Add(int a, int b)
        {
            return _IAdd.Add(a, b);
        }
    }

    #endregion

    public class SampleMethodCons
    {
        public static void HelloWorld()
        {
            Console.WriteLine("Hello World");
        }
        public static void Main()
        {
            var services = new ServiceCollection();
            services.AddTransient<IAdd, calculation>();
            IServiceProvider SP = services.BuildServiceProvider();
            var obj = SP.GetService<IAdd>();
            Console.WriteLine(obj?.Add(200, 55));
            
            //Constructor Injection Execution
            //constructorinjection ci = new constructorinjection();
            //Console.WriteLine(ci.Add(145, 55));
            //Console.ReadKey();

            ////Property Injection Execution
            //EventLog el = new EventLog();
            //PropertyInjection p = new PropertyInjection();
            //p.Log(el, "Message written by vol to check property injection");
            ////Console.ReadKey();

            ////Method Injection Execution
            //Client c = new Client();
            //c.run(new ServiceManager());
            //Console.ReadKey();
        }
    }
}


#region Property Injection Sample
public interface ILogMessage
{
    void StoreMessage(string message);
}
class PropertyInjection
{
    ILogMessage? _msg;
    public void Log(ILogMessage im, string message)
    {
        this._msg = im;
        _msg.StoreMessage(message);
    }
}

class EventLog : ILogMessage
{
    public void StoreMessage(string message)
    {
        Console.WriteLine(message);
    }
}

#endregion 

#region Method Injection Code - pass the dependency in the method only
public interface IWatch
{
    void StartFileWatcher();
}
public class ServiceManager : IWatch
{
    public void StartFileWatcher()
    {
        Console.WriteLine("Start File Watcher here......");
    }
}

public class Client
{
    private IWatch? _watch;
    public void run(IWatch w)
    {
        _watch = w;
        _watch.StartFileWatcher();
    }
}
#endregion