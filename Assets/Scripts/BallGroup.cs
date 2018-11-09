using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BallGroup
{
    public Stack<BallClass> ballstack;

    public BallGroup() {
        ballstack = new Stack<BallClass>();

        for (int i = 0; i < Randomize1(); i++) {
            ballstack.Push(new BallClass());
            GameObject o = GameObject.Instantiate(Resources.Load("Prefabs/ballprefab") as GameObject);

            Debug.Log(o);

            Vector3 v3 = new Vector3();
            v3.x = Randomize2();
            v3.y = Randomize2();
            v3.z = Randomize2();
            o.transform.position = v3;

            MeshRenderer mr = o.GetComponent<MeshRenderer>();
            Color c = new Color(ballstack.Peek().rgb[0], ballstack.Peek().rgb[1], ballstack.Peek().rgb[2]);
            mr.material.color = c;

            Rigidbody rb = o.GetComponent<Rigidbody>();
            rb.velocity = ballstack.Peek().velocity;
        }

    }

    public float Randomize1() {

        return Random.Range(1,20);
    }

    public float Randomize2() {
        return Random.Range(0, 10);
    }
}
