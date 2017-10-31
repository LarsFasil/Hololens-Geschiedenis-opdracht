using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour {

    public static string symbolTag;
    

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckAnswer(string antwoordTag)
    {
        if (symbolTag == antwoordTag)
        {
            Debug.Log("GOED");
        }
        else
        {
            Debug.Log("Fout");
        }

        Debug.LogFormat("symboltag was: {0}, en antwoordtag was: {1}", symbolTag, antwoordTag);
    }
}
