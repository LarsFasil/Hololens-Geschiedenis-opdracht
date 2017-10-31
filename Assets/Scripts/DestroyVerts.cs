using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVerts : MonoBehaviour {

    public GameObject parentVert;
    public bool destroyVerts = false;
    public static bool doIt = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void DestroyAllVerts()
    {
        if (destroyVerts)
        {
            foreach (Transform i in parentVert.transform.GetComponentsInChildren<Transform>())
            {
                i.gameObject.SetActive(false);
            }
        }
    }
}
