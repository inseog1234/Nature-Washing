using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    Camera cam;
    Rigidbody2D rb;

    void Awake()
    {
        Cursor.visible = false;
        if (Cursor.visible == false) Debug.Log("커서 사라짐");
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(mousePos);
    }
}
