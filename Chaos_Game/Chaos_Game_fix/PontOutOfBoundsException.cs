using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaos_Game_fix
{
    internal class PointOutOfBoundsException : Exception
    {
        public PointOutOfBoundsException() { }

        public PointOutOfBoundsException(string message) : base(message) { }

        public PointOutOfBoundsException(string message,  Exception innerException) : base(message, innerException) { }
    }
}
