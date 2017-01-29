using GXPEngine;

namespace Objects
{
    public class Backgrass : AnimSprite
    {
        public Backgrass(int frame, string filename) : base(filename, 3, 4)
        {
            SetFrame(frame);
        }
    }
}
