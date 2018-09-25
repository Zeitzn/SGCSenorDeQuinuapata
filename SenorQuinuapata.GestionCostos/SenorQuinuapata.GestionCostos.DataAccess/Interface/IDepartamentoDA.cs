﻿using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.DataAccess.Interface
{
    public interface IDepartamentoDA
    {
        IEnumerable<DepartamentoResponse> List();

        IEnumerable<FlujoUnidadesDepartamentoResponse> ListReportDemo(int id_departamento);
    }
}
