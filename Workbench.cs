using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_2026
{
    public class Workbench
    {
        private Rectangle _location;
        private Texture2D _texture;


        public Workbench(Rectangle location, Texture2D texture)
        {
            _location = location;
            _texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }

        public Rectangle Location
        {
            get { return _location; }
            set { _location = value; }
        }

    }

    
}
