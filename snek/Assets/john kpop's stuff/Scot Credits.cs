using UnityEngine;
using UnityEngine.SceneManagement;

public class ScotCredits : MonoBehaviour
{
    public void OnRightArrowButton()
    {
        SceneManager.LoadScene("Cerese Credits");
    }

    public void OnLeftArrowButton()
    {
        SceneManager.LoadScene("Faith Credits");
    }

    public void OnExitButton()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
