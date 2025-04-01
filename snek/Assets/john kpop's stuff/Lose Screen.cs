using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{

    public void OnRetryButton()
    {
        SceneManager.LoadScene("Faith");
    }
    public void OnMenuButton ()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
