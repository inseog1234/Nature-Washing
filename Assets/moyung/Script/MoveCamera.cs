using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private CinemachineCamera[] cameras;
    [SerializeField] FadeEffect fadeEffect;

    private int cameraIdx = 0;
    private bool isDelay;

    void Start()
    {
        SetCamera(cameraIdx);
        isDelay = false;
    }

    public void CameraMoveLeft()
    {
        if (isDelay == true) return;

        fadeEffect.OnFade(FadeState.FadeInOut);

        cameraIdx = (cameraIdx + 1) % cameras.Length;
        SetCamera(cameraIdx);

        StartCoroutine(Delay(1f));
    }

    public void CameraMoveRight()
    {
        if (isDelay == true) return;

        fadeEffect.OnFade(FadeState.FadeInOut);

        cameraIdx = (cameraIdx - 1 + cameras.Length) % cameras.Length;

        SetCamera(cameraIdx);

        StartCoroutine(Delay(1f));
    }

    private void SetCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].Priority = (i == index) ? 10 : 0;
        }
    }

    private IEnumerator Delay(float time)
    {
        isDelay = true;
        yield return new WaitForSeconds(time);
        isDelay = false;
    }
}
