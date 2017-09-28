using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehaviourScript : MonoBehaviour {

    public static GameObject schilderij;
    private static Transform[] allChildren;
    // Use this for initialization
    void Start () {
        schilderij = GameObject.FindWithTag("schilderij");
		allChildren = schilderij.gameObject.GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
       // schilderij.transform.GetComponentsInChildren<Transform>();
	}

    public static void ScriptSelected(Transform selectedTrans)
    {
        selectedTrans.parent = null;
        schilderij.transform.position = new Vector3(schilderij.transform.position.x, schilderij.transform.position.y, (schilderij.transform.position.z + 90f));
    }
}
