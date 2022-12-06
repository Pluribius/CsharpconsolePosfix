using System.Text.RegularExpressions;
using System;
using pilas;
using boundingbox;
namespace syntax;
public class check
{
    #region atributos
    box gui = new box(25, 86);
    public string userinput { get; set; }//= new string[50];
    public int maxstring { get; set; }
    private char[] chart = new char[45] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',//0-9
                                          '(', ')', ' ', '%', '*', '+', '-', '/', '^',     //10-18
                                          'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',//19-28
                                          'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',//29-38
                                          'u', 'v', 'w', 'x', 'y', 'z'};                   //39-44
    public pila buffer = new pila(50);
    private bool status = false;
    #endregion

    #region constructor
    public check(int size)
    {
        maxstring = size;

    }
    #endregion

    #region metodos
    public void cargar()
    {

        gui.textHandler("-------------------------cargar----------------------", 1);

        status = false;
        do
        {
            gui.textHandler("introduzca la expresion", 1);
            userinput = Console.ReadLine();
            if ((userinput.Length > maxstring) || (userinput.Length <= 0))
            {
                gui.textHandler("por favor introduzca una expresion", 1);
            }
            else
            {
                status = true;
            }
            userinput = userinput.ToLower();

        } while (status == false);

        gui.textHandler("-----------------------------------------------------", 1);
        Console.ReadKey();

    }

    public void verificar()
    {

        gui.textHandler("-------------------------verificar-------------------", 1);
        bool error = false;
        char[] scanner = new char[maxstring];
        scanner = userinput.ToCharArray();
        if ((scanner[0] != '(') || (scanner[scanner.Count() - 1] != ')'))
        {
            error = true;
            gui.textHandler("error!, la expresion debe tener al menos un parentesis", 1);
            mostrar();

        }
        else
        {
            //conteo de parentesis
            int abre = 0, cierra = 0;
            for (int i = 0; i < userinput.Count(); i++)
            {
                switch (scanner[i])
                {
                    case '(':
                        abre++;
                        break;
                    case ')':
                        cierra++;
                        break;
                }
            }
            if (abre != cierra)
            {
                error = true;
                gui.textHandler("error!, disparidad entre parentesis", 1);
                mostrar();
                Console.ReadKey();

            }
            //verificacion de repeticion adyacente de caracter
            for (int i = 1; i < scanner.Count(); i++)
            {
                bool trigger = false;
                if (scanner[i] == scanner[i - 1])
                {
                    for (int j = 13; j < chart.Count(); j++)
                    {
                        if (scanner[i] == chart[j])
                        {
                            error = true;
                            gui.textHandler("error,repeticion invalida:" + scanner[i], 1);
                            trigger = true;
                        }
                    }
                    if (trigger == true)
                    {
                        mostrar();
                        Console.ReadKey();
                    }
                }
            }



        }

        if (error == false)
        { gui.textHandler("expresion valida", 1); }
        else { cargar(); }


        gui.textHandler("-----------------------------------------------------", 1);
        Console.ReadKey();

    }
    public void transformar()
    {

        gui.textHandler("-------------------------transformar-----------------", 1);
        if (status == false)
        {
            gui.textHandler("aun no se ha introducido una expresion", 1);
            cargar();
        }
        if (buffer.Vacia() == true)
        {
            gui.textHandler("a", 1);
        }
        char[] scanner = new char[maxstring];
        scanner = userinput.ToCharArray();

        for (int i = 0; i < scanner.Count(); i++)
        {
            gui.textHandler("  " + scanner[i].ToString(), 1);
            if (scanner[i] != '(')
            {
                if (scanner[i] == ')')
                {
                    gui.textHandler("---juntar---", 1);
                    string termino;
                    string varA, varB, Op;

                    varA = ((buffer.pop()).ToString());
                    Op = ((buffer.pop()).ToString());
                    varB = ((buffer.pop()).ToString());

                    buffer.push('(' + varA + varB + Op + ')');
                    gui.textHandler("------", 1);
                }
                else
                {
                    buffer.push(scanner[i]);
                }
            }
        }

        gui.textHandler((buffer.pop()).ToString(), 1);

        Console.ReadKey();

    }



    public void juntar()
    {

    }
    public void mostrar()
    {

        gui.textHandler("-------------------------mostrar---------------------", 1);
        if (status == false)
        {
            gui.textHandler("no se ha introducido ninguna expresion", 1);
            gui.textHandler("por favor cargue una", 1);
        }
        else
        {
            gui.textHandler("Expresion introducida:", 1);
            gui.textHandler(userinput, 1);
        }

        gui.textHandler("-----------------------------------------------------", 1);
        Console.ReadKey();

    }
    #endregion
}
