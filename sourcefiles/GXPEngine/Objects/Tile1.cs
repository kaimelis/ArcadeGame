using GXPEngine;

namespace Objects
{
    class Tile1 : AnimSprite
    {
        public Tile1(int frame, string filename) : base(filename, 3, 5)
        {
            SetFrame(frame);
        }
    }
}
