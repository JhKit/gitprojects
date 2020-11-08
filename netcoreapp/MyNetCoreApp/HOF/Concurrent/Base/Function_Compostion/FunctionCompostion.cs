using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyNetCoreApp.HOF.Concurrent.Base.Function_Compostion
{

    /// <summary>
    ///  组合函数 CoffeeDemo
    ///  限制条件必须为静态对象
    /// </summary>
    public static class FunctionCompostion
    {
        /// <summary>
        /// 组合函数
        /// </summary>
        /// <typeparam name="A">函数</typeparam>
        /// <typeparam name="B">函数</typeparam>
        /// <typeparam name="C">函数</typeparam>
        /// <param name="f"></param>
        /// <param name="g"></param>
        /// <returns></returns>
        static Func<A, C> Compose<A, B, C>(this Func<A, B> f, Func<B, C> g) => (n) => g(f(n));

        static Func<CoffeeBeans, CoffeeGround> grindCoffee = coffenBeans => new CoffeeGround(coffenBeans);

        static Func<CoffeeGround, Espresso> brewCoffee = coffeeGround => new Espresso(coffeeGround);

        public static Func<CoffeeBeans, Espresso> make = grindCoffee.Compose(brewCoffee);

        public class CoffeeBeans
        {
            public CoffeeBeans() { }
        }

        public class CoffeeGround
        {
            public CoffeeGround(CoffeeBeans coffeeBeans) { }
        }

        public class Espresso
        {
            public Espresso(CoffeeGround coffeeGround) { }
        }

    }
}