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
    public class Player
    {
        private Rectangle _hitbox;
        private Rectangle _drawRect;
        private Vector2 _speed;
        private Texture2D _texture;
        private Color _color;
        private float _rotation;
        Vector2 _position;
        Vector2 _direction;

        

        public Player(Rectangle hitbox, Vector2 position, Vector2 speed, Texture2D texture, Color color)
        {
            _hitbox = hitbox;
            _drawRect = new Rectangle(position.ToPoint(), new Point(50, 50));
            _speed = speed;
            _texture = texture;
            _color = color;
            _rotation = 0;


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _drawRect, null, _color, 1f, new Vector2(_drawRect.Width / 2, _drawRect.Height / 2), SpriteEffects.None, 1f);
        }

        public void Update(KeyboardState keyboardState, MouseState mouseState)
        {
            if (keyboardState.IsKeyDown(Keys.D))
            {
                _speed.X = 4;
            }

            if (keyboardState.IsKeyDown(Keys.A))
            {
                _speed.X = -4;
            }

            if (keyboardState.IsKeyDown(Keys.W))
            {
                _speed.Y = 4;
            }

            if (keyboardState.IsKeyDown(Keys.S))
            {
                _speed.Y = -4;
            }

            else
            {
                _speed = Vector2.Zero;
            }

            

            _hitbox.Offset(_speed);
            _drawRect.Offset(_speed);

        }
    }
}
