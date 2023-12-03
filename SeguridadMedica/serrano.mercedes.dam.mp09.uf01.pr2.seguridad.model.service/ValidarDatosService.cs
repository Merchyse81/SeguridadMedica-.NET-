using SeguridadMedica.serrano.mercedes.dam.mp09.uf01.pr2.seguridad.model.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguridadMedica.serrano.mercedes.dam.mp09.uf01.pr2.seguridad.model.service
{
    internal class ValidarDatosService
    {
        internal bool ValidarVisitaMedica(VisitaMedica visitaMedica)
        {
            DateTime fechaActual = DateTime.Now;

            return visitaMedica != null &&
                   ValidarString(visitaMedica.NomPaciente) &&
                   ValidarString(visitaMedica.NomMetge) &&
                   ValidarFecha(visitaMedica.Fecha, fechaActual) &&
                   ValidarString(visitaMedica.Diagnostico);
        }

        private bool ValidarString(string texto)
        {
            return !string.IsNullOrEmpty(texto);
        }

        private bool ValidarFecha(DateTime fecha, DateTime fechaActual)
        {
            return fecha.Date <= fechaActual.Date;
        }
    }
}
