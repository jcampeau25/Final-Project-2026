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
    public class Bullet
    {
        private Vector2 _velocity;
        private Vector2 _position;
        private Rectangle _hitbox;
        private Texture2D _texture;
        private float _speed;
        private bool _active;
        private int _width;
        private int _height;


        public Bullet(Vector2 position, Texture2D texture, Vector2 direction, float speed)
        {
            _width = 15;
            _height = 15;
            _position = position;
            _hitbox = new Rectangle((int)position.X, (int)position.Y, _width, _height);
            _texture = texture;
            _velocity = new Vector2(direction.X * speed, direction.Y * speed);
            _speed = speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _hitbox, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _position += _velocity * dt;
            _hitbox = new Rectangle((int)_position.X, (int)_position.Y, _width, _height);
        }

    }
}
