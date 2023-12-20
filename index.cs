using System;

class AutoDrivingCarSimulator
{
    public static string SimulateAutoDrivingCar(int width, int height, int startX, int startY, char startOrientation, string commands)
    {
        string orientations = "NESW";
        int[,] movements = new int[,] { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

        int x = startX, y = startY;
        int orientationIndex = orientations.IndexOf(startOrientation);

        foreach (char command in commands)
        {
            switch (command)
            {
                case 'L':
                    orientationIndex = (orientationIndex + 3) % 4;
                    break;
                case 'R':
                    orientationIndex = (orientationIndex + 1) % 4;
                    break;
                case 'F':
                    int newX = x + movements[orientationIndex, 0];
                    int newY = y + movements[orientationIndex, 1];
                    if (newX >= 0 && newX < width && newY >= 0 && newY < height)
                    {
                        x = newX;
                        y = newY;
                    }
                    break;
            }
        }

        return $"{x} {y} {orientations[orientationIndex]}";
    }

    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);

        string[] startPosition = Console.ReadLine().Split(' ');
        int startX = int.Parse(startPosition[0]);
        int startY = int.Parse(startPosition[1]);
        char startOrientation = char.Parse(startPosition[2]);

        string commands = Console.ReadLine();

        Console.WriteLine(SimulateAutoDrivingCar(width, height, startX, startY, startOrientation, commands));
    }
}
