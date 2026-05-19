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

        public Bullet(Vector2 position, Rectangle hitbox, Texture2D texture, Vector2 direction, float speed)
        {
            _position = position;
            _hitbox = hitbox;
            _texture = texture;
            _velocity = new Vector2(direction.X * speed, direction.Y * speed);
            _speed = speed;
        }



    }
}
