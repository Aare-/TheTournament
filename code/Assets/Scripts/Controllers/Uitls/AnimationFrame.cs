using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class AnimationFrame {
    [SerializeField]
    public Sprite Frame;
    [SerializeField]
    public float FrameTime = 0.1f;

    public AnimationFrame() {
        FrameTime = 0.1f;
    }
    public AnimationFrame(Sprite frame) {
        Frame = frame;
    }
}

