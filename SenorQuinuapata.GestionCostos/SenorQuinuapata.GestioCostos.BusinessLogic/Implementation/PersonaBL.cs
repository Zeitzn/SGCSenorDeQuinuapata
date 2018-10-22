using SenorQuinuapata.GestionCostos.DataAccess.Implementation;
using SenorQuinuapata.GestionCostos.DataAccess.Interface;
using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestioCostos.BusinessLogic.Implementation
{
    public class PersonaBL:IPersonaBL
    {
        private readonly PersonaDA _PersonaDA = new PersonaDA();

       
        #region transaccional
        public void RegisterPersona(PersonaRequest persona)
        {
            _PersonaDA.RegisterPersona(persona);
        }
        #endregion


        #region no transaccional
        public IEnumerable<PersonaResponse> List()
        {
            return _PersonaDA.List();
        }

        public void MarcarAsistencia(int id)
        {
            _PersonaDA.MarcarAsistencia(id);
        }

        public IEnumerable<AsistenciaResponse> ReportAsistencia(int mes)
        {
            string fecha_actual = DateTime.Now.ToString();

            string _anio = fecha_actual.Substring(6, 4);

            int anio = Convert.ToInt32(_anio);

            return _PersonaDA.ReportAsistencia(mes,anio);
        }
        

        public PersonaResponse GetPersonaByDni(string dni)
        {
            return _PersonaDA.GetPersonaByDni(dni);
        }

        #endregion

    }
}
