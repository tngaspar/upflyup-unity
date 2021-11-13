using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class backgroundColor : MonoBehaviour
{
    SpriteRenderer spriterenderer;
    private float h;
    private float s;
    private float v;

    // false = down, true = up
    private bool sdir = true;
    private bool vdir = true;

    public float speed = 0.001f; 
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        Color.RGBToHSV(spriterenderer.color,out h,out s,out v);
        //h = (float)Math.Round(h * 100f) / 100f;
        //s = (float)Math.Round(s  * 100f) / 100f;
        //v = (float)Math.Round(v * 100f) / 100f;
    }

    void Update()
    {
        //h
        if (h >= 1f)
            h = 0f;
        else
            h = h + speed;

        //s
        if (s <= 0f)
        {
            sdir = true;
            s = s + speed;
        }
        else if (s >= .15f)
        {
            sdir = false;
            s = s - speed;
        }
        else
        {
            if (sdir == true)
                s = s + speed;
            else
                s = s - speed;
        }

        //v
        if (v <= 0.8f)
        {
            vdir = true;
            v = v + speed;
        }
        else if (v >= 1f)
        {
            vdir = false;
            v = v - speed;
        }
        else
        {
            if (vdir == true)
                v = v + speed;
            else
                v = v - speed;
        }

        //Debug.Log($"h: {h}" );
        //Debug.Log($"s: {s}");
        //Debug.Log($"v: {v}");
        spriterenderer.color = Color.HSVToRGB(h, s, v);
    }
}
