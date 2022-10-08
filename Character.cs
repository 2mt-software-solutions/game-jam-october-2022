using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tamagotchi
{
    internal class Character
    {
        // attributes
        private int playerHealth;
        private Texture2D playerTexture;
        protected int playerWidth;
        protected int playerHeight;
        protected Game game;

        public Character(Game game)
        {
            this.game = game;
            playerWidth = game.GraphicsDevice.Viewport.Width;
            playerHeight = game.GraphicsDevice.Viewport.Height;
            this.playerTexture = game.Content.Load<Texture2D>("player-dino");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            playerTexture.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
