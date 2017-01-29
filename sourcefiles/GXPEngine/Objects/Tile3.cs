using GXPEngine;

namespace Objects
{
    class Tile3 : AnimSprite
    {
        public Tile3(int frame, string filename) : base(filename, 3, 5)
        {
            SetFrame(frame);
        }
    }
}
