using System;

namespace matrix
{
    class Program
    {
        static Random rand = new Random();

        static char AsciiCharacter
        {
            get
            {
                int t = rand.Next(10);
                if (t <= 2)
                    // Returns a number
                    return (char)('0' + rand.Next(10));
                else if (t <= 4)
                    // Returns a small letter
                    return (char)('a' + rand.Next(27));
                else if (t <= 6)
                    // Returns a capital letter
                    return (char)('A' + rand.Next(27));
                else
                    // Returns any ascii character
                    return (char)(rand.Next(32, 255));
            }
        }

        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WindowLeft = Console.WindowTop = 0;
            Console.WindowHeight = Console.BufferHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.BufferWidth = Console.LargestWindowWidth;
            Console.WriteLine("Hit Any Key To Continue");
            Console.ReadKey();
            Console.CursorVisible = false;

            int width, height;
            int[] y;

            Initialize(out width, out height, out y);

            while (true)
                UpdateAllColumns(width, height, y);
        }


        private static void UpdateAllColumns(int width, int height, int[] y)
        {
            int x;

            for (x = 0; x < width; ++x)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(x, y[x]);
                Console.Write(AsciiCharacter);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                int temp = y[x] - 2;
                Console.SetCursorPosition(x, inScreenYPosition(temp, height));
                Console.Write(AsciiCharacter);

                int temp1 = y[x] - 20;
                Console.SetCursorPosition(x, inScreenYPosition(temp1, height));
                Console.Write(' ');

                y[x] = inScreenYPosition(y[x] + 1, height);
            }

            // F5 to reset, F11 to pause and unpause
            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.F5)
                    Initialize(out width, out height, out y);
                if (Console.ReadKey().Key == ConsoleKey.F11)
                    System.Threading.Thread.Sleep(1);
            }

        }

        public static int inScreenYPosition(int yPosition, int height)
        {
            if (yPosition < 0)
                return yPosition + height;
            else if (yPosition < height)
                return yPosition;
            else
                return 0;
        }

        private static void Initialize(out int width, out int height, out int[] y)
        {
            height = Console.WindowHeight;
            width = Console.WindowWidth - 1;

            y = new int[width];

            Console.Clear();
            for (int x = 0; x < width; ++x)
            {
                y[x] = rand.Next(height);
            }
        }
    }
}