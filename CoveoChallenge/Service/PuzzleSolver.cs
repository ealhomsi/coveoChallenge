using CoveoChallenge.Models;
using System;
using System.Collections.Generic;

namespace CoveoChallenge.Services
{
    public static class PuzzleSolver
    {
        public static string Solve(Puzzle p)
        {
            int horizDiff = p.End.Col - p.Origin.Col;
            int vertiDiff = p.End.Row - p.Origin.Row;

            //horiz ++> l --> r
            //verti ++> u --> d
            foreach(char c in p.ScrambledPath)
            {
                switch (c)
                {
                    case 'l':
                            horizDiff++;
                        break;
                    case 'r':
                            horizDiff--;
                        break;
                    case 'u':
                            vertiDiff++;
                        break;
                    case 'd':
                            vertiDiff--;
                        break;
                    case '?':
                        break;
                }
            }

            int must = horizDiff + vertiDiff;

            List<char> mustPut = new List<char>();
            while(horizDiff> 0)
            {
                horizDiff--;
                mustPut.Add('r');
            }

            while(horizDiff < 0)
            {
                horizDiff++;
                mustPut.Add('l');
            }

            while (vertiDiff > 0)
            {
                vertiDiff--;
                mustPut.Add('d');
            }

            while (vertiDiff < 0)
            {
                vertiDiff++;
                mustPut.Add('u');
            }

            Location current = new Location()
            {
                Col = p.Origin.Col,
                Row = p.Origin.Row
            };

            int k = 0;
            string answer = "";
            foreach(char c in p.ScrambledPath){
                char assinged = ' ';
                if (c != '?')
                    assinged = c;
                else if (k != mustPut.Count)
                    assinged = mustPut[k++];
                else
                    assinged = StupidMove(answer, mustPut);
                answer += assinged;
                switch (assinged)
                {
                    case 'l':
                        current.Col--;
                        break;
                    case 'r':
                        current.Col++;
                        break;
                    case 'u':
                        current.Row--;
                        break;
                    case 'd':
                        current.Row++;
                        break;
                }
            }

            return answer;
        }

        private static char StupidMove(string answer, List<char> mustPut)
        {
            switch (answer[answer.Length-1])
            {
                case 'l':
                    mustPut.Add('l');
                    return 'r';
                case 'r':
                    mustPut.Add('r');
                    return 'l';
                case 'u':
                    mustPut.Add('u');
                    return 'd';
                case 'd':
                    mustPut.Add('d');
                    return 'u';
            }

            return 'l';
        }
    }
}
