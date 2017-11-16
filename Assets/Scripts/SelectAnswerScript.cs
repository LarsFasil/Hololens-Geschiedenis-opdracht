using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnswerScript : MonoBehaviour {
    
    public void OnSelect()
    {
        if (!SpriteBehaviourScript.lerp3)
        {
            GameObject.Find("SceneManager").GetComponent<AnswerManager>().CheckAnswer(gameObject.tag);
        }
        
    }
}
