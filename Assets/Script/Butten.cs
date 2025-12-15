using UnityEngine;
using UnityEngine.SceneManagement;

public class Butten : MonoBehaviour
{
    public void StartGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void TestButten()
    {
        SceneManager.LoadScene(0);
    }
}
