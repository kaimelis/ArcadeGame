using System;
using GXPEngine;
using Objects;
using Vectors;

public class Player : AnimSprite
{

    private float _maxSpeed = 6.5f;
    private float _ySpeed = 0.0f;
    private float _xSpeed = 0.0f;

    private float _currentFrame = 0.0f;
    private float _lastFrame = 82;
    private int _direction = 0;
    private float _frame = 0;

    private bool onGround = false;

    private Level _level;
    private GrassTile _grassTile;
    private FireBall _fireball;
    private float _rotation;

    public Player(Level level) : base("boy.png", 9, 10)
    {
        SetOrigin(width / 2, height);
        x = game.width / 2;
        _level = level;
       // SetAnimationRange(0, 17);
        _direction = 1;
        _xSpeed = _maxSpeed;
    }

    private void Update()
    {
        Gravity();
        FrameRate();
        SimpleMoving();
    }

    private void SimpleMoving()
    {
        //move left
        if (Input.GetKey(Key.A))
        {
            SetAnimationRange(0, 18);
            _direction = -1;
            _xSpeed = _maxSpeed;

        }
        //move right
        else if (Input.GetKey(Key.D))
        {
            SetAnimationRange(0, 18);
            _direction = 1;
            _xSpeed = _maxSpeed;
        }
        //jump
        else if (Input.GetKeyDown(Key.SPACE))
        {
            
        }
        else if (Input.GetKeyDown(Key.F))
        {
            if (_direction == 1)
                _rotation = 0;
            else _rotation = 180;
            _fireball = new FireBall(Utility.UtilStrings.SpritesPlayer + "fireball.png",_rotation ,new Vec2(x, y));
            game.AddChildAt(_fireball,1);
        }
        //idle
        else
        {
            SetAnimationRange(18, 80);
            _xSpeed *= 0.4f;
        }

        DoMove((_direction * _xSpeed), 0);
        scaleX = _direction;
    }

    private void DoMove(float moveX, float moveY)
    {
        x += moveX;
        y += moveY;
        HandleCollisions(moveX, moveY);
    }

    private void Gravity()
    {
        DoMove(0, _ySpeed);
        _ySpeed = _ySpeed + 1.0f;

        if (onGround == true)
        {

            if (Input.GetKey(Key.F))
            {
                _ySpeed = -20.0f;
                onGround = false;
            }
        }
    }

    private void HandleCollisions(float moveX, float moveY)
    {
        foreach (GameObject other in GetCollisions())
        {
            HandleCollision(other, moveX, moveY);
        }
    }

    private void HandleCollision(GameObject other, float moveX, float moveY)
    {
        if (other is GrassTile)
        {
            _grassTile = other as GrassTile;
            if (moveY > 0)
                onGround = true;
            _ySpeed = 0.0f;
        }
    }

    private void FrameRate()
    {
        _frame = _frame + 0.6f;
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
