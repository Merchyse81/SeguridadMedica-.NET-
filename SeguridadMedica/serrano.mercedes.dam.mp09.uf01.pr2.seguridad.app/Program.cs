
using SeguridadMedica.serrano.mercedes.dam.mp09.uf01.pr2.seguridad.controller;

namespace SeguridadMedica.serrano.mercedes.dam.mp09.uf01.pr2.seguridad.app
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            VisitaMedicaController visitaMedicaController = new VisitaMedicaController();
            visitaMedicaController.AplicaSeguridadMD5();
            visitaMedicaController.AplicaSeguridadSHA256();
            visitaMedicaController.AplicaSeguridadAES();
        }
    }

}

