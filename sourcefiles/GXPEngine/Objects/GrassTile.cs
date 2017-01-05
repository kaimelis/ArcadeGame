using GXPEngine;

namespace Objects
{
    class GrassTile : AnimSprite
    {
        public GrassTile(int frame, string filename) : base(filename, 3, 3)
        {
            SetFrame(frame);
        }
    }
}
