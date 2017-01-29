using System;
using GXPEngine;

namespace Player
{
    class Trail : Sprite
    {
        private int time = 100;
        public Trail(string filename) : base(filename)
        {
            SetOrigin(width/2,height/2);
        }

        void Update()
        {
            alpha = time/100.0f;
            time = time - 1;
            if(time < 0 )Destroy();
        }
    }
}
