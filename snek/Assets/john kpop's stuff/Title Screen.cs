using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    
    public void OnStartButton ()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OnCreditsButton ()
    {
        SceneManager.LoadScene("Cerese Credits");
    }

    public void OnQuitButton ()
    {
        Application.Quit();
    }
}
