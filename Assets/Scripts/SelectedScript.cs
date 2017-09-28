using UnityEngine;

public class SelectedScript : MonoBehaviour
{
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        transform.parent.parent = null;
        SpriteBehaviourScript.lerp1 = true;
       
    }
}