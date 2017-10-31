using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnswerScript : MonoBehaviour {
    


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSelect()
    {
        GameObject.Find("SceneManager").GetComponent<AnswerManager>().CheckAnswer(gameObject.tag);
    }
}
