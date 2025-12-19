using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField] public Texture2D texture;
    [SerializeField] public SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        // PaintManager에게 자동 등록
        //PaintManager.Register(this);

        // 원본 텍스처 복사
        Texture2D source = sr.sprite.texture;
        texture = new Texture2D(source.width, source.height, TextureFormat.RGBA32, false);
        texture.SetPixels(source.GetPixels());
        texture.Apply();

        // 새 스프라이트 연결
        sr.sprite = Sprite.Create(
            texture,
            sr.sprite.rect,
            new Vector2(0.5f, 0.5f),
            sr.sprite.pixelsPerUnit
        );
    }

    private void OnDestroy()
    {
        //PaintManager.Unregister(this);
    }

    public void PaintAtUV(Vector2 uv, float radius, Color color)
    {
        int px = (int)(uv.x * texture.width);
        int py = (int)(uv.y * texture.height);

        int r = Mathf.RoundToInt(radius);

        for (int x = -r; x <= r; x++)
        {
            for (int y = -r; y <= r; y++)
            {
                int tx = px + x;
                int ty = py + y;

                if (tx < 0 || ty < 0 || tx >= texture.width || ty >= texture.height)
                    continue;

                if (x * x + y * y <= r * r)
                    texture.SetPixel(tx, ty, color);
            }
        }

        texture.Apply();
    }
}
