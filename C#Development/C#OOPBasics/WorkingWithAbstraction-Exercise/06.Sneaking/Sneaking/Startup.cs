namespace Sneaking
{
    using System;

    public class Startup
    {
        private static char[][] room;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            room = new char[n][];

            for (var row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];

                for (var col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }

            var moves = Console.ReadLine().ToCharArray();

            var samPosition = new int[2];

            for (var row = 0; row < room.Length; row++)
            {
                for (var col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }

            foreach (var i in moves)
            {
                for (var row = 0; row < room.Length; row++)
                {
                    for (var col = 0; col < room[row].Length; col++)
                    {
                        if (room[row][col] == 'b')
                        {
                            if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                            {
                                room[row][col] = '.';
                                room[row][col + 1] = 'b';
                                col++;
                            }
                            else
                            {
                                room[row][col] = 'd';
                            }
                        }
                        else if (room[row][col] == 'd')
                        {
                            if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                            {
                                room[row][col] = '.';
                                room[row][col - 1] = 'd';
                            }
                            else
                            {
                                room[row][col] = 'b';
                            }
                        }
                    }
                }

                var getEnemy = new int[2];

                for (var j = 0; j < room[samPosition[0]].Length; j++)
                {
                    if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                    {
                        getEnemy[0] = samPosition[0];
                        getEnemy[1] = j;
                    }
                }

                if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");

                    foreach (var row in room)
                    {
                        foreach (var col in row)
                        {
                            Console.Write(col);
                        }

                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }
                else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");

                    foreach (var row in room)
                    {
                        foreach (var col in row)
                        {
                            Console.Write(col);
                        }

                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }


                room[samPosition[0]][samPosition[1]] = '.';
                switch (i)
                {
                    case 'U':
                        samPosition[0]--;
                        break;
                    case 'D':
                        samPosition[0]++;
                        break;
                    case 'L':
                        samPosition[1]--;
                        break;
                    case 'R':
                        samPosition[1]++;
                        break;
                    default:
                        break;
                }

                room[samPosition[0]][samPosition[1]] = 'S';

                for (var j = 0; j < room[samPosition[0]].Length; j++)
                {
                    if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                    {
                        getEnemy[0] = samPosition[0];
                        getEnemy[1] = j;
                    }
                }

                if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
                {
                    room[getEnemy[0]][getEnemy[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");

                    foreach (var row in room)
                    {
                        foreach (var col in row)
                        {
                            Console.Write(col);
                        }

                        Console.WriteLine();
                    }

                    Environment.Exit(0);
                }
            }
        }
    }
}
