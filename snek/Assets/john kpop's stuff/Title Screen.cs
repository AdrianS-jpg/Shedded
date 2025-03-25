using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void OnStartButton ()
    {
        SceneManager.LoadScene("Faith");
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }
}
