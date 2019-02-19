using Morabara.Views.Base;
using Morabara.Logic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Linq;

namespace Morabara.Views
{
    public class Settings : BaseWindow
    {
        private readonly RectangleShape backButton;
        private readonly Text backText;
        private readonly Text settingsText;

        private readonly RectangleShape easyButton;
        private readonly RectangleShape mediumButton;
        private readonly RectangleShape hardButton;
        private readonly Text easyButtonText;
        private readonly Text mediumButtonText;
        private readonly Text hardButtonText;


        public Settings()
        {
            backButton = new RectangleShape(new Vector2f(700, 100))
            {
                FillColor = new Color(150, 200, 150),
                Position = new Vector2f(50, 475)
            };

            backText = new Text("BACK TO MENU", Font)
            {
                CharacterSize = 60,
                Style = Text.Styles.Regular,
                Position = new Vector2f(190, 485),
                Color = Color.Blue
            };

            string topTextString = "Difficulty level:";
            

            settingsText = new Text(topTextString, Font)
            {
                CharacterSize = 20,
                Style = Text.Styles.Regular,
                Position = new Vector2f(50, 50),
                Color = Color.Blue
            };

            easyButton = new RectangleShape(new Vector2f(350, 50))
            {
                FillColor = new Color(150, 200, 150),
                Position = new Vector2f(30, 85)
            };

            easyButtonText = new Text("EASY", Font)
            {
                CharacterSize = 30,
                Style = Text.Styles.Regular,
                Position = new Vector2f(170, 90),
                Color = Color.Blue
            };

            mediumButton = new RectangleShape(new Vector2f(350, 50))
            {
                FillColor = new Color(150, 200, 150),
                Position = new Vector2f(30, 175)
            };

            mediumButtonText = new Text("MEDIUM", Font)
            {
                CharacterSize = 30,
                Style = Text.Styles.Regular,
                Position = new Vector2f(150, 180),
                Color = Color.Blue
            };

            hardButton = new RectangleShape(new Vector2f(350, 50))
            {
                FillColor = new Color(150, 200, 150),
                Position = new Vector2f(30, 265)
            };

            hardButtonText = new Text("HARD", Font)
            {
                CharacterSize = 30,
                Style = Text.Styles.Regular,
                Position = new Vector2f(170, 270),
                Color = Color.Blue
            };



            bindEvents();
            start();
        }

        private void start()
        {
            while (Window.IsOpen)
            {
                Window.DispatchEvents(); //init event
                Window.Clear(new Color(0, 192, 255)); //clear window

                Window.Draw(backButton);
                Window.Draw(backText);

                Window.Draw(settingsText);

                Window.Draw(easyButton);
                Window.Draw(easyButtonText);

                Window.Draw(mediumButton);
                Window.Draw(mediumButtonText);

                Window.Draw(hardButton);
                Window.Draw(hardButtonText);

                Window.Display(); //display render up view
            }
        }

        private void bindEvents()
        {
            Window.MouseMoved += (sender, e) =>
            {
                backButton.FillColor = backButton.GetGlobalBounds().Contains(Mouse.GetPosition(Window).X, Mouse.GetPosition(Window).Y)
                    ? new Color(100, 100, 100)
                    : new Color(150, 200, 150);

                easyButton.FillColor = easyButton.GetGlobalBounds().Contains(Mouse.GetPosition(Window).X, Mouse.GetPosition(Window).Y)
                    ? new Color(100, 100, 100)
    :               new Color(150, 200, 150);
                mediumButton.FillColor = mediumButton.GetGlobalBounds().Contains(Mouse.GetPosition(Window).X, Mouse.GetPosition(Window).Y)
                    ? new Color(100, 100, 100)
                    : new Color(150, 200, 150);
                hardButton.FillColor = hardButton.GetGlobalBounds().Contains(Mouse.GetPosition(Window).X, Mouse.GetPosition(Window).Y)
                    ? new Color(100, 100, 100)
                    : new Color(150, 200, 150);
            };

            Window.MouseButtonReleased += (sender, args) =>
            {
                if (backButton.GetGlobalBounds().Contains(Mouse.GetPosition(Window).X, Mouse.GetPosition(Window).Y))
                {
                    WindowsStack.CloseLastWindow();
                }
                else if (easyButton.GetGlobalBounds().Contains(Mouse.GetPosition(Window).X, Mouse.GetPosition(Window).Y))
                {
                    GameLogic.difficulty = 2;
                    WindowsStack.CloseLastWindow();
                }
                else if (mediumButton.GetGlobalBounds().Contains(Mouse.GetPosition(Window).X, Mouse.GetPosition(Window).Y))
                {
                    GameLogic.difficulty = 4;
                    WindowsStack.CloseLastWindow();
                }
                else if (hardButton.GetGlobalBounds().Contains(Mouse.GetPosition(Window).X, Mouse.GetPosition(Window).Y))
                {
                    GameLogic.difficulty = 5;
                    WindowsStack.CloseLastWindow();
                }
            };
        }
    }
}