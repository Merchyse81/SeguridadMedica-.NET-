using MP09.UF01.P01.Seguretat.Exemple.mp09.uf01.seguretat.exemple.model.security;
using SeguridadMedica.serrano.mercedes.dam.mp09.uf01.pr2.seguridad.model.domain;
using SeguridadMedica.serrano.mercedes.dam.mp09.uf01.pr2.seguridad.view.console;

namespace SeguridadMedica.serrano.mercedes.dam.mp09.uf01.pr2.seguridad.controller
{
    internal class VisitaMedicaController
    {
        private VisitaMedicaView visitaMedicaView = new VisitaMedicaView();

        internal void AplicaSeguridadMD5()
        {
            try
            {
                visitaMedicaView.ShowMensaje("MD5 ---------", false);
                VisitaMedica visitaMedica = visitaMedicaView.GetVisitaMedica();

                if (visitaMedica == null || string.IsNullOrEmpty(visitaMedica.NomPaciente))
                {
                    visitaMedicaView.ShowMensaje("Error al obtener los datos de la visita.", true);
                    return;
                }

                MD5Security security = new MD5Security();
                string nomPacienteEnc = security.Encripta(visitaMedica.NomPaciente);
                string diagnosticoEnc = security.Encripta(visitaMedica.Diagnostico);

                VisitaMedica visitaMedicaEnc = new VisitaMedica();
                visitaMedicaEnc.NomPaciente = nomPacienteEnc;
                visitaMedicaEnc.Diagnostico = diagnosticoEnc;

                visitaMedicaView.ShowVisitaMedica(visitaMedicaEnc);
            }
            catch (Exception ex)
            {
                visitaMedicaView.ShowMensaje("Error: " + ex.Message, true);
            }
        }

        internal void AplicaSeguridadSHA256()
        {
            try
            {
                visitaMedicaView.ShowMensaje("SHA256 ---------", false);
                VisitaMedica visitaMedica = visitaMedicaView.GetVisitaMedica();

                if (visitaMedica == null || string.IsNullOrEmpty(visitaMedica.NomPaciente) || string.IsNullOrEmpty(visitaMedica.Diagnostico))
                {
                    visitaMedicaView.ShowMensaje("Error: Datos de visita médica incompletos o nulos.", true);
                    return;
                }

                SHA256Security security = new SHA256Security();
                string nomPacienteEnc = security.Encripta(visitaMedica.NomPaciente);
                string diagnosticoEnc = security.Encripta(visitaMedica.Diagnostico);

                VisitaMedica visitaMedicaEnc = new VisitaMedica();
                visitaMedicaEnc.NomPaciente = nomPacienteEnc;
                visitaMedicaEnc.Diagnostico = diagnosticoEnc;

                visitaMedicaView.ShowVisitaMedica(visitaMedicaEnc);
            }
            catch (Exception ex)
            {
                visitaMedicaView.ShowMensaje("Error: " + ex.Message, true);
            }
        }

        internal void AplicaSeguridadAES()
        {
            try
            {
                visitaMedicaView.ShowMensaje("AES ---------", false);
                VisitaMedica visitaMedica = visitaMedicaView.GetVisitaMedica();
                AESSecurity security = new AESSecurity();
                string nomPacienteEnc = security.Encripta(visitaMedica.NomPaciente);
                string diagnosticoEnc = security.Encripta(visitaMedica.Diagnostico);

                VisitaMedica visitaMedicaEnc = new VisitaMedica();
                visitaMedicaEnc.NomPaciente = nomPacienteEnc;
                visitaMedicaEnc.Diagnostico = diagnosticoEnc;

                visitaMedicaView.ShowVisitaMedica(visitaMedicaEnc);

                visitaMedicaView.ShowMensaje("AES ------------ Desencripta", false);

                string nomPacienteDesenc = security.Desencripta(visitaMedicaEnc.NomPaciente);
                string diagnosticoDesenc = security.Desencripta(visitaMedicaEnc.Diagnostico);

                VisitaMedica visitaMedicaDesenc = new VisitaMedica();
                visitaMedicaDesenc.NomPaciente = nomPacienteDesenc;
                visitaMedicaDesenc.Diagnostico = diagnosticoDesenc;
                visitaMedicaView.ShowVisitaMedica(visitaMedicaDesenc);
            }
            catch (Exception ex)
            {
                visitaMedicaView.ShowMensaje(ex.Message, true);
            }
        }
    }
}
