using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePlacableChildren : MonoBehaviour {

    public Placeable[] placeScripts;
    public GameObject[] Children;
    public GameObject schilderij;
    private int aantalKids;
    public static bool kidsHidden = false;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoopDoorChildren()
    {
        placeScripts = schilderij.gameObject.GetComponentsInChildren<Placeable>();
        foreach (Placeable i in placeScripts)
        {
            i.enabled = true;
        }
    }

    public void HideKids()
    {
        //Debug.Log(schilderij.transform.childCount);
        Children = new GameObject[schilderij.transform.childCount - 1];
        for (int i = 1; i < schilderij.transform.childCount; i++)
        {
            //Debug.Log(i);
            //Debug.Log(schilderij.transform.GetChild(i).gameObject.name);
            Children[i-1] = schilderij.transform.GetChild(i).gameObject;
        }
        if (kidsHidden)
        {
            foreach (GameObject i in Children)
            {
                i.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        if (!kidsHidden)
        {
            //Debug.Log("kids hidden");
            foreach (GameObject i in Children)
            {
                i.GetComponent<SpriteRenderer>().enabled = false;
                
            }
        }
        kidsHidden = !kidsHidden;
    }
}
