using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
     public interface IMovieStarsService
    {
        Actor[] GetMovieStars();
        int CalculateBirthday(DateTime birthDate);
        string PreperaForPrint(Actor actor);
    }
}
