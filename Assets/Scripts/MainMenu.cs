using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public Scene scene;
    public string sceneName;
    public void Quit()
    {
        Application.Quit();
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
