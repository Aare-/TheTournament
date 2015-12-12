using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

static class ExtensionVector2 {
    public static Vector2 Rotate(this Vector2 v, float degrees) {
        float radians = degrees * Mathf.Deg2Rad;
        float sin = Mathf.Sin(radians);
        float cos = Mathf.Cos(radians);

        float tx = v.x;
        float ty = v.y;

        return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
    }
    public static Vector2 Mul(this Vector2 v, float val) {        
        return new Vector2(v.x * val, v.y * val);
    }
}

