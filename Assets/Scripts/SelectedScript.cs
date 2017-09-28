using UnityEngine;

public class SelectedScript : MonoBehaviour
{
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            SpriteBehaviourScript.ScriptSelected(transform.parent.transform);

            //var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            //rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }
}