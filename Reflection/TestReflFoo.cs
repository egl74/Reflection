using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    /// <summary>
    ///  Show date and time of creation the instance of the object.
    ///  Don't use Console directly.
    /// </summary>
    public class TestReflFoo
    {
        private static string _s;

        private TestReflFoo()
        {
        }

        private TestReflFoo(string s)
        {
            if (s == null || s.Length == 0)
                throw new ArgumentException("s");

            _s = s + DateTime.Now.ToString("G");
        }

        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        private static void GetValue(out string s)
        {
            s = _s;
        }
    }

    /// <summary>
    /// Create instance of the object, specify some values for the properties.
    /// Create copy of the object with the same values.
    /// Show values of the object. Don't use console directly.
    /// </summary>
    public sealed class TestReflBar
    {
        #region Declarations
        private string _s;
        private int _i;
        private double _d;
        private DateTime _dt;
        #endregion

        public bool B;

        #region Constructors
        private TestReflBar()
        {

        }

        private TestReflBar(double d)
        {
            _d = d;
        }
        #endregion

        #region Properties
        protected string S
        {
            get { return _s; }
            set { _s = value + DateTime.Now; }
        }

        protected int I
        {
            get { return _i; }
            set { _i = value * value; }
        }

        public double D
        {
            get { return _d; }
        }

        protected DateTime Dt
        {
            set { _dt = DateTime.Now; }
        }
        #endregion

        #region Methods
        private DateTime GetDt()
        {
            return _dt;
        }

        private void PrintValue(ref string s, ref int i, double d, DateTime dt, bool b)
        {
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", s, i, d, dt.ToString(), b); //how much parameters are here? Five? Six? Where is the sixth?
        }

        private void PrintValue()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

