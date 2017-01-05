
using GXPEngine;

namespace UI.MENU
{
    class Background : Sprite
    {
        private int _choice;//choice of how fast the speed will be

        public Background(string filename, int choice) : base(filename)
        {
            SetOrigin(game.width, game.height);
            SetXY(width, height);
            _choice = choice;
        }

        public void Scroll(float x, float y)
        {
            SetXY(game.width / 2 - (x  / 10), game.height / 2 + -(y  / 10));
        }
    }
}
