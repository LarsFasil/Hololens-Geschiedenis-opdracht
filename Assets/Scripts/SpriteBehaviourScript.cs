using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehaviourScript : MonoBehaviour
{
    public bool testLerp = false;
    public static bool lerp1;
    private float t, eind, start;
    private bool heen = true;
    public float afstand = 5.0f;
    public float snelheid = .4f;
    public GameObject schilderij;
    private Vector3 sPos, begin;
    public SpriteRenderer sprite;
    private Color c, sC, eC;
    private float alphaLevel = 255;

    void Start()
    {
        c = sprite.color;
        lerp1 = false;
        t = 0f;
        //begin = schilderij.transform.position;
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
                sPos = schilderij.transform.position;                                  //Update de variabele sPos voor de nieuwe lerp.
                start = sPos.z;                                                        //Update de start variabele, vanaf die positie begint de beweging.
                eind = start + afstand;
                sC = c;
                eC = new Color(c.r, c.g, c.b, 0);
            }

            if (sPos == Vector3.zero && heen == false)
            {
                sPos = schilderij.transform.position;
                start = sPos.z;
                eind = start - afstand;
                sC = new Color(c.r, c.g, c.b, 0);
                eC = c;
            }

            sPos = new Vector3(sPos.x, sPos.y, Mathf.Lerp(start, eind, t));            //Sla nieuwe positie op in sPos.
            schilderij.transform.position = sPos;                                      //Update de echte positie van het schilderij.
            t += snelheid * Time.deltaTime;                                            //Update de tijd die de lerp erover moet doen.
            sprite.color = Color.Lerp(sC, eC, t);
            //sprite.color = new Color(c.r, c.g, c.b, alphaLevel);
            //alphaLevel -= 1f;

            if (Mathf.Abs(eind - schilderij.transform.position.z) < 0.02f)             //Als het schilderij minder dan 0.02 units van het einde is verwijdert springt hij gelijk naar het eind.
            {
                Debug.Log("done");
                lerp1 = false;
                testLerp = false;
                schilderij.transform.position = new Vector3(sPos.x, sPos.y, eind);
                sPos = Vector3.zero;
                heen = !heen;
                t = 0f;
            }
        }
    }
}
