using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBehaviourScript : MonoBehaviour
{

    public bool lerp1;
    private float t, eind, start;
    public float afstand = 90.0f;
    public float snelheid = .3f;
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
        if (lerp1)
        {
            if (sPos == Vector3.zero)
            {
                sPos = schilderij.transform.position;
                start = sPos.z;
                if (start > begin.z)
                {
                    eind = start - afstand;
                }
                else
                {
                    eind = start + afstand;
                }
            }

            sPos = new Vector3(sPos.x, sPos.y, Mathf.Lerp(start, eind, t));
            schilderij.transform.position = sPos;
            t += snelheid * Time.deltaTime;

            if (Mathf.Abs(eind - schilderij.transform.position.z) < 0.02f)
            {
                lerp1 = false;
                schilderij.transform.position = new Vector3(sPos.x, sPos.y, eind);
                sPos = Vector3.zero;
                t = 0f;
            }
        }
    }
}
