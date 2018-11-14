using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGbrahData {

    public float[] rgb;
    public float[] velocity;
    public float[] position;

    public GGbrahData()
    {
        rgb = new float[3];
        velocity = new float[3];
        position = new float[3];
    }

    public GGbrahData(float[] rgb, float[] velocity, float[] position)
    {
        this.rgb = rgb;
        this.velocity = velocity;
        this.position = position;
    }
}
