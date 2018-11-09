using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BallClass {

    [SerializeField]
    public float[] rgb;
    public Vector3 velocity;
    public Vector3 position;

    public BallClass()
    {
        this.rgb = new float[3];
        rgb[0] = Random.value;
        rgb[1] = Random.value;
        rgb[2] = Random.value;

        int r = Random.Range(0, 4);
        switch (r) {
            case 0:
            case 1:
                this.velocity.x = Random.Range(-15, 15);
                break;
            case 2:
                this.velocity.y = Random.Range(-15, 15);
                break;
            case 4:
            case 3:
                this.velocity.z = Random.Range(-15, 15);
                break;
            default:
                break;

        }
        position = new Vector3();
    }
}
