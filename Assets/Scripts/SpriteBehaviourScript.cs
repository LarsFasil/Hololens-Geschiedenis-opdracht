using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehaviourScript : MonoBehaviour
{
    public bool testLerp = false, testlerp3 = false, textSpawned = false;
    public static bool lerp1, lerp2, lerp3;
    private float t;
    private bool heen = true;
    public float afstand = 5.0f;
    public float snelheid = .4f;
    public float antOffset = 1f;
    public GameObject schilderij, antwoorden, muurprefab, scorePrefab;
    private Vector3 sPos, begin, eind, start, offset, offset2;
    public SpriteRenderer sprite;
    private SpriteRenderer textSprite;
    private Color c, sC, eC;
    public static Vector3 centerPunt;
    public static GameObject symbolToLerp;
    private GameObject ant1, score, muur;



    void Start()
    {
        c = sprite.color;
        lerp1 = false;
        lerp2 = false;
        t = 0f;
        sPos = Vector3.zero;


    }

    void Update()
    {
        TextLerp();
        BGLerp();
        SymLerp();
    }
    public void SchilderijReset()
    {
        muur.transform.Translate(Vector3.forward * -.2f);
        StartCoroutine(lerpAntBack());
        symbolToLerp.GetComponent<FadeObjectInOut>().FadeOut(1);
        if (ScoreScript.score < 11)
        {
            lerp1 = true;
            return;
        }
        Destroy(schilderij);
    }


    IEnumerator lerpAntBack()
    {
        ant1.GetComponent<FadeObjectInOut>().FadeOut(1);
        score.GetComponent<FadeObjectInOut>().FadeOut(1);

        Vector3 end = ant1.transform.position + (ant1.transform.forward * 2f);
        Debug.Log(end);
        while (Vector3.Distance(ant1.transform.localPosition, end) > .1f)
        {
            score.transform.localPosition = Vector3.Lerp(score.transform.localPosition, end, Time.deltaTime * 1f);
            ant1.transform.localPosition = Vector3.Lerp(ant1.transform.localPosition, end, Time.deltaTime * 1f);
            yield return null;
        }
        Destroy(score);
        Destroy(ant1);
        Destroy(symbolToLerp);
        Destroy(muur);
        textSpawned = false;
    }

    public void TextLerp()
    {
        if (lerp3 || testlerp3)
        {
            if (!textSpawned)
            {
                textSpawned = true;
                centerPunt = schilderij.transform.position;
                offset = centerPunt + (schilderij.transform.right * antOffset);
                offset2 = centerPunt + (schilderij.transform.up * .8f);
                if (symbolToLerp.name == "Arnolfini_Bed")
                {
                    offset2 = centerPunt + (schilderij.transform.up * 1f);
                }

                ant1 = Instantiate(antwoorden, centerPunt, schilderij.transform.rotation);
                score = Instantiate(scorePrefab, centerPunt, schilderij.transform.rotation);
                ScoreScript.text = score.GetComponentInChildren<TextMesh>().gameObject;
                GetComponent<ScoreScript>().UpdateScore();

                ant1.GetComponent<FadeObjectInOut>().FadeOut(.001f);
                ant1.GetComponent<FadeObjectInOut>().FadeIn(1);

                score.GetComponent<FadeObjectInOut>().FadeOut(.001f);
                score.GetComponent<FadeObjectInOut>().FadeIn(1);
            }

            ant1.transform.localPosition = Vector3.Lerp(ant1.transform.position, offset, snelheid * Time.deltaTime * 1.33f);
            score.transform.localPosition = Vector3.Lerp(score.transform.position, offset2, snelheid * Time.deltaTime * 1.33f);

            if (Vector3.Distance(ant1.transform.position, offset) < .02f && Vector3.Distance(score.transform.position, offset2) < .02f)
            {
                testlerp3 = false;
                lerp3 = false;
            }
        }
    }

    public void SymLerp()
    {
        if (lerp2)
        {
            symbolToLerp.transform.position = Vector3.Lerp(symbolToLerp.transform.position, centerPunt, snelheid * Time.deltaTime);
            if (Vector3.Distance(symbolToLerp.transform.position, centerPunt) < .02f)
            {
                muur = Instantiate(muurprefab, symbolToLerp.transform.position, symbolToLerp.transform.rotation);
                muur.transform.Translate(Vector3.forward * .008f);
                lerp2 = false;
            }
        }
    }

    public void BGLerp()
    {
        if (lerp1 || testLerp)                                                      //Als de public static bool lerp1 'true' word begint de sequence van de rest van het schilderij naar achter werken.
        {

            if (sPos == Vector3.zero && heen == true)                                                       //Deze if statement zorgt ervoor dat je met 1 bool(lerp1) de achtergrond beide kanten op kan laten gaan. En reset wat nodige variabele.
            {
                sPos = schilderij.transform.localPosition;                                  //Update de variabele sPos voor de nieuwe lerp.
                start = sPos;                                                        //Update de start variabele, vanaf die positie begint de beweging.
                eind = start + (schilderij.transform.forward * afstand);
                sC = c;
                eC = new Color(c.r, c.g, c.b, 0);
                GetComponent<ActivatePlacableChildren>().HideKids();
            }

            if (sPos == Vector3.zero && heen == false)
            {
                sPos = schilderij.transform.localPosition;
                start = sPos;
                eind = start - (schilderij.transform.forward * afstand);
                sC = new Color(c.r, c.g, c.b, 0);
                eC = c;
            }

            schilderij.transform.localPosition = Vector3.Lerp(start, eind, t);
            t += snelheid * Time.deltaTime;
            sprite.color = Color.Lerp(sC, eC, t * 3);


            if (Vector3.Distance(schilderij.transform.position, eind) < .02f)
            {
                if (!heen)
                {
                    GetComponent<ActivatePlacableChildren>().HideKids();
                }
                lerp1 = false;
                testLerp = false;
                schilderij.transform.localPosition = eind;
                sPos = Vector3.zero;
                heen = !heen;
                t = 0f;
            }
        }
    }
}
