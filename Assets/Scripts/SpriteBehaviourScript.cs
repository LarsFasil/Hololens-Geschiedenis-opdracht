using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehaviourScript : MonoBehaviour
{

    public static bool lerp1;
    private float t, eind, start;
    public float afstand = 90.0f;
    public float snelheid = .4f;
    public GameObject schilderij;
    private Vector3 sPos, begin;

    void Start()
    {
        lerp1 = false;
        t = 0f;
        begin = schilderij.transform.position;
        sPos = Vector3.zero;
    }

    void Update()
    {
        BGLerp();
    }

    public void BGLerp()
    {
        if (lerp1)                                                      //Als de public static bool lerp1 'true' word begint de sequence van de rest van het schilderij naar achter werken.
        {
            if (sPos == Vector3.zero)                                   //Deze if statement zorgt ervoor dat je met 1 bool(lerp1) de achtergrond beide kanten op kan laten gaan. En reset wat nodige variabele.
            {
                sPos = schilderij.transform.position;                   //Update de variabele sPos voor de nieuwe lerp.
                start = sPos.z;                                         //Update de start variabele, vanaf die positie begint de beweging.
                if (start > begin.z)                                    //Checkt welke kant die op moet bewegen en kiest een eind positie.
                {
                    eind = start - afstand;
                }
                else
                {
                    eind = start + afstand;
                }
            }

            sPos = new Vector3(sPos.x, sPos.y, Mathf.Lerp(start, eind, t));            //Sla nieuwe positie op in sPos.
            schilderij.transform.position = sPos;                                      //Update de echte positie van het schilderij.
            t += snelheid * Time.deltaTime;                                            //Update de tijd die de lerp erover moet doen.

            if (Mathf.Abs(eind - schilderij.transform.position.z) < 0.02f)             //Als het schilderij minder dan 0.02 units van het einde is verwijdert springt hij gelijk naar het eind.
            {
                lerp1 = false;                                                         //
                schilderij.transform.position = new Vector3(sPos.x, sPos.y, eind);     //
                sPos = Vector3.zero;                                                   //           reset wat andere variabele
                t = 0f;                                                                //
            }
        }
    }
}
