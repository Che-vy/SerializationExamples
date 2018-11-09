using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GGbrah : MonoBehaviour
{
    public GameObject go;
    MeshRenderer mr;
    Rigidbody rb;

    public GGbrah() {
        RandomInit();
    }

    public void RandomInit()
    {
        go = Instantiate(Resources.Load("Prefabs/ballprefab") as GameObject);
        mr = go.GetComponent<MeshRenderer>();
        rb = go.GetComponent<Rigidbody>();
        mr.material.color = new Color(Random.value, Random.value, Random.value);
        go.transform.position = new Vector3(Random.Range(0, 15), Random.Range(0, 15), Random.Range(0, 15));
        rb.velocity = new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5)); 
    }

    public void Init()
    {
        go = Instantiate(Resources.Load("Prefabs/ballprefab") as GameObject);
        mr = go.GetComponent<MeshRenderer>();
        rb = go.GetComponent<Rigidbody>();
    }

    public void ImportBallData(GGbrahData data)
    {
        go.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
        mr.material.color = new Color(data.rgb[0], data.rgb[1], data.rgb[2]);
        rb.velocity = new Vector3(data.velocity[0], data.velocity[1], data.velocity[2]);
    }

    public GGbrahData ExportAsBallData()
    {
        return new GGbrahData(
            new float[] { mr.material.color.r, mr.material.color.g, mr.material.color.b },
            new float[] { rb.velocity.x, rb.velocity.y, rb.velocity.z },
            new float[] { go.transform.position.x, go.transform.position.y, go.transform.position.z });
    }

}

