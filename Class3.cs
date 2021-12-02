using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace lab6
{
    class Errors
    {
    }

    class TestException : Exception
    {
        public TestException(string message):base(message)
        {

        }
    }

    class Speed_of_transportException : ArgumentException
    {
        public int Value { get; }
        public Speed_of_transportException(string message, int val):base(message)
        {
            Value = val;
        }
    }

    class MaskException : Exception
    {
        public MaskException(string message):base(message)
        {

        }
    }
    class AssertException : Exception
    {
        public AssertException(string message) : base(message)
        {

        }
    }
}
