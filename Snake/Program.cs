using System;

namespace Snake
{
    struct globalVars
    {
        public static int getWidth()
        {
            return width;
        }
        public static int getHeight()
        {
            return height;
        }
        public static void setX(int value)
        {
            x = value;
        }
        public static int getX()
        {
            return x;
        }

        public static int getLastX()
        {
            return lastX;
        }

        public static void setLastX(int value)
        {
            lastX = value;
        }

        public static int getLastY()
        {
            return lastY;
        }

        public static void setLastY(int value)
        {
            lastY = value;
        }
        public static void setY(int value)
        {
            y = value;
        }
        public static int getY()
        {
            return y;
        }

        public static double getSpeed()
        {
            return speed;
        }

        public static void setSpeed(double value)
        {
            speed = value;
        }
        public static void setFriutX()
        {
            Random rnd = new Random();
            friutX = rnd.Next(1, globalVars.getWidth() / 2) * 2 - 1;
            for(int i = 0; i < nTail; ++i)
            {
                if (friutX == tailX[i])
                    setFriutX();                    
            }
        }
        public static int getFriutX()
        {
            return friutX;
        }
        public static void setFriutY()
        {
            Random rnd = new Random();
            fruitY = rnd.Next(1, globalVars.getHeight() - 2);
            for (int i = 0; i < nTail; ++i)
            {
                if (fruitY == tailY[i])
                    setFriutY();
            }
        }
        public static int getFriutY()
        {
            return fruitY;
        }
        public static void setScore(int value)
        {
            score = value;
        }
        public static int getScore()
        {
            return score;
        }
        public static void setDir(eDirection value)
        {
            dir = value;
        }
        public static eDirection getDir()
        {
            return dir;
        }
        public static bool isGameOver()
        {
            return gameOver;
        }
        public static void setGameOver(bool value)
        {
            gameOver = value;
        }
        public static int getNTail()
        {
            return nTail;
        }
        public static void setNTail(int value)
        {
            nTail = value;
        }

        public static int getTailX(int index)
        {
            return tailX[index];
        }
        public static void setTailX(int index, int value)
        {
            tailX[index] = value;
        }
        public static int getTailY(int index)
        {
            return tailY[index];
        }
        public static void setTailY(int index, int value)
        {
            tailY[index] = value;
        }
        public enum eDirection { STOP, LEFT, RIGHT, UP, DOWN }; // состояния движения самой змейки
        public static eDirection dir;
        private static bool gameOver;
        private const int width = 41; // размеры поля
        private const int height = 21; // const по дефолту static, поэтому не надо писать модификатор static
        private static int x, y, lastX, lastY, friutX, fruitY, score;// положение змейки и фрукта; score - общий счёт
        private static double speed;
        private static int[] tailX = new int[300]; // массив хранит координаты каждого элемента хвоста
        private static int[] tailY = new int[300];
        private static int nTail = 0; // кол-во элементов в хвосте
    }
    class Program
    {
        public static void Setup()
        {
            globalVars.setGameOver(false);
            globalVars.setDir(globalVars.eDirection.STOP);
            globalVars.setX(globalVars.getWidth() / 2 - 1);
            globalVars.setY(globalVars.getHeight() / 2 - 1);
            globalVars.setFriutX();
            globalVars.setFriutY();
            globalVars.setScore(0);
            globalVars.setNTail(0);
            globalVars.setLastX(globalVars.getWidth() / 2 - 5);
            globalVars.setLastY(globalVars.getHeight() / 2 - 5);
            globalVars.setSpeed(10);
        }

        public static void game()
        {
            Console.Clear();
            Setup();
            for (int i = 0; i < globalVars.getWidth(); ++i) // рисует верхнюю границу поля
            {
                if (i == 0)
                {
                    Console.Write('╔');
                    continue;
                }
                else if (i == globalVars.getWidth() - 1)
                {
                    Console.Write('╗');
                    continue;
                }
                Console.Write('═');
            }
            Console.Write('\n');
            for (int j = 0; j < globalVars.getHeight() - 2; ++j) // рисует левую и правую границу поля
            {
                for (int i = 0; i < globalVars.getWidth(); ++i)
                {
                    if (i == 0 || i == globalVars.getWidth() - 1)
                    {
                        Console.Write('║');
                        continue;
                    }
                    Console.Write(' ');
                }
                Console.Write('\n');
            }
            for (int i = 0; i < globalVars.getWidth(); ++i) // рисует нижнюю границу поля
            {
                if (i == 0)
                {
                    Console.Write('╚');
                    continue;
                }
                else if (i == globalVars.getWidth() - 1)
                {
                    Console.Write('╝');
                    continue;
                }
                Console.Write('═');
            }
            while (!globalVars.isGameOver())
            {
                Draw();
                Input();
                Logic();
                System.Threading.Thread.Sleep((int)(1000 / globalVars.getSpeed())); // приостанавливает поток на заданное кол-во мс
            }
            Console.Clear();
            Console.WriteLine("Для продолжения нажмите Enter, для выхода Escape: "); 
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    game();
                else if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
            }
        }
        public static void Draw()
        {
            Console.SetCursorPosition(globalVars.getX(), globalVars.getY());
            Console.Write('*');
            Console.SetCursorPosition(globalVars.getLastX(), globalVars.getLastY());
            Console.Write(' ');
            Console.SetCursorPosition(globalVars.getFriutX(), globalVars.getFriutY());
            Console.Write('F');
            Console.SetCursorPosition(0, globalVars.getHeight());
            Console.Write($"Score: {globalVars.getScore()}");
        }
        public static void Input()
        {
            if (Console.KeyAvailable) // проверка на то нажата клавиша или нет
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        globalVars.setDir(globalVars.eDirection.LEFT);
                        break;
                    case ConsoleKey.RightArrow:
                        globalVars.setDir(globalVars.eDirection.RIGHT);
                        break;
                    case ConsoleKey.UpArrow:
                        globalVars.setDir(globalVars.eDirection.UP);
                        break;
                    case ConsoleKey.DownArrow:
                        globalVars.setDir(globalVars.eDirection.DOWN);
                        break;
                }
            }
        }
        public static void Logic()
        {
            int prevX = globalVars.getTailX(0);
            int prevY = globalVars.getTailY(0);
            globalVars.setTailX(0, globalVars.getX());
            globalVars.setTailY(0, globalVars.getY());
            int prev2X, prev2Y;
            globalVars.setLastX(globalVars.getTailX(0));
            globalVars.setLastY(globalVars.getTailY(0));
            for (int i = 1; i < globalVars.getNTail(); ++i)
            {
                prev2X = globalVars.getTailX(i);
                prev2Y = globalVars.getTailY(i);
                globalVars.setTailX(i, prevX);
                globalVars.setTailY(i, prevY);
                prevX = prev2X;
                prevY = prev2Y;
                globalVars.setLastX(globalVars.getTailX(i));
                globalVars.setLastY(globalVars.getTailY(i));
            }
            switch (globalVars.getDir())
            {
                case globalVars.eDirection.LEFT:
                    globalVars.setX(globalVars.getX() - 2);
                    break;
                case globalVars.eDirection.RIGHT:
                    globalVars.setX(globalVars.getX() + 2);
                    break;
                case globalVars.eDirection.UP:
                    globalVars.setY(globalVars.getY() - 1);
                    break;
                case globalVars.eDirection.DOWN:
                    globalVars.setY(globalVars.getY() + 1);
                    break;
            }
            for (int i = 0; i < globalVars.getNTail(); ++i) // проверка на столкновение с хвостом
            {
                if (globalVars.getTailX(i) == globalVars.getX() && globalVars.getTailY(i) == globalVars.getY())
                    globalVars.setGameOver(true);
            }
            if (globalVars.getX() > globalVars.getWidth() - 2) // проверка на выход за границы поля
                globalVars.setX(1);
            else if (globalVars.getX() < 1)
                globalVars.setX(globalVars.getWidth() - 2);
            else if (globalVars.getY() > globalVars.getHeight() - 2)
                globalVars.setY(1);
            else if (globalVars.getY() < 1)
                globalVars.setY(globalVars.getHeight() - 2);
            if (globalVars.getX() == globalVars.getFriutX() && globalVars.getY() == globalVars.getFriutY())
            {
                globalVars.setSpeed(globalVars.getSpeed() + 0.5);
                globalVars.setNTail(globalVars.getNTail() + 1);
                globalVars.setScore(globalVars.getScore() + 10);
                globalVars.setFriutX();
                globalVars.setFriutY();
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false; // скрывает на консоли курсор
            Console.SetWindowSize(globalVars.getWidth() + 8, globalVars.getHeight() + 2);
            game();    
        }
    }
}