using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("SuicideMethod", 2f);
	}
	
	// Update is called once per frame
	void SuicideMethod () {
        Destroy(gameObject);
	}
}
