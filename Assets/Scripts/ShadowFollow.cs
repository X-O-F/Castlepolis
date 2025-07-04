using UnityEngine;

public class ShadowFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0, -0.1f, 0);

    void Update()
    {
        if (_target != null)
        {
            transform.position = _target.position + _offset;
        }
    }

    // Optional: If you want to set the target via script too
    public void SetTarget(Transform newTarget)
    {
        _target = newTarget;
    }
}
