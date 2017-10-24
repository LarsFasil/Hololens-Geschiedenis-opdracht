using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehaviourScript : MonoBehaviour
{
    public bool testLerp = false;
    public static bool lerp1;
    private float t;
    private bool heen = true;
    public float afstand = 5.0f;
    public float snelheid = .4f;
    public GameObject schilderij;
    private Vector3 sPos, begin, eind, start;
    public SpriteRenderer sprite;
    private Color c, sC, eC;

    void Start()
    {
        c = sprite.color;
        lerp1 = false;
        t = 0f;
        sPos = Vector3.zero;


    }

    void Update()
    {
        BGLerp();
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
            sprite.color = Color.Lerp(sC, eC, t *3);


            if (Vector3.Distance(schilderij.transform.position, eind) < .02f)
            {
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
