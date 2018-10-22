using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenorQuinuapata.GestionCostos.Models
{
    public class PersonaViewModel
    {
        public IEnumerable<PersonaResponse> ListPersona { get; set; }

        public PersonaResponse GetPersona { get; set; }
    }
}