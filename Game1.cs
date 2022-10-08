using Android.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using tamagotchi.Controls;

namespace tamagotchi
{
    public class Game1 : Game
    { 
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Component> _gameComponents;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            var quitButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Vector2(100, 250),
                Text = "Quit",
            };
            quitButton.Touch += QuitButton_Touch;
            _gameComponents = new List<Component>()
            {
                quitButton,
            };

        }

        private void QuitButton_Touch(object sender, System.EventArgs e)
        {
            Console.WriteLine("test");
            Exit();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            foreach (var component in _gameComponents)
                component.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (var component in _gameComponents)
                component.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}