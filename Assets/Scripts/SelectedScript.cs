using UnityEngine;

public class SelectedScript : MonoBehaviour
{

    private bool holding = false;

    void OnHoldStart()
    {
        holding = true;
        //SpatialMapping.Instance.DrawVisualMeshes = true;
    }

    void OnHoldCompleted()
    {
        //SpatialMapping.Instance.DrawVisualMeshes = false;
        holding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (holding)
        {
            transform.parent.position = Camera.main.transform.position + Camera.main.transform.forward * 2.0f;
        }
    }
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        transform.parent.parent = null;             //Maakt zichzelf los van zn parent object (schilderij)
        SpriteBehaviourScript.lerp1 = true;         //Zegt tegen spritebehaviourscript dat de lerp moet beginne.

    }

}