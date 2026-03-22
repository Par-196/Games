using Chess;
using Games.Models.Enums;
using Snake;
using Snake.Models.Enums;
using System;

namespace Games
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            bool menuExit = false;
            
            while (!exit)
            {
                Console.WriteLine("1.Sign in\n" +
                "2.Sign up\n" +
                "3.Exit");
                Enum.TryParse(Console.ReadLine(), out Authorization authorization);
                switch (authorization)
                {
                    case Authorization.SignIn:
                        {
                            while (!menuExit)
                            {
                                Console.Clear();
                                Console.WriteLine("Choose game\n" +
                                "1.Snake\n" +
                                "2.Sea War\n" +
                                "3.Chess");
                                Enum.TryParse(Console.ReadLine(), out MainMenu mainMenu);
                                switch (mainMenu)
                                {
                                    case MainMenu.Snake:
                                        {
                                            SnakeMenu();
                                        }
                                        break;
                                    case MainMenu.SeaWar:
                                        {
                                            Console.Clear();
                                        }
                                        break;
                                    case MainMenu.Chess:
                                        {
                                            Console.Clear();
                                        }
                                        break;
                                    case MainMenu.Exit:
                                        {
                                            Console.Clear();
                                            menuExit = true;
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case Authorization.SignUp:
                        {

                        }
                        break;
                    case Authorization.Exit:
                        {
                            exit = true;
                        }
                        break;
                }
            }
            Console.ReadLine();
        }

        public static void SnakeMenu()
        {
            int widthField = 30;
            int heightField = 70;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("1.PLay\n" +
                "2.Field size\n" +
                "3.Records\n" +
                "4.Exit");

                Enum.TryParse(Console.ReadLine(), out GameMenu gameMenu);
                switch (gameMenu)
                {
                    case GameMenu.PLay:
                        {
                            Console.Clear();
                            Console.CursorVisible = false;
                            SnakeGame snakeGame = new SnakeGame();
                            snakeGame.GameStart();
                            Console.ReadLine();
                        }
                        break;
                    case GameMenu.FieldSize:
                        {
                            Console.Clear();
                            do
                            {
                                Console.WriteLine("Enter Field height, min 20");
                                heightField = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Field widht, min 30");
                                widthField = int.Parse(Console.ReadLine());
                                if (heightField < 20 || widthField < 30)
                                {
                                    Console.WriteLine("Try again");
                                }
                            }
                            while (heightField < 20 || widthField < 30);
                        }
                        break;
                    case GameMenu.Records:
                        {
                        }
                        break;
                    case GameMenu.Exit:
                        {
                            exit = true;
                            Console.WriteLine("Exit from game");
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Wrong input, try again");
                        }
                        break;
                }
            }
        }
    }
}
