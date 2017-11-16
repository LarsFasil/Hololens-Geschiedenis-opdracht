using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour {

    public static string symbolTag;
    public GameObject goed, fout;
    public AudioClip audio_goed, audio_fout;
    AudioSource audiosource;

	// Use this for initialization
	void Start () {
        audiosource = GetComponent<AudioSource>();
	}

    public void CheckAnswer(string antwoordTag)
    {
        if (symbolTag == antwoordTag)
        {
            gameObject.GetComponent<SpriteBehaviourScript>().SchilderijReset();
            ScoreScript.score++;
            GetComponent<ScoreScript>().UpdateScore();

            audiosource.PlayOneShot(audio_goed);
            Instantiate(goed, SpriteBehaviourScript.symbolToLerp.transform);
            Debug.Log("GOED");
        }
        else
        {
            audiosource.PlayOneShot(audio_fout);
            Instantiate(fout, SpriteBehaviourScript.symbolToLerp.transform);
            Debug.Log("Fout");
        }

        Debug.LogFormat("symboltag was: {0}, en antwoordtag was: {1}", symbolTag, antwoordTag);
    }
}
