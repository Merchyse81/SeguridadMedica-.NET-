using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguridadMedica.serrano.mercedes.dam.mp09.uf01.pr2.seguridad.model.domain
{
    internal class VisitaMedica
    {
        private int idVisita;
        private string nomPaciente;
        private string nomMetge;
        private DateTime fecha;
        private string diagnostico;
        internal string NombreMedico;

        internal int IdVisita
        {
            get { return idVisita; }
            set { idVisita = value; }
        }

        internal string NomPaciente
        {
            get { return nomPaciente; }
            set { nomPaciente = value; }
        }

        internal string NomMetge
        {
            get { return nomMetge; }
            set { nomMetge = value; }
        }

        internal DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        internal string Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }

        public string NombrePaciente { get; internal set; }

        internal bool ValidarDatosInformados()
        {
            return ContieneEspacio(nomPaciente) && ContieneEspacio(nomMetge) &&
                   !string.IsNullOrEmpty(nomPaciente) &&
                   !string.IsNullOrEmpty(nomMetge) &&
                   fecha != DateTime.MinValue &&
                   !string.IsNullOrEmpty(diagnostico);
        }

        private bool ContieneEspacio(string texto)
        {
            return !string.IsNullOrEmpty(texto) && texto.Contains(" ");
        }

        public override string ToString()
        {
            return $"VisitaMedica [idVisita={idVisita}, nomPaciente={nomPaciente}, nomMetge={nomMetge}, fecha={fecha}, diagnostico={diagnostico}]";
        }
    }
}
