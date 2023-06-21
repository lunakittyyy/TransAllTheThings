﻿using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    Renderer renderer;
    Gradient gradient;
    GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    void Start()
    {
        renderer = GetComponent<Renderer>();

        gradient = new Gradient();
        colorKey = new GradientColorKey[5];
        alphaKey = new GradientAlphaKey[5];

        // apparently this is the easiest way to lerp between more than 2 colors somehow
        colorKey[0].color = new Color32(91, 206, 250, 255);
        colorKey[0].time = 0.2f;
        
        colorKey[1].color = new Color32(245, 169, 184, 255);
        colorKey[1].time = 0.4f;
        
        colorKey[2].color = Color.white;
        colorKey[2].time = 0.6f;
        
        colorKey[3].color = new Color32(245, 169, 184, 255);
        colorKey[3].time = 0.8f;

        colorKey[4].color = new Color32(91, 206, 250, 255);
        colorKey[4].time = 1.0f;

        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.2f;

        alphaKey[1].alpha = 1.0f;
        alphaKey[1].time = 0.4f;

        alphaKey[2].alpha = 1.0f;
        alphaKey[2].time = 0.6f;

        alphaKey[3].alpha = 1.0f;
        alphaKey[3].time = 0.8f;

        alphaKey[4].alpha = 1.0f;
        alphaKey[4].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);
    }

    void Update()
    {
        renderer.sharedMaterial.color = gradient.Evaluate(Mathf.PingPong(Time.time / 4, 1.0f));
    }
}