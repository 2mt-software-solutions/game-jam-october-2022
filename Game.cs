using Android.Content;
using Android.Media;
using Android.OS;
using Android.Util;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO.IsolatedStorage;
using tamagotchi.Gamestates;

namespace tamagotchi
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private const string SAVEGAME = "savegame";
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Gamestate _state;
        private long _lastExit;
        private IsolatedStorageFile savegameStorage = IsolatedStorageFile.GetUserStoreForApplication();

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this._state = new RunningState();

            this.readSaveGame();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this._lastExit = DateAndTime.Now.Ticks;
                this.writeSavegame();
                Exit();
            }

            this._state.handleInput(GamePad.GetState(PlayerIndex.One), Keyboard.GetState());
            this._state.update();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

        protected void readSaveGame()
        {

            if (savegameStorage.FileExists(SAVEGAME))
            {
                IsolatedStorageFileStream fs = null;
                try
                {
                    fs = savegameStorage.OpenFile(SAVEGAME, System.IO.FileMode.Open);
                }
                catch (IsolatedStorageException e)
                {
                    this._lastExit = DateAndTime.Now.Ticks;
                }

                if (fs != null)
                {
                    byte[] saveBytes = new byte[256];
                    int count = fs.Read(saveBytes, 0, 256);
                    string lastExit = System.Text.Encoding.UTF8.GetString(saveBytes, 0, count);
                    fs.Close();

                    this._lastExit = Convert.ToInt64(lastExit);
                    Log.Debug(null, "last exit: " + this._lastExit.ToString());

                }
            }
        }

        protected void writeSavegame()
        {
            IsolatedStorageFileStream fs = null;
            fs = savegameStorage.OpenFile(SAVEGAME, System.IO.FileMode.Create);
            if (fs != null)
            {
                fs.Write(System.Text.Encoding.UTF8.GetBytes(this._lastExit.ToString()));
                fs.Close();
            }
        }
    }
}