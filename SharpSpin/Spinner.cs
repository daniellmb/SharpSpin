using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSpin
{
    /// <summary>
    /// Supports both Nested and Flat Spinning
    /// </summary>
    /// <example>
    /// Spinner.Spin("{The {quick|fast|speedy} brown fox {jumped|leaped|hopped} {over|right over|over the top of} the {lazy|sluggish|care-free|relaxing} dog.|{While|Although} just {taking|having} a{| little| quick} {siesta|nap} the dog was {startled|shocked|surprised} by a {quick|fast|speedy} {brown|dark brown|brownish} fox that {leaped|jumped} right {over|over the top of} him.}");
    /// </example>
    public static class Spinner
    {
        public static IRandomizer Randomizer = new RealRandom();
        public static int permutations = 1;
        private const char OPEN_BRACE = '{';
        private const char CLOSE_BRACE = '}';
        private const char DELIMITER = '|';

        public static string Spin(string content)
        {
            //quick data sanity check
            if (content == null)
            {
                throw new ArgumentException("Text content to spin is required.");
            }

            //get index of the start and ending bracess
            var start = content.IndexOf(OPEN_BRACE);
            var end = content.IndexOf(CLOSE_BRACE);

            //return the original content if:
            //  if there are no braces {} at all
            //  there is no start brace {
            //  the end is before the start } {
            if (start == -1 && end == -1 || start == -1 || end < start)
            {
                return content;
            }

            //replace first brace
            var substring = content.Substring(start + 1, content.Length - (start + 1));

            //recursion
            var rest = Spin(substring);
            end = rest.IndexOf(CLOSE_BRACE);
            
            //check for issues
            if (end == -1)
            {
                throw new FormatException("Unbalanced brace.");
            }

            //get spin options
            var options = rest.Substring(0, end).Split(DELIMITER);

            //update permutations count
            permutations *= options.Length;

            //get random item
            var item = options[Randomizer.Generate(options.Length)];

            //substitute content and recurse the rest
            return content.Substring(0, start) + item + Spin(rest.Substring(end + 1, rest.Length - (end + 1)));
        }

        public static int Permutations(string content)
        {
            permutations = 1;

            Spin(content);

            return permutations;
        }
    }
}
