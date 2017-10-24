using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlacableChildren : MonoBehaviour {

    public Placeable[] placeScripts;
    public GameObject[] Children;
    private int aantalKids;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < transform.childCount -1; i++)
        {
            Children[i] = transform.GetChild(i).gameObject;

        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoopDoorChildren()
    {
        foreach (GameObject i in Children)
        {
            i.SetActive(true);
        }
        placeScripts = gameObject.GetComponentsInChildren<Placeable>();
        foreach (Placeable i in placeScripts)
        {
            i.enabled = true;
        }
    }
}
