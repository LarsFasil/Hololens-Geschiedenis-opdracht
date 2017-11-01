using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("h"))
        {
            transform.Translate(Vector3.forward * -.2f);
        }
        //Rotate();
	}

    void Rotate()
    {
        this.transform.RotateAround(transform.position, Vector3.up, 20*Time.deltaTime);
    }
}
