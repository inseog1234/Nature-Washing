using UnityEngine;
using UnityEngine.SceneManagement;

public class Butten : MonoBehaviour
{
    int j = 0;
    private int[] cameraIdx = new int[4];

    public void StartGameScene()
    {
        SceneManager.LoadScene(1);
    }

}
