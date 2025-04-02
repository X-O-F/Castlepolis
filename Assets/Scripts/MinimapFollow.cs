using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform target; // Drag your player here

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPos = target.position;
            newPos.z = transform.position.z; // Keep camera height
            newPos.y = transform.position.y; // Optional: keep height constant if top-down
            transform.position = newPos;
        }
    }
}
