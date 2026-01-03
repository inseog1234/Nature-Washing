using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum FadeState { FadeIn = 0, FadeOut, FadeInOut, FadeLoop };

public class FadeEffect : MonoBehaviour
{
    private Image image; 
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;
    [SerializeField] AnimationCurve fadeCurve;
    private FadeState fadeState;


    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnFade(FadeState state)
    {
        fadeState = state;

        switch (fadeState)
        {
            case FadeState.FadeIn:
                StartCoroutine(Fade(1, 0));
                break;
            case FadeState.FadeOut:
                StartCoroutine(Fade(0, 1));
                break;
            case FadeState.FadeInOut:
            case FadeState.FadeLoop:
                StartCoroutine(FadeInOUt());
                break;
        }
    }

    private IEnumerator FadeInOUt()
    {
        while (true)
        {
            yield return StartCoroutine(Fade(0, 1)); //fade in

            yield return StartCoroutine(Fade(1, 0)); //fade out

            if( fadeState == FadeState.FadeInOut)
            {
                break;
            }
        }
    }

    // Update is called once per frame
    public IEnumerator Fade(float start, float end)
    {
        float currentTime   = 0.0f;
        float percent       = 0.0f;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color color = image.color;
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));
            image.color = color;

            yield return null;
        }
    }
    
    public float Get_dd()
    {
        return fadeTime;
    }

}
