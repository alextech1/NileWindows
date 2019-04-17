using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsData
{
    /// <summary>Provides a simple sequence of numbers.</summary>
    public class Sequence
    {
        /// <summary>Initializes an instance of the <see cref="Sequence"/> class.</summary>
        /// <remarks>
        /// The starting value is 1.
        /// </remarks>
        public Sequence() : this(1)
        {
        }

        /// <summary>Initializes an instance of the <see cref="Sequence"/> class.</summary>
        /// <param name="startingValue">The starting value to use.</param>
        public Sequence(int startingValue)
        {
            _value = startingValue;
        }

        /// <summary>Gets the next number.</summary>
        /// <returns>The next number.</returns>
        public int Next()
        {
            return _value++;
        }

        private int _value;
    }
}
