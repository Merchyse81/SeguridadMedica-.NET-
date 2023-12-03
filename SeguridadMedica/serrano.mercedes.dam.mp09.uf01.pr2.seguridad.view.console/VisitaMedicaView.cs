using SeguridadMedica.serrano.mercedes.dam.mp09.uf01.pr2.seguridad.model.domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguridadMedica.serrano.mercedes.dam.mp09.uf01.pr2.seguridad.view.console
{
    internal class VisitaMedicaView
    {
        internal VisitaMedica GetVisitaMedica()
        {
            try
            {
                VisitaMedica visitaMedica = new VisitaMedica();
                bool datosCorrectos = false;

                while (!datosCorrectos)
                {
                    ShowMensaje("Nº Visita: ", false);
                    if (int.TryParse(Console.ReadLine(), out int idVisita))
                    {
                        visitaMedica.IdVisita = idVisita;
                        datosCorrectos = true;
                    }
                    else
                    {
                        ShowMensaje("Error: Por favor ingresa un número válido.", true);
                    }
                }

                datosCorrectos = false;

                while (!datosCorrectos)
                {
                    ShowMensaje("Nombre del paciente: ", false);
                    string nombreCompletoPaciente = Console.ReadLine().Trim();

                    if (nombreCompletoPaciente.Contains(" ") && nombreCompletoPaciente.Split(" ").Length >= 2)
                    {
                        visitaMedica.NomPaciente = nombreCompletoPaciente;
                        datosCorrectos = true;
                    }
                    else
                    {
                        ShowMensaje("Error: Por favor ingresa nombre y apellido del paciente.", true);
                    }
                }

                datosCorrectos = false;

                while (!datosCorrectos)
                {
                    ShowMensaje("Nombre del médico: ", false);
                    string nombreCompletoMedico = Console.ReadLine().Trim();

                    if (nombreCompletoMedico.Contains(" ") && nombreCompletoMedico.Split(" ").Length >= 2)
                    {
                        visitaMedica.NomMetge = nombreCompletoMedico;
                        datosCorrectos = true;
                    }
                    else
                    {
                        ShowMensaje("Error: Por favor ingresa nombre y apellido del médico.", true);
                    }
                }

                datosCorrectos = false;

                while (!datosCorrectos)
                {
                    ShowMensaje("Fecha visita (Formato yyyy-MM-dd): ", false);
                    string fechaString = Console.ReadLine().Trim();

                    if (DateTime.TryParseExact(fechaString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
                    {
                        visitaMedica.Fecha = fecha;
                        datosCorrectos = true;
                    }
                    else
                    {
                        ShowMensaje("Error al introducir la fecha. Asegúrate de ingresarla en el formato correcto (yyyy-MM-dd).", true);
                    }
                }

                datosCorrectos = false;

                while (!datosCorrectos)
                {
                    ShowMensaje("Diagnóstico: ", false);
                    string diagnostico = Console.ReadLine().Trim();

                    if (!string.IsNullOrEmpty(diagnostico) && diagnostico.Contains(" "))
                    {
                        visitaMedica.Diagnostico = diagnostico;
                        datosCorrectos = true;
                    }
                    else
                    {
                        ShowMensaje("Error: Por favor ingresa un diagnóstico válido (una o varias palabras).", true);
                    }
                }

                return visitaMedica;
            }
            catch (Exception ex)
            {
                ShowMensaje("Error al obtener los datos de la visita: " + ex.Message, true);
                return null;
            }
        }

        internal void ShowMensaje(string mensaje, bool esError)
        {
            if (esError)
            {
                Console.Error.WriteLine(mensaje);
            }
            else
            {
                Console.WriteLine(mensaje);
            }
        }

        internal void ShowVisitaMedica(VisitaMedica visitaMedica)
        {
            Console.WriteLine(visitaMedica.ToString());
        }
    }
}
