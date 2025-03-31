using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void OnMenuButton()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
