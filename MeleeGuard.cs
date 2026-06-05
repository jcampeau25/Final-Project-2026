using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Final_Project_2026
{
    public class MeleeGuard
    {
        public Rectangle Hitbox;
        public Rectangle DrawRect;
        private Vector2 velocity;
        private float _speed;
        private Texture2D _texture;
        private Color _color;
        public float Rotation;
        public Vector2 Position;
        public Vector2 Direction;
        public int Health, MaxHealth, Damage;
        public bool _attacking;
        private float _attackSeconds;
        private SpriteEffects _flip;


        public MeleeGuard(Rectangle hitbox, Vector2 position, Vector2 direction, Texture2D texture, int maxHealth, float speed, int damage)
        {
            Hitbox = hitbox;
            _texture = texture;
            velocity = Vector2.Zero;
            _speed = speed;
            DrawRect = new Rectangle(position.ToPoint(), new Point(50, 50));
            velocity = new Vector2(direction.X * speed, direction.Y * speed);
            _color = Color.White;
            Rotation = 0;
            Health = maxHealth;
            MaxHealth = maxHealth;
            Position = position;
            Damage = damage;
            _attacking = false;
            _flip = SpriteEffects.None;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle(DrawRect.Center, DrawRect.Size), null, _color, Rotation, new Vector2(_texture.Width / 2, _texture.Height / 2), _flip, 1f);
        }

        public void Update(GameTime gameTime, Player player)
        {

            Direction = player.DrawRect.Center.ToVector2() - DrawRect.Center.ToVector2();
            Direction.Normalize();
            Rotation = (float)Math.Atan2(Direction.Y, Direction.X) + (3 * MathHelper.PiOver2);


            velocity = new Vector2(Direction.X * _speed, Direction.Y * _speed);

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!_attacking)
            {
                _flip = SpriteEffects.None;
                Position += velocity * dt;
            }

            DrawRect = new Rectangle((int)Position.X, (int)Position.Y, 50, 50);

            if (DrawRect.Intersects(player.Hitbox) && !_attacking)
            {
                //Position += -velocity * dt;
                _attacking = true;
                player.Health -= Damage;
                _flip = SpriteEffects.FlipHorizontally;
                _attackSeconds = 0;

            }

            if (_attacking)
            {
                _attackSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                
                if (_attackSeconds >= 1)
                {               
                    _attacking = false;
                    
                }
            }



        }

    }




}
