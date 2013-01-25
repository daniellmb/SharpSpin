using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSpin
{
    public interface IRandomizer
    {
        int Generate(int max);
    }

    public class RealRandom : IRandomizer
    {
        public int Generate(int max)
        {
            return (new Random()).Next(0, max);
        }
    }
}
