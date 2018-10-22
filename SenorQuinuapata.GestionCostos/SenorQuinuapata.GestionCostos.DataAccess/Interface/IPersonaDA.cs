using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.DataAccess.Interface
{
    public interface IPersonaDA
    {
        void RegisterPersona(PersonaRequest persona);
        IEnumerable<PersonaResponse> List();
        void MarcarAsistencia(int id);
        IEnumerable<AsistenciaResponse> ReportAsistencia(int mes, int anio);
        PersonaResponse GetPersonaByDni(string dni);
    }
}
