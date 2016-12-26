using System;
using GXPEngine;

namespace Vectors
{
    public class Vec2
    {
        public static Vec2 zero { get { return new Vec2(0, 0); } }

        public float x = 0;
        public float y = 0;
        static Random rnd = new Random();
        public Vec2(float pX = 0, float pY = 0)
        {
            x = pX;
            y = pY;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", x, y);
        }

        public Vec2 Add(Vec2 other)
        {
            x += other.x;
            y += other.y;
            return this;
        }

        public Vec2 Sub(Vec2 other)
        {
            x -= other.x;
            y -= other.y;
            return this;
        }

        public Vec2 Scale(float pScale)
        {
            x *= pScale;
            y *= pScale;
            return this;
        }

        public int Length()
        {
            double length;
            length = Math.Sqrt(x * x + y * y);
            return (int)length;
        }

        public Vec2 Normalize()
        {

            double length = Length();
            if (length != 0)
            {
                x = x / (int)length;
                y = y / (int)length;
            }
            return this;
        }

        public Vec2 Clone()
        {

            return new Vec2(x, y);
        }

        public Vec2 SetXY(float pX, float pY)
        {
            x = pX;
            y = pY;
            return this;
        }

        public Vec2 SetXY(Vec2 other)
        {
            x = other.x;
            y = other.y;
            return this;
        }

        public static float Deg2Rad(float pDegrees)
        {
            float radians = pDegrees * Mathf.PI / 180;
            return radians;
        }

        public static float Rad2Deg(float pRadians)
        {
            float degrees = pRadians * 180 / Mathf.PI;
            return degrees;
        }

        public static Vec2 GetUnitVectorDegrees(float pDegrees)
        {
            return new Vec2(Mathf.Cos(Deg2Rad(pDegrees)), Mathf.Sin(Deg2Rad(pDegrees)));
        }

        public static Vec2 GetUnitVectorRadians(float pRadians)
        {
            return new Vec2(Mathf.Cos((pRadians)), Mathf.Sin((pRadians)));
        }

        public static Vec2 RandomUnitVector()
        {
            return new Vec2(Mathf.Cos(Deg2Rad(rnd.Next(0, 360))), Mathf.Sin(Deg2Rad(rnd.Next(0, 360))));
        }

        public Vec2 SetAngleDegrees(float pDegrees)
        {
            float angleInDegrees = pDegrees - GetAngleDegrees();
            float angleInRadians = Deg2Rad(angleInDegrees);
            float oldX = x;
            float oldY = y;
            x = oldX * Mathf.Cos(angleInRadians) - oldY * Mathf.Sin(angleInRadians);
            y = oldX * Mathf.Sin(angleInRadians) + oldY * Mathf.Cos(angleInRadians);
            return this;
        }

        public Vec2 SetAngleRadians(float pRadians)
        {
            float angleInRadians = pRadians - GetAngleRadians();
            float oldX = x;
            float oldY = y;
            x = oldX * Mathf.Cos(angleInRadians) - oldY * Mathf.Sin(angleInRadians);
            y = oldX * Mathf.Sin(angleInRadians) + oldY * Mathf.Cos(angleInRadians);
            return this;
        }

        public Vec2 RotateDegrees(float pDegrees)
        {
            float angleInRadians = Deg2Rad(pDegrees);
            float oldX = x;
            float oldY = y;
            x = oldX * Mathf.Cos(angleInRadians) - oldY * Mathf.Sin(angleInRadians);
            y = oldX * Mathf.Sin(angleInRadians) + oldY * Mathf.Cos(angleInRadians);
            return this;
        }

        public Vec2 RotateRadians(float pRadians)
        {
            float oldX = x;
            float oldY = y;
            x = oldX * Mathf.Cos(pRadians) - oldY * Mathf.Sin(pRadians);
            y = oldX * Mathf.Sin(pRadians) + oldY * Mathf.Cos(pRadians);
            return this;
        }
        /*
        public float GetAngleToObjectDegrees(Vec2 pObj1, Vec2 pObj2)
        {
            return Rad2Deg(Mathf.Atan2(pObj2.y - pObj1.y, pObj2.x - pObj1.x));
        }

        public float GetAngleToObjectRadians(Vec2 pObj1, Vec2 pObj2)
        {
            return Mathf.Atan2(pObj1.y - pObj2.y, pObj1.x - pObj2.x);
        }
        */
        public float GetAngleDegrees()
        {
            float degrees;
            degrees = Rad2Deg(Mathf.Atan2(y, x));
            return degrees;
        }

        public float GetAngleRadians()
        {
            float radians;
            radians = Mathf.Atan2(y, x);
            return radians;
        }

        public Vec2 RotateAroundDegrees(float pDegrees, float pX, float pY)
        {
            float translatedX = x - pX;
            float translatedY = y - pY;
            float angleInRadians = Deg2Rad(pDegrees);

            x = translatedX * Mathf.Cos(angleInRadians) - translatedY * Mathf.Sin(angleInRadians) + pX;
            y = translatedX * Mathf.Sin(angleInRadians) + translatedY * Mathf.Cos(angleInRadians) + pY;

            return this;
        }

        public Vec2 RotateAroundRadians(float pRadians, float pX, float pY)
        {
            float translatedX = x - pX;
            float translatedY = y - pY;

            x = translatedX * Mathf.Cos(pRadians) - translatedY * Mathf.Sin(pRadians) + pX;
            y = translatedX * Mathf.Sin(pRadians) + translatedY * Mathf.Cos(pRadians) + pY;

            return this;
        }

        public Vec2 Normal()
        {
            return new Vec2(-y, x).Normalize();
        }

        public float Dot(Vec2 other)
        {
            return x * other.x + y * other.y;
        }

        public Vec2 Reflect(Vec2 pNormal, float pBounciness = 1)
        {
            //pNormal normalized
            Sub(pNormal.Scale((1 + pBounciness) * Clone().Dot(pNormal)));
            return this;
        }
    }


}

