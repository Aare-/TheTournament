using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarr : MonoBehaviour {
    public Image Background;
    public Image Foreground;

    private float _Percent;

    public float Percent {
        get {
            return _Percent;
        }
        set {
            RectTransform t = Foreground.GetComponent<RectTransform>();

            t.localScale = new Vector3(Mathf.Clamp01(value), 1.0f, 1.0f);

            _Percent = value;
        }
    }
}
