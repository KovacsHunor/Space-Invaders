using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp2
{
    public struct enemy
    {
        public int élet;
        public int eposition;
        public string kinézet1;
        public string kinézet2;
        public string kinézet3;
    }
    class Program
    {
        private static int l2 = 0;
        private static int szaml = 0;
        private static int kör = 1;
        private static int x = 0;
        private static int y = 0;
        private static int seged2 = 0;
        private static int health = 3;
        private static int position = 0;
        static int speed = 1;
        private static int l = 0;
        private static int[] bulletposition = new int[100];
        private static int a = 0;
        private static int b = 0;
        private static ConsoleKeyInfo keyinfo;

        private static int high2 = 9;

        private static int[] high = new int[100];

        private static int lov = 1;
        static int seged = 0;
        static string lent = "\n\n\n\n\n\n\n\n\n\n";
        static string rakéta1 = "  A";
        static string rakéta2 = " |O|";
        static string rakéta3 = "  H";
        static string rakéta4 = "<OOO>";
        static enemy[] ellen = new enemy[10];
        static enemy[] pajzs = new enemy[10];
        static enemy boss;
        static enemy[] gun = new enemy[3];
        

        static string elent = "\n\n\n\n\n\n\n\n\n\n\n\n";
        static void Main(string[] args)
        {
            for (int i = 0; i < ellen.Length; i++)
            {
                ellen[i].élet = 1;
            }
            for (int i = 0; i < ellen.Length; i++)
            {
                pajzs[i].élet = 0;
            }
            gun[0].eposition = 62;
            gun[1].eposition = 63;
            gun[2].eposition = 64;
            ellen[0].eposition = 6;
            for (int i = 1; i < ellen.Length; i++)
            {
                ellen[i].eposition = ellen[i - 1].eposition + 11;
            }
            ellen[0].kinézet1 = "[OOO]";
            ellen[0].kinézet2 = "  H";
            ellen[0].kinézet3 = "  V";
            pajzs[0].kinézet1 = "=======";
            boss.kinézet1   = "|OOOOO|";
            boss.kinézet2   = " <HHH>";
            gun[0].kinézet1 = "V";
            gun[1].kinézet1 = "V";
            gun[2].kinézet1 = "V";

            Timer timer = new Timer();
            timer.Interval = 150;
            timer.AutoReset = true;
            timer.Elapsed += Tick;
            Console.CursorVisible = false;

            for (int i = 0; i < high.Length; i++)
            {
                high[i] = 24;
            }
            timer.Start();



            while (true)

            {

                keyinfo = Console.ReadKey(true);

                if (keyinfo.Key == ConsoleKey.RightArrow && 114 > position)
                {
                    speed = 1;

                }
                if (keyinfo.Key == ConsoleKey.LeftArrow && 0 < position)
                {
                    speed = -1;

                }
                if (keyinfo.Key == ConsoleKey.Spacebar)
                {

                    lov = 2;
                    seged = 1;

                }

            }
        }
        static void ellensegrajz()
        {
            for (int i = 0; i < ellen.Length; i++)
            {
                if (ellen[i].élet == 1)
                {
                    Console.SetCursorPosition(ellen[i].eposition, 6);
                    Console.WriteLine(ellen[0].kinézet1);
                    Console.SetCursorPosition(ellen[i].eposition, 7);
                    Console.WriteLine(ellen[0].kinézet2);
                    Console.SetCursorPosition(ellen[i].eposition, 8);
                    Console.WriteLine(ellen[0].kinézet3);
                    if (x == 1 && pajzs[i].élet == 1)
                    {
                        Console.SetCursorPosition(ellen[i].eposition - 1, 9);
                        Console.WriteLine(pajzs[0].kinézet1);
                    }
                    
                }
                if (gun[0].élet == 1 || gun[1].élet == 1 || gun[2].élet == 1)
                {
                    Console.SetCursorPosition(60, 6);
                    Console.WriteLine(boss.kinézet1);
                    Console.SetCursorPosition(60, 7);
                    Console.WriteLine(boss.kinézet2);
                    Console.SetCursorPosition(gun[0].eposition - 2, 8);
                    Console.WriteLine("~");
                    Console.SetCursorPosition(gun[0].eposition - 1, 8);
                    Console.WriteLine("~");
                    Console.SetCursorPosition(gun[2].eposition + 1, 8);
                    Console.WriteLine("~");
                    Console.SetCursorPosition(gun[2].eposition + 2, 8);
                    Console.WriteLine("~");

                    Console.SetCursorPosition(gun[0].eposition, 8);
                    if (gun[0].élet == 1)
                    {
                        Console.Write($"{gun[0].kinézet1}");
                    }
                    else
                    {
                        Console.WriteLine("~");
                    }
                    Console.SetCursorPosition(gun[1].eposition, 8);
                    if (gun[1].élet == 1)
                    {
                        Console.Write($"{gun[1].kinézet1}");
                    }
                    else
                    {
                        Console.WriteLine("~");
                    }
                    Console.SetCursorPosition(gun[2].eposition, 8);
                    if (gun[2].élet == 1)
                    {
                        Console.Write($"{gun[2].kinézet1}");
                    }
                    else
                    {

                        Console.WriteLine("~");
                    }

                }
            }
        }
        static void rajz()
        {
            Console.Write(elent);


            Console.WriteLine($"{lent}");
            for (int i = 0; i < position; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine($"{rakéta1}");
            for (int i = 0; i < position; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine($"{rakéta2}");
            for (int i = 0; i < position; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine($"{rakéta3}");
            for (int i = 0; i < position; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine($"{rakéta4}");

        }
        static void Tick(object sender, ElapsedEventArgs e)
        {
            
            if (health > 0)
            {
               

                position += speed;
                
                Console.Clear();
                if (seged2 == 0)
                {
                    Console.SetCursorPosition(5, 4);
                    Console.WriteLine($"Maradt életek:{health}");
                    Console.SetCursorPosition(25, 4);
                    Console.WriteLine($"kör:{kör}");

                }
                if (seged2 == 0)
                {
                    rajz();
                }
                ellensegrajz();
               
                    if (b == 0)
                    {
                        Random rnd = new Random();
                        l2 = rnd.Next(0, 3);
                    }
                if (gun[l2].élet > 0 || b == 1)
                {

                    b = 1;
                    Console.SetCursorPosition(gun[l2].eposition, high2);
                    Console.Write("X");
                    high2++;
                    if ((high2 == 32 && gun[l2].eposition == position - 2) ||
                        (high2 > 29 && gun[l2].eposition == position - 1) ||
                        (high2 > 28 && gun[l2].eposition == position) ||
                        (high2 > 29 && gun[l2].eposition == position + 1) ||
                        (high2 == 32 && gun[l2].eposition == position + 2))
                    {
                        health--;
                        high2 = 9;
                        b = 0;
                    }
                    else if (high2 == 32)
                    {
                        high2 = 9;
                        b = 0;
                    }
                }
                if (a == 0)
                {
                int c = 0;
                int o = 10;
                Random r = new Random();
                l = r.Next(c, o);
                }


                if (ellen[l].élet > 0 || a == 1)
                {
                    a = 1;
                    Console.SetCursorPosition(ellen[l].eposition + 2, high2);
                    Console.Write("X");
                    
                    high2++;
                   
                    if ((high2 == 32 && ellen[l].eposition == position - 2) ||
                        (high2 > 29 && ellen[l].eposition == position - 1) ||
                        (high2 > 28 && ellen[l].eposition == position) ||
                        (high2 > 29 && ellen[l].eposition == position + 1) ||
                        (high2 == 32 && ellen[l].eposition == position + 2))
                    {
                        health--;
                        high2 = 9;
                        a = 0;
                    }
                   else if (high2 == 32)
                    {
                        high2 = 9;
                        a = 0;
                    }

                }
               

                if (lov == 2)
                {
                    if (seged == 1)
                    {

                        for (int i = 0; i < bulletposition.Length; i++)
                        {
                            if (bulletposition[i] < 1)
                            {
                                bulletposition[i] = position + 2;
                                i = 100;
                                seged = 0;
                            }
                        }
                    }


                    for (int i = 0; i < bulletposition.Length; i++)
                    {


                        if (bulletposition[i] != 0 && high[i] > 2)
                        {
                            Console.SetCursorPosition(bulletposition[i], high[i] + 3);
                            Console.Write("X");
                            high[i]--;
                        }
                       
                        for (int f = 0; f < gun.Length; f++)
                        {
                         
                            if (gun[f].élet == 1 && bulletposition[i] == gun[f].eposition && high[i] == 4)
                            {
                                gun[f].élet = 0;
                                high[i] = 1;
                            }
                        }
                        for (int p = 0; p < ellen.Length; p++)
                        {
                            
                            if (bulletposition[i] >= ellen[p].eposition - 1 && bulletposition[i] < ellen[p].eposition + 6 && high[i] == 6 && pajzs[p].élet == 1)
                            {
                                pajzs[p].élet = 0;
                                high[i] = 1;
                            }
                            if ((bulletposition[i] >= ellen[p].eposition && bulletposition[i] < ellen[p].eposition + 5 && high[i] == 3 && bulletposition[i] != ellen[p].eposition + 2)||
                                (bulletposition[i] == ellen[p].eposition + 2 && high[i] == 5) && ellen[p].élet == 1)
                            {
                                ellen[p].élet = 0;
                                high[i] = 1;


                            }
                        }
                    }
                }
                int ideiglenes = 0;
                if (x == 0)
                {
                    for (int i = 0; i < ellen.Length; i++)
                    {
                        if (ellen[i].élet == 1)
                        {
                            ideiglenes++;
                        }
                    }
                }
               
                
                if (ideiglenes == 0 && x == 0)
                {
                    x = 1;
                    kör++;
                    for (int i = 0; i < ellen.Length; i++)
                    {
                        ellen[i].élet = 1;
                        pajzs[i].élet = 1;
                    }
                }
                int ideiglenes2 = 0;
                if (x == 1)
                {
                    for (int i = 0; i < ellen.Length; i++)
                    {
                        if (ellen[i].élet == 1)
                        {
                            ideiglenes2++;
                        }
                    }
                }
                if (ideiglenes2 == 0 && x == 1 && y == 0)
                {
                    gun[0].élet = 1;
                    gun[1].élet = 1;
                    gun[2].élet = 1;
                    y = 1;
                    kör++;
                    
                }
                if (kör == 3 && szaml < 20)
                {

                    szaml++;
                    Console.SetCursorPosition(58, 4);
                    Console.WriteLine("BOSS FIGHT");
                }
                if (gun[0].élet == 0 && gun[1].élet == 0 && gun[2].élet == 0 && y == 1)
                {
                    seged2 = 1;
                    Console.Clear();
                    Console.WriteLine("Győzelem!");
                }
                speed = 0;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Játék vége!");
                Console.ReadLine();
            }
        }
    }
}

