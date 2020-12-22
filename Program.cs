using System;
using System.Drawing;
using System.Text;


class Program
{
    static string[,] field = new string[4, 4];
    static Random rnd = new Random();
    static Point pnt;

    static string[,] GetField()
    {
        string forCheck;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                forCheck = Convert.ToString(rnd.Next(0, 16));
                while (RepeatCheck(forCheck))
                                   
                    forCheck = Convert.ToString(rnd.Next(0, 16));
                    field[i, j] = forCheck;
                

                    if (field[i, j] == "0")
                    {
                        pnt = new Point(i, j);
                    }
                
                
            }
        }
        Console.WriteLine();
        return field;
    }


    static bool RepeatCheck(string check_element)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (field[i, j] == check_element)
                    return true;
            }
        }
        return false;
    }


    static void ShowField()
    {
        Console.Clear();
        Console.CursorTop = 0;
        for (int i = 0; i < 4; i++)
        {
            Console.CursorLeft = 0;

            for (int j = 0; j < 4; j++)
            {
                if ((i == pnt.X) && (j == pnt.Y))
                {
                    field[i, j] = " ";
                }
                Console.Write("{0,5}", field[i, j]);
            }
            Console.WriteLine("\n");
        }
    }


    static void Swap(ref string a, ref string b)
    {
        string temp = a;
        a = b;
        b = temp;
    }


    static void MoveRight()
    {
        if (pnt.Y < field.GetLength(1) - 1)
        {
            Swap(ref field[pnt.X, pnt.Y], ref field[pnt.X, pnt.Y + 1]);
            pnt.Y++;
        }
    }
    static void MoveLeft()
    {
        if (pnt.Y > 0)
        {
            Swap(ref field[pnt.X, pnt.Y], ref field[pnt.X, pnt.Y - 1]);
            pnt.Y--;
        }
    }
    static void MoveUp()
    {
        if (pnt.X > 0)
        {
            Swap(ref field[pnt.X - 1, pnt.Y], ref field[pnt.X, pnt.Y]);
            pnt.X--;
        }
    }
    static void MoveDown()
    {
        if (pnt.X < field.GetLength(0) - 1)
        {
            Swap(ref field[pnt.X + 1, pnt.Y], ref field[pnt.X, pnt.Y]);
            pnt.X++;
        }
    }


    static bool IsWinner()
    {
        int count = 1;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i == j && i == 3) continue;
                if (field[i, j] == count.ToString())
                {
                    count++;
                    continue;
                }
                else return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        field = GetField();
        ShowField();

        while (true)
        {
            ConsoleKeyInfo cur = Console.ReadKey();

            if (cur.Key == ConsoleKey.UpArrow)
            {
                MoveUp();
            }
            if (cur.Key == ConsoleKey.DownArrow)
            {
                MoveDown();
            }
            if (cur.Key == ConsoleKey.LeftArrow)
            {
                MoveLeft();
            }
            if (cur.Key == ConsoleKey.RightArrow)
            {
                MoveRight();
            }
            if (cur.Key == ConsoleKey.Enter)
            {
                if (IsWinner())
                {
                   Console.Write("You won!");
                }
            }
            ShowField();
        }
    }
}
