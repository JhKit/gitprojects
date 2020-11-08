using System;
using System.Collections.Generic;
using System.Threading;
using static MyNetCoreApp.HOF.Concurrent.Base.Function_Compostion.FunctionCompostion;

namespace MyNetCoreApp
{
    class Program
    {
        /*记忆化函数
         * 记忆化函数的工作是查找内部表中传递的参数
         * 如果找到输入值
         * 则返回先前计算的结果
         * 否则
         * 该函数将结果存储在表中
         * 总结 如果传入的参数已经在该函数中运行过一次且存储在表中，可以避免相同的参数在运算一次，可直接获取存在表中的数据
         * **/
        /// <summary>
        /// 记忆化函数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        static Func<T, R> Memoize<T, R>(Func<T, R> func) where T : IComparable
        {
            Dictionary<T, R> cache = new Dictionary<T, R>();
            return arg => {
                if (cache.ContainsKey(arg))
                    return cache[arg];
                return cache[arg] = func(arg);
            };
        }


        public static string Greeting(string name)
        {
            return $"Warm greetings {name},the time is {DateTime.Now:hh:mm:ss}";
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(Greeting("Richard"));
            //Thread.Sleep(2000);
            //Console.WriteLine(Greeting("Paul"));
            //Thread.Sleep(2000);
            //Console.WriteLine(Greeting("Richard"));
            //Console.ReadLine();

            var greetingMemoize = Memoize<string, string>(Greeting);
            Console.WriteLine(greetingMemoize("Richard"));
            Thread.Sleep(2000);
            Console.WriteLine(greetingMemoize("Paul"));
            Thread.Sleep(2000);
            Console.WriteLine(greetingMemoize("Richard"));
            Thread.Sleep(2000);
            Console.WriteLine(greetingMemoize("Paul"));

            //组合函数Demo
            Espresso espresso = make(new CoffeeBeans());
        }
    }
}
