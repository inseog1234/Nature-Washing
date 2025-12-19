using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour
{
    public float brushRadius = 0.2f;      // 브러시 반경 (월드 기준)
    public Color brushColor = Color.red;  // 칠할 색

    private Texture2D tex;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // 원본 텍스처를 복사해서 변경 가능하도록 함
        tex = Instantiate(sr.sprite.texture);
        tex.Apply();

        // 새 텍스처로 교체
        sr.sprite = Sprite.Create(
            tex,
            sr.sprite.rect,
            new Vector2(0.5f, 0.5f),
            sr.sprite.pixelsPerUnit
        );
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PaintAtMouse();
        }
    }

    void PaintAtMouse()
    {
        // 마우스 월드 좌표
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 스프라이트 로컬 좌표
        Vector2 localPos = transform.InverseTransformPoint(mouseWorldPos);

        // 스프라이트 픽셀 좌표로 변환
        Vector2 pivot = sr.sprite.pivot;
        float ppu = sr.sprite.pixelsPerUnit;

        int px = Mathf.RoundToInt(pivot.x + localPos.x * ppu);
        int py = Mathf.RoundToInt(pivot.y + localPos.y * ppu);

        // 픽셀 반경으로 변환
        int radius = Mathf.RoundToInt(brushRadius * ppu);

        // 원형 브러시 영역 픽셀 칠하기
        for (int x = -radius; x < radius; x++)
        {
            for (int y = -radius; y < radius; y++)
            {
                if (x * x + y * y > radius * radius) continue; // 원형 체크

                int tx = px + x;
                int ty = py + y;

                if (tx < 0 || tx >= tex.width || ty < 0 || ty >= tex.height)
                    continue;

                tex.SetPixel(tx, ty, brushColor);
            }
        }

        tex.Apply();
    }
}