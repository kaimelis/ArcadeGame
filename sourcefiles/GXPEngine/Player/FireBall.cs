using GXPEngine;
using Vectors;

public class FireBall : Sprite
{
    private Vec2 _position;
    private Vec2 _velocity;
    private Player.Player _player;
    private int _fireballSpeed = 10;

    public FireBall(string filename, Vec2 pPosition = null, Vec2 pVelocity = null) : base(filename)
    {
        SetOrigin(width/2, height/2);
        _position = pPosition;
        _velocity = pVelocity;
        x = _position.x;
        y = _position.y;
        SetOrigin(width / 2, height / 2);
    }

    public Vec2 position
    {
        set{ _position = value ?? Vec2.zero; }
        get{ return _position; }
    }

    public Vec2 velocity
    {
        set{ _velocity = value ?? Vec2.zero; }
        get{ return _velocity; }
    }

    void Update()
    {
        _position.Add(_velocity);
        x = _position.x;
        y = _position.y;
    }
}

