using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    [SerializeField] Texture2D cursorImg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.Auto);
    }

    
}
