using static System.Random;
using System.Threading;
using static System.ConsoleColor; // Import ConsoleColor
using System;

class AtomreaktorSzimulator
{
    private int hofok;
    private double energia;
    private Random veletlen;
    private bool fut;
    private int valasztottMenupont;

    public AtomreaktorSzimulator()
    {
        veletlen = new Random();
        hofok = veletlen.Next(40, 101);
        energia = veletlen.NextDouble() * 10;
        fut = true;
        valasztottMenupont = 0;
    }

    public void Elinditas()
    {
        fut = true;
        Console.WriteLine("Az atomreaktor elindítva!");
        Frissites();

        // Külön szál indítása a felhasználói bemenet figyelésére
        Thread userInputThread = new Thread(UserInputListener);
        userInputThread.Priority = ThreadPriority.BelowNormal; // Beállítjuk a szál prioritását
        userInputThread.Start();

        while (fut)
        {
            Thread.Sleep(1000);
            hofok += veletlen.Next(1, 5);
            energia += veletlen.NextDouble() * 0.1;
            Frissites();

            if (hofok > 100)
            {
                Console.WriteLine("A reaktor felrobbant!");
                fut = false;
            }
        }

        valasztottMenupont = 0; // visszaállítjuk az aktív menüpontot
    }


    public void UserInputListener()
    {
        while (fut)
        {
            var key = Console.ReadKey(true);
            if (key.KeyChar == '2')
            {
                if (hofok > 70)
                {
                    Console.WriteLine("A reaktor túl forró a leállításhoz! Hűtse le vagy válassza a hűtővíz beengedését a leállításhoz.");
                    Console.WriteLine("Nyomja meg a '5' billentyűt a hűtővíz beengedéséhez és a leállításhoz.");
                    Thread.Sleep(3000);
                }
                else
                {
                    Leallitas();
                }
            }
            else if (key.KeyChar == '5')
            {
                HutovizBeengedese();
            }
        }
    }



    public void Leallitas()
    {
        if (hofok < 70)
        {
            fut = false;
            Console.WriteLine("Az atomreaktor leállítva.");
        }
        else
        {
            Console.WriteLine("A reaktor túl forró a leállításhoz! Hűtse le vagy válassza a hűtővíz beengedését a leállításhoz.");
            Console.WriteLine("Nyomja meg a '5' billentyűt a hűtővíz beengedéséhez és a leállításhoz.");
            var keyInfo = Console.ReadKey(true);
            if (keyInfo.KeyChar == '5')
            {
                HutovizBeengedese();
                fut = false;
                Console.WriteLine("A reaktor leállítva hűtővízzel.");
            }
        }

        valasztottMenupont = 0; // visszaállítjuk az aktív menüpontot
    }

    public void EnergiaMennyiseg()
    {
        Console.WriteLine($"Generált energia: {energia:F1} GW"); // Fixed closing bracket
    }
    public void Hofok()
    {
        Console.WriteLine($"Hőmérséklet: {hofok} fok"); // Use string interpolation to display the temperature
    }

    public void HutovizBeengedese()
    {
        hofok = 40;
        Console.WriteLine("A reaktor lehűtve.");
    }

    private void Frissites()
    {
        Console.Clear();

        // Menüpontok megjelenítése
        for (int i = 1; i <= 6; i++)
        {
            if (i == valasztottMenupont)
            {
                if (i == 2 && valasztottMenupont == 1) // Ha az első menüpontot választottad ki, és ez a második menüpont, akkor is zöldre állítjuk
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Minden kiválasztott menüpont zöld legyen
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine($"{i}. {MenupontNev(i)}");
        }

        // Hőmérséklet és energia megjelenítése
        Hofok(); // Hőmérséklet frissítése a megjelenítés előtt
        EnergiaMennyiseg(); // Energia frissítése a megjelenítés előtt
    }

    private string MenupontNev(int menupont)
    {
        switch (menupont)
        {
            case 1: return "Elindítás";
            case 2: return "Leállítás";
            case 3: return "Generált energia mennyisége";
            case 4: return "Hőfok";
            case 5: return "Hűtővíz beengedése";
            case 6: return "Kilépés";
            default: return "";
        }
    }

    public static void Main(string[] args)
    {
        var szimulator = new AtomreaktorSzimulator();

        while (true)
        {
            Console.CursorVisible = false; // Elrejti a kurzort

            szimulator.Frissites(); // Frissíti a kijelzőt

            ConsoleKeyInfo keyInfo = Console.ReadKey(true); // Billentyűnyomás leolvasása

            // Választás kiértékelése
            switch (keyInfo.KeyChar)
            {
                case '1':
                    szimulator.valasztottMenupont = 1;
                    szimulator.Elinditas();
                    szimulator.Frissites(); // Frissíti a kijelzőt
                    break;
                case '2':
                    szimulator.valasztottMenupont = 2;
                    szimulator.Leallitas();
                    szimulator.Frissites(); // Frissíti a kijelzőt
                    break;
                case '3':
                    szimulator.valasztottMenupont = 3;
                    szimulator.EnergiaMennyiseg();
                    break;
                case '4':
                    szimulator.valasztottMenupont = 4;
                    szimulator.Hofok(); // Hőmérséklet megjelenítése
                    break;
                case '5':
                    szimulator.valasztottMenupont = 5;
                    szimulator.HutovizBeengedese();
                    szimulator.Frissites(); // Frissíti a kijelzőt
                    break;
                case '6':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Érvénytelen bemenet!"); // Érvénytelen bemenet kezelése
                    break;
            }
        }
    }
}