using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSpin
{
    public interface IRandomizer
    {
        int Generate(int max, int? seed = null);
    }

    public class RealRandom : IRandomizer
    {
        public int Generate(int max, int? seed = null)
        {
            if (seed != null)
            {
                return (new Random(seed.Value)).Next(0, max);
            }
            else
            {
                return (new Random()).Next(0, max);
            }
        }
    }
}
