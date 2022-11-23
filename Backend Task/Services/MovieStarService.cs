using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Backend.Model;

namespace Backend.Services
{
    public class MovieStarsService : IMovieStarsService
    {
        public int CalculateBirthday(DateTime birthDate)
        {
            var days = (int)(DateTime.Today - birthDate).TotalDays;
            var age = days / 365;
            return age;
        }

        public Actor[] GetMovieStars()
        {
            var jsonText = File.ReadAllText("input.txt");
            var movieStarsArray = JsonConvert.DeserializeObject<Actor[]>(jsonText);
            return movieStarsArray;
        }

        public string PreperaForPrint(Actor actor)
        {
            var stringBuilder = new StringBuilder();
            var actorToPrint = stringBuilder.AppendLine(actor.Name + " " + actor.Surname)
                 .AppendLine(actor.Sex)
                 .AppendLine(actor.Nationality)
                 .AppendLine(actor.Age + " years old");

            return actorToPrint.ToString();
        }
    }
}
