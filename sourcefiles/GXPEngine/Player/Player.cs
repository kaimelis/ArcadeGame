using System;
using GXPEngine;
using Objects;
using Utility;
using Vectors;

namespace Player
{
    public class Player : AnimSprite
    {
        private float _frame;
        private float _lastFrame = 12;
        private float _direction = 0;

        private float _xSpeed = 0;
        private float _ySpeed = 0;
        private float _maxSpeed = 5;
        private float _maxYspeed = 15f;
        private bool _isGrounded;
        private int _jumpCount;

        private float _lastKnownGoodX = 0.0f;
        private float _lastKnownGoodY = 0.0f;

        public Player() : base("boy.png", 8, 2)
        {
            _direction = 1;
            _xSpeed = _maxSpeed;
        }

        private void Update()
        {
            storePosition();
            FrameRate();
            Movement();
            Gravity();
        }

        private void Movement()
        {


            if (Input.GetKey(Key.RIGHT))
            {
                _direction = 1;
                SetAnimationRange(0, 7);
                _xSpeed = _maxSpeed;
            }
            else if (Input.GetKey(Key.LEFT))
            {
                _direction = -1;
                SetAnimationRange(0, 7);
                _xSpeed = -_maxSpeed;
            }
            else
            {
                _xSpeed *= 0.8f;
                SetAnimationRange(0, 0);

            }
            if (Input.GetKeyDown(Key.SPACE) )
            {
                SetAnimationRange(0, 8);//why it's not called?
                Console.WriteLine(_currentFrame + " " + _lastFrame);
                Console.WriteLine("fire");
            }

            if (Input.GetKey(Key.UP) && _ySpeed < _maxYspeed && _isGrounded && _jumpCount < 2)
            {
                _ySpeed = -30.0f;
                _jumpCount++;
                _isGrounded = false;
                SetAnimationRange(9, 11);//why it's not called?

            }
            Move(_xSpeed,0);
            scaleX = _direction;

        }

        private void Move(float xSpeed , float ySpeed)
        {
            x += xSpeed;
            y += ySpeed;
            HandleCollision(xSpeed, ySpeed);
        }

        private void HandleCollision(float moveX, float moveY)
        {
            foreach (GameObject other in GetCollisions())
            {
                Collisions(other, moveX,moveY);
            }
        }

        private void Collisions(GameObject other, float moveX, float moveY)
        {
            if (other is Tile1)
            {
               // if(moveY > 0)
                _isGrounded = true;
                MoveBack();// with this i can jump but not move ehhhhhh.............
                _ySpeed = 0f;
                _jumpCount = 0;
            }
        }

        private void Gravity()
        {
            Move(0, _ySpeed);
            _ySpeed +=2f;
        }


        void storePosition()
        {
           // _lastKnownGoodX = x;
            _lastKnownGoodY = y;
        }

        void restorePosition()
        {
           // x = _lastKnownGoodX;
            y = _lastKnownGoodY;
        }

        public void MoveBack()
        {
            restorePosition();
        }

        private void FrameRate()
        {
            _frame +=  0.3f;
            if (_frame >= _lastFrame + 1) _frame = _currentFrame;
            if (_frame < _currentFrame) _frame = _currentFrame;
            SetFrame((int)_frame);
        }

        private void SetAnimationRange(int first, int last)
        {
            _currentFrame = first;
            _lastFrame = last; 
        }
    }
}
