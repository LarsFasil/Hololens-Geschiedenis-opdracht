using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    public static int score = 0;
    public static GameObject text;

	
    public void UpdateScore()
    {
        text.GetComponent<TextMesh>().text = score.ToString() + "/12";
        if (score == 12)
        {
            //endtext.gameObject.SetActive(true);
        }
    }
}
