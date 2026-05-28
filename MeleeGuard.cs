using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_2026
{
    public class MeleeGuard
    {
        public Rectangle Hitbox;
        public Rectangle DrawRect;
        private Vector2 _speed;
        private Texture2D _texture;
        private Color _color;
        public float Rotation;
        public Vector2 Position;
        public Vector2 Direction;
        public int Health, MaxHealth;




        public MeleeGuard(Rectangle hitbox, Vector2 position, Vector2 speed, Texture2D texture, int maxHealth)
        {
            Hitbox = hitbox;
            DrawRect = new Rectangle(position.ToPoint(), new Point(50, 50));
            _speed = speed;
            _color = Color.White;
            Rotation = 0;
            Health = maxHealth;
            MaxHealth = maxHealth;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle(DrawRect.Center, DrawRect.Size), null, _color, Rotation, new Vector2(_texture.Width / 2, _texture.Height / 2), SpriteEffects.None, 1f);

        }

        public void Update(GameTime gameTime, Player player)
        {

        }

    }




}
