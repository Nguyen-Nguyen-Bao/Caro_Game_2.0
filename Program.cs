using System.Text;
namespace Caro_Game_2._0;

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;
        static bool CREATE_TABLE(out string[,] CaroTable, out int n)
        {
            int u = 15;
            string[,] CaroTable0 = new string[u, u];
            int row = 0, col = 0;
            do
            {
                col = 0;
                do
                {
                    if (row == 0)
                    {
                        CaroTable0[row, col] = $"{col}";
                    }
                    else if (col == 0)
                    {
                        CaroTable0[row, col] = $"{row}";
                    }
                    else
                    {
                        CaroTable0[row, col] = "-";
                    }
                    ++col;
                }
                while (col < u);
                ++row;
            }
            while (row < u);
            n = u;
            CaroTable = CaroTable0;
            return true;
        }
        CREATE_TABLE(out string[,] CaroTable, out int n);
        CARO();
        static void CARO()
        {
            int j = 0, r = 0, player = 1;
            do
            {
                Console.WriteLine("Bấm Q để tắt, Bấm phím bất kỳ để bắt đầu!");
                string p = Console.ReadLine();
                if (p == "Q" || p == "q")
                {
                    Environment.Exit(0);
                }
                else
                {
                    CREATE_TABLE(out string[,] CaroTable, out int n);
                    do
                    {
                        HIENTHI(CaroTable, n);
                        Console.WriteLine($"Player {player}");
                        Console.Write("Đánh hàng và cột: ");
                        string[] RowCol = Console.ReadLine().Split(" ");
                        Array.Resize(ref RowCol, 2);
                        if (!(CHECKCHIENTHANG_DOC(CaroTable, n)))
                        {
                            if (DATA_TYPE_CHECK(CaroTable, n, RowCol))
                            {
                                int row = Convert.ToInt16(RowCol[0]), col = Convert.ToInt16(RowCol[1]);
                                if (player == 1)
                                {
                                    CaroTable[row, col] = "X";
                                    ++player;
                                    if (CHECKCHIENTHANG_DOC(CaroTable, n))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("NGƯỜI CHƠI 1 CHIẾN THẮNG !!!");
                                        Console.ResetColor();
                                        TOADOCHIENTHANG_DOC(CaroTable, n, out int[] Rows, out int[] Cols);
                                        HIENTHICHIENTHANG(CaroTable, n, Rows, Cols);
                                        break;
                                    }
                                    else if (CHECKCHIENTHANH_NGANG(CaroTable, n))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("NGƯỜI CHƠI 1 CHIẾN THẮNG !!!");
                                        Console.ResetColor();
                                        TOADOCHIENTHANH_NGANG(CaroTable, n, out int[] Rows, out int[] Cols);
                                        HIENTHICHIENTHANG(CaroTable, n, Rows, Cols);
                                        break;
                                    }
                                    else if (CHECKCHIENTHANG_CHEO1(CaroTable, n))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("NGƯỜI CHƠI 1 CHIẾN THẮNG !!!");
                                        Console.ResetColor();
                                        TOADOCHIENTHANG_CHEO1(CaroTable, n, out int[] Rows, out int[] Cols);
                                        HIENTHICHIENTHANG(CaroTable, n, Rows, Cols);
                                        break;
                                    }
                                    else if (CHECKCHIENTHANG_CHEO2(CaroTable, n))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("NGƯỜI CHƠI 1 CHIẾN THẮNG !!!");
                                        Console.ResetColor();
                                        TOADOCHIENTHANG_CHEO2(CaroTable, n, out int[] Rows, out int[] Cols);
                                        HIENTHICHIENTHANG(CaroTable, n, Rows, Cols);
                                        break;
                                    }
                                }
                                else if (player == 2)
                                {
                                    CaroTable[row, col] = "O";
                                    --player;
                                    if (CHECKCHIENTHANG_DOC(CaroTable, n))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("NGƯỜI CHƠI 2 CHIẾN THẮNG !!!");
                                        Console.ResetColor();
                                        TOADOCHIENTHANG_DOC(CaroTable, n, out int[] Rows, out int[] Cols);
                                        HIENTHICHIENTHANG(CaroTable, n, Rows, Cols);
                                        break;
                                    }
                                    else if (CHECKCHIENTHANH_NGANG(CaroTable, n))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("NGƯỜI CHƠI 2 CHIẾN THẮNG !!!");
                                        Console.ResetColor();
                                        TOADOCHIENTHANH_NGANG(CaroTable, n, out int[] Rows, out int[] Cols);
                                        HIENTHICHIENTHANG(CaroTable, n, Rows, Cols);
                                        break;
                                    }
                                    else if (CHECKCHIENTHANG_CHEO1(CaroTable, n))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("NGƯỜI CHƠI 2 CHIẾN THẮNG !!!");
                                        Console.ResetColor();
                                        TOADOCHIENTHANG_CHEO1(CaroTable, n, out int[] Rows, out int[] Cols);
                                        HIENTHICHIENTHANG(CaroTable, n, Rows, Cols);
                                        break;
                                    }
                                    else if (CHECKCHIENTHANG_CHEO2(CaroTable, n))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("NGƯỜI CHƠI 2 CHIẾN THẮNG !!!");
                                        Console.ResetColor();
                                        TOADOCHIENTHANG_CHEO2(CaroTable, n, out int[] Rows, out int[] Cols);
                                        HIENTHICHIENTHANG(CaroTable, n, Rows, Cols);
                                        break;
                                    }
                                }
                                HIENTHI(CaroTable, n);
                            }
                            else
                            {
                                HIENTHI(CaroTable, n);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("*Dữ liệu không hợp lệ");
                                Console.ResetColor();
                            }
                        }
                    }
                    while (j < 1);
                }
            }
            while (r < 1);
        }
        static void HIENTHI(string[,] CaroTable, int n)
        {
            int row = 0, col = 0;
            do
            {
                col = 0;
                do
                {
                    if (row == 0 && col >= 10)
                    {
                        Console.Write($" {CaroTable[row, col]}");
                    }
                    else if (col == 0 && row < 10)
                    {
                        Console.Write($"  {CaroTable[row, col]}");
                    }
                    else if (col == 0 && row >= 10)
                    {
                        Console.Write($" {CaroTable[row, col]}");
                    }
                    else
                    {
                        if (CaroTable[row, col] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"  {CaroTable[row, col]}");
                            Console.ResetColor();
                        }
                        else if (CaroTable[row, col] == "O")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"  {CaroTable[row, col]}");
                            Console.ResetColor();
                        }
                        else Console.Write($"  {CaroTable[row, col]}");
                    }
                    ++col;
                }
                while (col < n);
                Console.WriteLine();
                ++row;
            }
            while (row < n);
        }
        static bool DATA_TYPE_CHECK(string[,] CaroTable, int n, string[] RowCol)
        {
            int row = 0, col = 0;
            do
            {
                col = 0;
                do
                {
                    if (RowCol[0] == $"{row}" && RowCol[1] == $"{col}")
                    {
                        return true;
                    }
                    ++col;
                }
                while (col < n);
                ++row;
            }
            while (row < n);
            return false;
        }
        static bool CHECKCHIENTHANG_DOC(string[,] CaroTable, int n)
        {
            int row = 0, col = 0, checkX = 0, checkO = 0;
            do
            {
                row = 0;
                do
                {
                    if (CaroTable[row, col] == "X")
                    {
                        ++checkX;
                        checkO = 0;
                        if (checkX == 5) return true;
                    }
                    else if (CaroTable[row, col] == "O")
                    {
                        ++checkO;
                        checkX = 0;
                        if (checkO == 5) return true;
                    }
                    else
                    {
                        checkX = 0;
                        checkO = 0;
                    }
                    ++row;
                }
                while (row < n);
                ++col;
            }
            while (col < n);
            return false;
        }
        static bool CHECKCHIENTHANH_NGANG(string[,] CaroTable, int n)
        {
            int row = 0, col = 0, checkX = 0, checkO = 0;
            do
            {
                col = 0;
                do
                {
                    if (CaroTable[row, col] == "X")
                    {
                        checkO = 0;
                        ++checkX;
                        if (checkX == 5) return true;
                    }
                    else if (CaroTable[row, col] == "O")
                    {
                        checkX = 0;
                        ++checkO;
                        if (checkO == 5) return true;
                    }
                    else
                    {
                        checkX = 0;
                        checkO = 0;
                    }
                    ++col;
                }
                while (col < n);
                ++row;
            }
            while (row < n);
            return false;
        }
        static bool CHECKCHIENTHANG_CHEO1(string[,] CaroTable, int n)
        {
            int row = 1, col = 1, i = 1, checkX = 0, checkO = 0;
            do
            {
                do
                {
                    if (CaroTable[row, col] == "X")
                    {
                        checkO = 0;
                        ++checkX;
                        if (checkX == 2) return true;
                    }
                    else if (CaroTable[row, col] == "O")
                    {
                        checkX = 0;
                        ++checkO;
                        if (checkO == 2) return true;
                    }
                    else
                    {
                        checkX = 0;
                        checkO = 0;
                    }
                    ++row;
                    ++col;
                }
                while (row < n);
                ++i;
                row = i;
                col = 1;
            }
            while (row < n);
            row = 1; col = 1; i = 1; checkX = 0; checkO = 0;
            do
            {
                do
                {
                    if (CaroTable[row, col] == "X")
                    {
                        checkO = 0;
                        ++checkX;
                        if (checkX == 2) return true;
                    }
                    else if (CaroTable[row, col] == "O")
                    {
                        checkX = 0;
                        ++checkO;
                        if (checkO == 2) return true;
                    }
                    else
                    {
                        checkX = 0;
                        checkO = 0;
                    }
                    ++row;
                    ++col;
                }
                while (col < n);
                ++i;
                row = 1;
                col = i;
            }
            while (col < n);
            return false;
        }
        static bool CHECKCHIENTHANG_CHEO2(string[,] CaroTable, int n)
        {
            int row = 1, col = 1, i = 1, checkX = 0, checkO = 0;
            do
            {
                do
                {
                    if (CaroTable[row, col] == "X")
                    {
                        checkO = 0;
                        ++checkX;
                        if (checkX == 2) return true;
                    }
                    else if (CaroTable[row, col] == "O")
                    {
                        checkX = 0;
                        ++checkO;
                        if (checkO == 2) return true;
                    }
                    else
                    {
                        checkX = 0;
                        checkO = 0;
                    }
                    --row;
                    ++col;
                }
                while (row > 0);
                ++i;
                row = i;
                col = 1;
            }
            while (i < n);
            row = 14; col = 0; i = 0; checkX = 0; checkO = 0;
            do
            {
                do
                {
                    if (CaroTable[row, col] == "X")
                    {
                        checkO = 0;
                        ++checkX;
                        if (checkX == 2) return true;
                    }
                    else if (CaroTable[row, col] == "O")
                    {
                        checkX = 0;
                        ++checkO;
                        if (checkO == 2) return true;
                    }
                    else
                    {
                        checkX = 0;
                        checkO = 0;
                    }
                    --row;
                    ++col;
                }
                while (col < n);
                ++i;
                row = 14;
                col = i;
            }
            while (col < n);
            return false;
        }
        static void TOADOCHIENTHANG_DOC(string[,] CaroTable, int n, out int[] Rows, out int[] Cols)
        {
            int row = 0, col = 0, x = 0, o = 0;
            int[] RowsX = new int[5];
            int[] ColsX = new int[5];
            int[] RowsO = new int[5];
            int[] ColsO = new int[5];
            do
            {
                row = 0;
                do
                {
                    if (CaroTable[row, col] == "X")
                    {
                        RowsX[x] = row;
                        ColsX[x] = col;
                        ++x;
                        o = 0;
                        if (x == 2)
                        {
                            RowsX = RowsO;
                            ColsX = ColsO;
                            break;
                        }
                    }
                    else if (CaroTable[row, col] == "O")
                    {
                        RowsX[o] = row;
                        ColsX[o] = col;
                        ++o;
                        x = 0;
                        if (o == 2)
                        {
                            RowsO = RowsX;
                            ColsO = ColsX;
                            break;
                        }
                    }
                    else
                    {
                        x = 0;
                        o = 0;
                    }
                    ++row;
                }
                while (row < n);
                if (x == 2 || o == 2)
                {
                    break;
                }
                ++col;
            }
            while (col < n);
            Rows = RowsX;
            Cols = ColsX;
        }
        static void HIENTHICHIENTHANG(string[,] CaroTable, int n, int[] Rows, int[] Cols)
        {
            int row = 0, col = 0, i = 0;
            do
            {
                col = 0;
                do
                {
                    if (row == 0 && col >= 10)
                    {
                        Console.Write($" {CaroTable[row, col]}");
                    }
                    else if (col == 0 && row < 10)
                    {
                        Console.Write($"  {CaroTable[row, col]}");
                    }
                    else if (col == 0 && row >= 10)
                    {
                        Console.Write($" {CaroTable[row, col]}");
                    }
                    else
                    {
                        if (row == Rows[i] && col == Cols[i] && CaroTable[row, col] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            ;
                            Console.Write($"  {CaroTable[row, col]}");
                            Console.ResetColor();
                            ++i;
                        }
                        else if (row == Rows[i] && col == Cols[i] && CaroTable[row, col] == "O")
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"  {CaroTable[row, col]}");
                            Console.ResetColor();
                            ++i;
                        }
                        else if (CaroTable[row, col] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write($"  {CaroTable[row, col]}");
                            Console.ResetColor();
                        }
                        else if (CaroTable[row, col] == "O")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write($"  {CaroTable[row, col]}");
                            Console.ResetColor();
                        }
                        else Console.Write($"  {CaroTable[row, col]}");
                    }
                    ++col;
                }
                while (col < n);
                Console.WriteLine();
                ++row;
            }
            while (row < n);
        }
        static void TOADOCHIENTHANH_NGANG(string[,] CaroTable, int n, out int[] Rows, out int[] Cols)
        {
            int row = 0, col = 0, x = 0, o = 0;
            int[] RowsX = new int[5];
            int[] ColsX = new int[5];
            int[] RowsO = new int[5];
            int[] ColsO = new int[5];
            do
            {
                col = 0;
                do
                {
                    if (CaroTable[row, col] == "X")
                    {
                        RowsX[x] = row;
                        ColsX[x] = col;
                        ++x;
                        o = 0;
                        if (x == 2)
                        {
                            RowsX = RowsO;
                            ColsX = ColsO;
                            break;
                        }
                    }
                    else if (CaroTable[row, col] == "O")
                    {
                        RowsX[o] = row;
                        ColsX[o] = col;
                        ++o;
                        x = 0;
                        if (o == 2)
                        {
                            RowsO = RowsX;
                            ColsO = ColsX;
                            break;
                        }
                    }
                    else
                    {
                        x = 0;
                        o = 0;
                    }
                    ++col;
                }
                while (col < n);
                if (x == 2 || o == 2)
                {
                    break;
                }
                ++row;
            }
            while (row < n);
            Rows = RowsX;
            Cols = ColsX;

        }
        static void TOADOCHIENTHANG_CHEO1(string[,] CaroTable, int n, out int[] Rows, out int[] Cols)
        {
            int row = 0, col = 0, x = 0, o = 0, i = 0;
            int[] RowsX = new int[5];
            int[] ColsX = new int[5];
            int[] RowsO = new int[5];
            int[] ColsO = new int[5];
            do
            {
                do
                {
                    if (CaroTable[row, col] == "X")
                    {
                        RowsX[x] = row;
                        ColsX[x] = col;
                        ++x;
                        o = 0;
                        if (x == 2)
                        {
                            RowsX = RowsO;
                            ColsX = ColsO;
                            break;
                        }
                    }
                    else if (CaroTable[row, col] == "O")
                    {
                        RowsX[o] = row;
                        ColsX[o] = col;
                        ++o;
                        x = 0;
                        if (o == 2)
                        {
                            RowsO = RowsX;
                            ColsO = ColsX;
                            break;
                        }
                    }
                    else
                    {
                        x = 0;
                        o = 0;
                    }
                    ++row;
                    ++col;
                }
                while (row < n);
                if (x == 2 || o == 2)
                {
                    break;
                }
                ++i;
                row = i;
                col = 1;
            }
            while (row < n);
            row = 1; col = 1; i = 1; x = 0; o = 0;
            do
            {
                do
                {
                    if (CaroTable[row, col] == "X")
                    {
                        RowsX[x] = row;
                        ColsX[x] = col;
                        ++x;
                        o = 0;
                        if (x == 2)
                        {
                            RowsX = RowsO;
                            ColsX = ColsO;
                            break;
                        }
                    }
                    else if (CaroTable[row, col] == "O")
                    {
                        RowsX[o] = row;
                        ColsX[o] = col;
                        ++o;
                        x = 0;
                        if (o == 2)
                        {
                            RowsO = RowsX;
                            ColsO = ColsX;
                            break;
                        }
                    }
                    else
                    {
                        x = 0;
                        o = 0;
                    }
                    ++row;
                    ++col;
                }
                while (col < n);
                if (x == 2 || o == 2)
                {
                    break;
                }
                ++i;
                row = 1;
                col = i;
            }
            while (col < n);
            Rows = RowsX;
            Cols = ColsX;
        }
        static void TOADOCHIENTHANG_CHEO2(string[,] CaroTable, int n, out int[] Rows, out int[] Cols)
        {
            int row = 0, col = 0, x = 0, o = 0, i = 0;
            int[] RowsX = new int[5];
            int[] ColsX = new int[5];
            int[] RowsO = new int[5];
            int[] ColsO = new int[5];
            do
            {
                do
                {
                    if (CaroTable[row, col] == "X")
                    {
                        RowsX[x] = row;
                        ColsX[x] = col;
                        ++x;
                        o = 0;
                        if (x == 2)
                        {
                            RowsX = RowsO;
                            ColsX = ColsO;
                            break;
                        }
                    }
                    else if (CaroTable[row, col] == "O")
                    {
                        RowsX[o] = row;
                        ColsX[o] = col;
                        ++o;
                        x = 0;
                        if (o == 2)
                        {
                            RowsO = RowsX;
                            ColsO = ColsX;
                            break;
                        }
                    }
                    else
                    {
                        x = 0;
                        o = 0;
                    }
                    ++row;
                    --col;
                }
                while (col > 0);
                if (x == 2 || o == 2)
                {
                    break;
                }
                ++i;
                col = i;
                row = 1;
            }
            while (i < n);
            row = 0; col = 14; i = 0; x = 0; o = 0;
            do
            {
                do
                {
                    if (CaroTable[row, col] == "X")
                    {
                        RowsX[x] = row;
                        ColsX[x] = col;
                        ++x;
                        o = 0;
                        if (x == 2)
                        {
                            RowsX = RowsO;
                            ColsX = ColsO;
                            break;
                        }
                    }
                    else if (CaroTable[row, col] == "O")
                    {
                        RowsX[o] = row;
                        ColsX[o] = col;
                        ++o;
                        x = 0;
                        if (o == 2)
                        {
                            RowsO = RowsX;
                            ColsO = ColsX;
                            break;
                        }
                    }
                    else
                    {
                        x = 0;
                        o = 0;
                    }
                    ++row;
                    --col;
                }
                while (row < n);
                if (x == 2 || o == 2)
                {
                    break;
                }
                col = 14;
                ++i;
                row = i;
            }
            while (i < n);
            Rows = RowsX;
            Cols = ColsX;
        }
    }
}

