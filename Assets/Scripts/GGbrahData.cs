using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGbrahData {

    public float[] rgb;
    public float[] velocity;
    public float[] position;
    public List<GGbrahData> list;

    public GGbrahData()
    {
        rgb = new float[3];
        velocity = new float[3];
        position = new float[3];
        list = new List<GGbrahData>();
    }

    public GGbrahData(float[] rgb, float[] velocity, float[] position)
    {
        this.rgb = rgb;
        this.velocity = velocity;
        this.position = position;
        list = new List<GGbrahData>();
    }
}
