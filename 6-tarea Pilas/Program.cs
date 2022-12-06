using syntax;
using boundingbox;
namespace menu
{
    class program
    {
        static void Main(string[] args)
        {
            check p1 = new check(50);//instaciacion del objeto que controla la logica de la calculadora
            box gui = new box(25, 86);//instaciacion del objeto que controla la gui de consola 

            gui.startup();
            gui.cambiar_color(ConsoleColor.DarkRed, ConsoleColor.DarkRed);
            gui.cuadro('■');


            #region menu
            bool temp = false;
            int menurespuesta = 0;
            string error = "introduzca la opcion nuevamente";

            //menu de opciones
            do
            {
                gui.textHandler("introduzca la operacion que se desea realizar", 1);
                gui.textHandler("1-cargar", 1);
                gui.textHandler("2-verificar", 1);
                gui.textHandler("3-transformar", 1);
                gui.textHandler("4-Mostrar expresion", 1);
                gui.textHandler("5-salir", 1);

                try
                {
                    menurespuesta = Convert.ToInt32(Console.ReadLine());
                    switch (menurespuesta)
                    {
                        case 1:
                            gui.clear();

                            gui.textHandler("---Cargar---", 1);
                            p1.cargar();

                            break;
                        case 2:
                            gui.clear();
                            gui.textHandler("---verificar---", 1);
                            p1.verificar();
                            break;

                        case 3:
                            gui.clear();
                            gui.textHandler("---Transformar---", 1);
                            p1.transformar();
                            break;

                        case 4:
                            gui.clear();

                            gui.textHandler("---Mostrar expresion introducida--", 1);
                            p1.mostrar();
                            break;

                        case 5:
                            gui.clear();

                            gui.textHandler("---Salir---", 1);
                            temp = true;
                            break;

                        default:
                            gui.textHandler("respuesta fuera de rango" + error, 1);
                            break;
                    }

                }
                catch (System.FormatException)
                {
                    gui.clear();

                    gui.textHandler("error de formato!:" + error, 1);
                }
            } while (temp == false);
            #endregion


        }
    }
}
