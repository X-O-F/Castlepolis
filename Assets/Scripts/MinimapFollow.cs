using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform target;

    void LateUpdate()
    {
        if (target != null)
        {
            // Keep the camera at the player's X and Y position, but keep Z fixed
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }
    }
}
