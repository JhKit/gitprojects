using System;
using System.Collections.Generic;

namespace TestFuncDemo
{
    public class TestFunc
    {
        static Func<T,R> Memoize<T,R>(Func<T,R> func) where T :IComparable
        {
            Dictionary<T,R> cache = new  Dictionary<T,R>();
            return arg =>{
                if(cache.ContainsKey(arg))
                    return cache[arg];
                return (cache[arg]=func(arg));
            };            
        }

        public static string Greeting(string name)
        {
            return $"Warm greetings{name},the time is {DateTime.Now.ToString("hh:mm:ss")}";
        }      
    }    
}