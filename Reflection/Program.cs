using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(TestReflFoo);
            Type typei = typeof(int);
            Type typestr = typeof(string);
            ConstructorInfo c = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
            null, new Type[] { typeof(String) }, null);
            Object o = c.Invoke(new Object[] { "Hello!" }); // calling private constructor with a parameter

            Type[] argTypes = { typestr.MakeByRefType() };
            Type[] argtyp = { typeof(string) };
            MethodInfo mi1 = typeof(TestReflFoo).GetMethod("GetValue", BindingFlags.NonPublic | BindingFlags.Static, Type.DefaultBinder, argTypes, null);
            var input = new object[] { "" };
            mi1.Invoke(null, input); // calling private static property with an out parameter

            MethodInfo mi2 = typeof(TestReflFoo).GetMethod("WriteLine", BindingFlags.Public | BindingFlags.Instance, Type.DefaultBinder, argtyp, null);            
            mi2.Invoke(o, input); // finally calling public non-static method with a parameter from an instance

            Type type2 = typeof(TestReflBar);
            ConstructorInfo c1 = type2.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(double) }, null);
            object o1 = c1.Invoke(new Object[] {6.54});// creating an instance

            PropertyInfo propint = o1.GetType().GetProperty("I", BindingFlags.NonPublic | BindingFlags.Instance);     
            propint.SetValue(o1, 7, null);

            PropertyInfo propstr = o1.GetType().GetProperty("S", BindingFlags.NonPublic | BindingFlags.Instance);
            propstr.SetValue(o1, "Coin", null);

            PropertyInfo propdat = o1.GetType().GetProperty("Dt", BindingFlags.NonPublic | BindingFlags.Instance);
            propdat.SetValue(o1, null, null);

            FieldInfo fldbool = o1.GetType().GetField("B", BindingFlags.Public | BindingFlags.Instance);
            
            fldbool.SetValue(o1, true);
            
            TestReflBar o2 = (TestReflBar)o1; //create copy of the object

            PropertyInfo propstr2 = o2.GetType().GetProperty("S", BindingFlags.NonPublic | BindingFlags.Instance);
            string s2 = (string)propstr2.GetValue(o2);

            PropertyInfo propint2 = o2.GetType().GetProperty("I", BindingFlags.NonPublic | BindingFlags.Instance);
            int i2 = (int)propint2.GetValue(o2);

            PropertyInfo propdbl2 = o2.GetType().GetProperty("D", BindingFlags.Public | BindingFlags.Instance);
            double d2 = (double)propdbl2.GetValue(o2);

            MethodInfo methdat2 = o2.GetType().GetMethod("GetDt", BindingFlags.NonPublic | BindingFlags.Instance);
            DateTime dt2 = (DateTime)methdat2.Invoke(o2, null);

            FieldInfo fldbool2 = o2.GetType().GetField("B", BindingFlags.Public | BindingFlags.Instance);
            bool b2 = (bool)fldbool2.GetValue(o2);
            
            Type[] outTps = { typestr.MakeByRefType(), typei.MakeByRefType(), typeof(double), typeof(DateTime), typeof(bool) };
            MethodInfo mou = typeof(TestReflBar).GetMethod("PrintValue", BindingFlags.NonPublic | BindingFlags.Instance, Type.DefaultBinder, outTps, null);
            var inp1 = new object[] { s2, i2, d2, dt2, b2 };
            mou.Invoke(o2, inp1); //show values of the object
            Console.ReadLine();
        }
    }
}
