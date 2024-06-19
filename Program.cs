using System;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static int selectedTab = 0;
    private static string[] tabs = { "Get bypass words", "About", "Exit" };

    static async Task Main()
    {
        Console.CursorVisible = false;
        ConsoleKeyInfo keyInfo;

        while (true)
        {
            PrintTabs();
            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedTab = (selectedTab + 1) % tabs.Length;
            }
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedTab = (selectedTab - 1 + tabs.Length) % tabs.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                if (selectedTab == 0)
                {
                    await Bypasswords();
                }
                else if (selectedTab == 1)
                {
                    await About();
                }
                else if (selectedTab == 2)
                {
                    Environment.Exit(-1);
                    return;
                }
                Console.Clear();
            }
        }

        Console.CursorVisible = true;
    }

    static void PrintTabs()
    {
        Console.Clear();
        for (int i = 0; i < tabs.Length; i++)
        {
            if (i == selectedTab)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"-> [{tabs[i]}]");
            }
            else
            {
                Console.WriteLine(tabs[i]);
            }
            Console.ResetColor();
        }
    }

    static async Task Bypasswords()
    {
        Console.WriteLine("Enter a word:");
        string input = Console.ReadLine();
        await PrintAsync("\n\nBypassed Input -> " + BadWordsBypasser(input));
        await PrintAsync("Click enter to exit...");
        Console.ReadLine(); 
    }

    static async Task About()
    {
        await PrintAsync("This is a program used to bypass any discord servers bad words (rejection). \nThis simply just uses a discord exploit to make an invisible spot inbetween the text.\nMade by Azora | James");
        Console.ReadLine(); 
    }

    static async Task PrintAsync(string fs)
    {
        await Task.Delay(100);
        Console.WriteLine(fs);
    }

    static string BadWordsBypasser(string dsg)
    {
        var l = dsg.Length;
        var sb = new StringBuilder();
        var r = new Random();
        for (int i = 0; i < l; i++)
        {
            sb.Append(dsg[i]);
            if (i < l - 1 && r.Next(2) == 0)
            {
                sb.Append($"<sound:{i}>");
            }
        }
        return sb.ToString();
    }
}
