using GXPEngine;

namespace Objects
{
    class Tile2 : AnimSprite
    {
        public Tile2(int frame, string filename) : base(filename, 3, 5)
        {
            SetFrame(frame);
        }
    }
}
