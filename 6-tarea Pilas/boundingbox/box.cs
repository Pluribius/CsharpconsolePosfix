using System.Threading.Tasks.Dataflow;
using pilas;
namespace boundingbox;
public class box:pila
{
    //86width //25heigth
    #region atributos
    public int height { get; set; }
    public int width { get; set; }
    private System.ConsoleColor Colorfore;
    private System.ConsoleColor Colorback;
    private int Counter = 1;
    public pila? guimemmo;
    #endregion

    #region constructor
    public box(int Alto, int Ancho):base(23)
    {
        if (Alto <= 1 || Alto > Console.LargestWindowHeight)
        {
            //default vom viewurfel setzen 
            height = 25;
        }
        else { height = Alto; }
        if (Ancho <= 1 || Ancho > Console.LargestWindowWidth)
        {
            //default vom viewurfel setzen 
            width = 86;
        }
        else { width = Ancho; }
    }
  
    #endregion
    #region metodos
    public void cambiar_color(ConsoleColor Fore,ConsoleColor back)
    {   
        Colorfore=Fore;
        Colorback=back;
    }
    public void startup()
    {   Console.ResetColor();
        Console.Clear();
        Console.SetWindowSize(width, height);
        Console.Title = "Universidad Santa Maria--Rafael Ramis";
    }



    public void cuadro(char character)
    {
        Console.Clear();
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if ((y == 0) || (y == height - 1) || (x == 0) || (x == width - 1))
                {
                    Console.ForegroundColor = Colorfore;
                    Console.BackgroundColor = Colorback;
                    Console.Write(character);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write('■');
                }
            }
        }
        Console.SetCursorPosition(1,1);
    }
    public void line(char character, int x1, int y1, int x2, int y2)
    {
        //m=y2-y1
        //  -------   y=mx+b---> y-mx=b
        //   x2-x1
        int b = 0, y = 0, m = 0;
        m = ((y2 - y1) / (x2 - x1));
        b = y1 - (m * x1);
        for (int x_axis = 0; x_axis < width; x_axis++)
        {
            y = (m * x_axis) + b;
            if (y <= height)
            {
                Console.SetCursorPosition(x_axis, y);
                Console.ForegroundColor = Colorfore;
                Console.BackgroundColor = Colorback;
                Console.Write(character);
            }
        }
        Console.ResetColor();
    }
    public void point(char character, int x2, int y2)
    {
        if (x2 >= 0 && y2 >= 1 && x2 < width && y2 < height + 1)
        {
            Console.SetCursorPosition(x2, y2);
            Console.ForegroundColor = Colorfore;
            Console.BackgroundColor = Colorback;
            Console.Write(character);
            Console.ResetColor();
        }
    }
    public void clear()
    {
        Console.Clear();
        Counter = 1;
        cuadro('■');
    }
    public void sync(int val)
    {Counter=val;}
    public void textHandler(string text, int margin_left)
    {   
        Console.ResetColor();
        if (margin_left < 1) { Console.WriteLine(text);}
        else
        {
        Counter++;
        int center=1;
        foreach (var i in text)
        {
         center++;   
        }
        center=(width/2-(center/2))+margin_left;
        /*guimemmo.push(text);
        if(Counter>=height)
        {
            height++;
            startup();
            cambiar_color(ConsoleColor.DarkRed,ConsoleColor.DarkRed);
            cuadro('■');
        }*/
         Console.SetCursorPosition(center, Console.CursorTop);
        Console.WriteLine(text);
        Console.SetCursorPosition(width/2,Console.CursorTop);
        
        }
    }
    #endregion
}
