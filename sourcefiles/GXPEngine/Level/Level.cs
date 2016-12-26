using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;

namespace Level
{
    class Level : GameObject
    {
        private readonly MyGame _game;
        private readonly string _levelName; //useless for now
        private int _score;


        public Level(string filename, MyGame game)
        {
            _game = game;
            _score = _game.GetScore();
        }
    }
}
