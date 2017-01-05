using GXPEngine;
using Vectors;

public class FireBall : Sprite
{
    private Vec2 _position;
    private Vec2 _direction;
    private Player _player;
    private int _fireballSpeed = 10;

    public FireBall(string filename, float rotation, Vec2 position) : base(filename)
    {
        SetOrigin(width/2, height/2);
        _position = position;
        _direction = Vec2.GetUnitVectorDegrees(rotation);
        _direction.Normalize();
    }

    void Update()
    {
        _position.x += _direction.x * _fireballSpeed;
        _position.y += _direction.y * _fireballSpeed;
        rotation = _direction.GetAngleDegrees();
        SetXY(_position.x, _position.y);
    }
}

