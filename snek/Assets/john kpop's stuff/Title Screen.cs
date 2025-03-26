using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void OnStartButton ()
    {
        SceneManager.LoadScene("Faith");
    }

    public void OnCreditsButton ()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }
}
