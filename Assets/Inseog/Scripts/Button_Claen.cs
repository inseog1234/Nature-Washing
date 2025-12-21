using UnityEngine;

public class Button_Claen : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] private RectTransform Dirt;

    private float Dirt_Width_Target;
    private Vector2 Dirt_Width_Anim_Velocity;
    private float Dirt_Width_Anim_Time;

    private void Start()
    {
        
    }

    private void Update()
    {
        Dirt.sizeDelta = Vector2.SmoothDamp(Dirt.sizeDelta, new Vector2(Dirt_Width_Target, Dirt.sizeDelta.y), ref Dirt_Width_Anim_Velocity, Dirt_Width_Anim_Time);
    }

    public void Set_Anim(float Target, float Time = 0.1f)
    {
        Dirt_Width_Target = Target;
        Dirt_Width_Anim_Time = 0.1f;
        Dirt_Width_Anim_Velocity = Vector2.zero;
    }
}
