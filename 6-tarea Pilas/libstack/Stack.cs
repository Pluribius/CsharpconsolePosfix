using System;
using System.Reflection.Metadata;
namespace pilas;
public class pila
{
    #region atributos

    int maxvalue=1;
    object[] elementos { get; set; }
    public int tope { get; set; }
    //public bool full { get; set; }
    public string mes { get; set; }
    public bool vacia { get; set; }
    public bool llena { get; set; }
    #endregion

    #region constructor
    public pila(int max)
    {
        maxvalue=max;
        elementos = new Object[maxvalue];
        tope = -1;
        mes="";

    }
    #endregion


    #region metodos
    public object pop()
    {//recupera la informacion en el ultimo indice del stack
        mes = "pop! ";
        object res="null";
        if (Vacia()==false)
        {   
            //Console.WriteLine(mes);
            res=elementos[tope];
            
            tope--;
            return (res);
        }
        else {Console.WriteLine(mes + "ERROR stack vacio"); 
            return res;  }


    }

    public object peek()
    {object res="null";
    res=elementos[tope];
       return( res);
    }

    public string poptop()
    {//lee cual es el valor del elemento en el primer indice del stack
        mes = "poptop! " + elementos[0];

        return (mes);
    }
    public void push(object dato)
    {//introduce informacion en el ultimo indice del stack
        mes = "push! ";
        if (LLena() == false)
        {
            tope++;
           // Console.WriteLine("tope= "+tope);
            elementos[tope]=dato;
            //Console.WriteLine(mes + " valor introducido en la posicion: " + tope);
        }
        else
        {
            Console.WriteLine(mes + " Error el stack esta lleno");
        }
    }

    public bool Vacia()
    {//regresa un booleano que dice si el stack esta vacia

        if (tope == -1)
        {
            return vacia = true;
        }
        else { return vacia = false; }
    }
    public bool LLena()
    {//regresa un booleano que dice si el stack esta full

        if (tope == maxvalue)
        {
            return llena = true;
        }
        else { return llena = false; }
    }


    #endregion
}
