using Newtonsoft.Json;

namespace CoveoChallenge.Models
{
    public class Puzzle
    {
        public Location Origin { get; set; }

        public Location End { get; set; }

        public string ScrambledPath { get; set; }
    }
}
