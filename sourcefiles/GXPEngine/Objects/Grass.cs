﻿using GXPEngine;

namespace Objects
{
   public class Grass : AnimSprite
    {
        public Grass(int frame, string filename) : base(filename, 3, 5)
        {
            SetFrame(frame);
        }
    }
}
