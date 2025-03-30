using UnityEngine;

public class YSort : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
    }
}
