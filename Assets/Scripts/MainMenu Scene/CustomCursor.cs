using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Vector2 hotSpot = Vector2.zero;
    public float cursorScale = 2.0f; // Adjust this value to make the cursor bigger

    void Start()
    {
        if (cursorTexture != null)
        {
            // Scale the cursor manually
            Texture2D scaledCursor = ResizeTexture(cursorTexture, (int)(cursorTexture.width * cursorScale), (int)(cursorTexture.height * cursorScale));
            Cursor.SetCursor(scaledCursor, hotSpot, CursorMode.Auto);
        }
    }

    private Texture2D ResizeTexture(Texture2D source, int newWidth, int newHeight)
    {
        RenderTexture rt = RenderTexture.GetTemporary(newWidth, newHeight);
        Graphics.Blit(source, rt);
        Texture2D result = new Texture2D(newWidth, newHeight);
        RenderTexture.active = rt;
        result.ReadPixels(new Rect(0, 0, newWidth, newHeight), 0, 0);
        result.Apply();
        RenderTexture.ReleaseTemporary(rt);
        return result;
    }
}
