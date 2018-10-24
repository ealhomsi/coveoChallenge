using Microsoft.AspNetCore.Mvc;
using CoveoChallenge.Models;
using CoveoChallenge.Services;
using System.Collections.Generic;
using System;

namespace CoveoChallenge.Controllers
{
    [Route("")]
    [ApiController]
    public class Controller : ControllerBase
    {
        [HttpPost]
        public ActionResult<Output> PostRequest([FromBody] Input problems)
        {
            List<string> answers = new List<string>();
            foreach (Puzzle p in problems.Puzzles)
            {
                answers.Add(PuzzleSolver.Solve(p));
            }

            Participant[] participants = new Participant[3];

            participants[0] = new Participant()
            {
                Email = "elias.alhomsi@hotmail.com",
                FullName = "Elias Al Homsi",
                GoogleAccount = "eliasalhomsi@gmail.com",
                GraduationDate = EpochTimeConverter(new DateTime(2020, 12, 15)),
                IsCaptain = true,
                Phone = "438-969-3563",
                School = "McGill University",
                SchoolProgram = "Software Engineering BEng"
            };

            participants[1] = new Participant()
            {
                Email = "zhou.mia2@gmail.com",
                FullName = "Yuxin Zhou",
                GoogleAccount = "zhou.mia2@gmail.com",
                GraduationDate = EpochTimeConverter(new DateTime(2021, 5, 15)),
                IsCaptain = false,
                Phone = "514-632-5653",
                School = "McGill University",
                SchoolProgram = "Software Engineering BEng"
            };

            participants[2] = new Participant()
            {
                Email = "Carlelkhoury@hotmail.com",
                FullName = "Carl Elkhoury",
                GoogleAccount = "Carlelkhoury5@gmail.com",
                GraduationDate = EpochTimeConverter(new DateTime(2020, 12, 15)),
                IsCaptain = false,
                Phone = "5142249729",
                School = "McGill University",
                SchoolProgram = "Software Engineering BEng"
            };

            return new Output()
            {
                Solutions = answers.ToArray(),
                TeamName = "TableTable",
                Participants = participants
            };

            long EpochTimeConverter(DateTime dateTime)
            {
                var baseDate = new DateTime(1970, 01, 01);
                return (long)dateTime.Subtract(baseDate).TotalMilliseconds;
            }
        }
    }
}
