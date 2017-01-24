using UnityEngine;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

public class PixelPerfectCamera : MonoBehaviour
{
    // Use this for initialization
    public int PPUScale = 1;
    public int PPU = 32;
    private float lastScreenHeight;

    private void Start()
    {
        UpdateCameraOrtho();
    }

    private void UpdateCameraOrtho()
    {
        lastScreenHeight = Screen.height;

        Camera.main.orthographicSize = (lastScreenHeight/(PPUScale*PPU))*0.5f;

        Debug.Log("Camera orthographic size set to: " + Camera.main.orthographicSize);
    }

    private void Update()
    {
        #if UNITY_EDITOR
            if (lastScreenHeight != Screen.height)
                UpdateCameraOrtho();
        #endif
    }
}