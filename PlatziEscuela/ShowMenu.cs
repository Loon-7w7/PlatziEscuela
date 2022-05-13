using System;
using System.Collections.Generic;
using PlatziEscuela.Entidades;
using PlatziEscuela.App;
using PlatziEscuela.Util;
using static System.Console;
using System.Linq;
using PlatziEscuela.Entidades.Interfaces;
using PlatziEscuela.constanttexts;
using PlatziEscuela.CasesSwitchMenu;

namespace PlatziEscuela
{
    public class ShowMenu 
    {
        static EscuelaEngine engine = new EscuelaEngine();
        static Reporteador reporteador;
        static PressEnterOrEsc PressEscOrEnter = new PressEnterOrEsc();
        static EndProgram ProgramEnd = new EndProgram();
        public void MenuShow()
        {
            engine.InicialicarValoresDelPrograma();
            reporteador = new Reporteador(engine.GetDicionario());
            try
            {

                ShowSelecTorMenu();

                
                int opcionSeleccionada = Int32.Parse(Console.ReadLine());
                switch (opcionSeleccionada)
                {
                    case 1:
                        var firstCase = new FirstCaseShowListOfEvaluations();
                        firstCase.ShowFirstCase(reporteador);

                        break;

                    case 2:
                        var SecanodCase = new SecondCaseShowListEvaluationsBySubject();
                        SecanodCase.ShowSecondCase(reporteador);
                        break;

                    case 3:
                        var ThridCase = new ThirdCaseShowListOfSubjects();
                        ThridCase.ShowTridCase(reporteador);
                        break;

                    case 4:
                        var fourrhCase = new FourthCaseShowListOfAveragesBySubject();
                        fourrhCase.ShowFourthCase(reporteador);
                        break;

                    case 5:
                        var FifthCase = new FifthCaseShowTopAveragesBySubject();
                        FifthCase.ShowFifthCase (reporteador);
                        break;

                    case 6:
                        var SixthCase = new SixthCaseShowTopOfAveragesOfASubject();
                        SixthCase.ShowSexthCase(reporteador);
                       
                        break;

                    case 7:
                        var Seventhcase = new SeventhCaseFinishProgram();
                        Seventhcase.ShowSeventhCase();
                        break;

                    default:
                        var Defaultcase = new DefaultCaseSwitch();
                        Defaultcase.showDefaulrcase();
                        break;
                }
            }
            catch (FormatException)
            {
                var CatchCase = new CatchCaseEvent();
                CatchCase.ShowCatchCase();
            }
        }

        private void ShowSelecTorMenu() 
        {
            var ConstanText = new SConstanTextMostrarmenu();
            var TextsList = ConstanText.ShowSelector;

            int TmporalPointCount = 0;
            foreach (var itemTexts in TextsList)
            {
                if (TmporalPointCount == 0)
                {
                    Printer.EscirbirTitulo(itemTexts);
                    TmporalPointCount++;
                }
                WriteLine(itemTexts);

            }
        }
    }

    


}