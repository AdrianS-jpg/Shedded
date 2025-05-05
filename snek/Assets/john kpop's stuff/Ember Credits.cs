using UnityEngine;
using UnityEngine.SceneManagement;

public class EmberCredits : MonoBehaviour
{
    public void OnRightArrowButton()
    {
        SceneManager.LoadScene("Adrian Credits");
    }

    public void OnLeftArrowButton()
    {
        SceneManager.LoadScene("Cerese Credits");
    }

    public void OnExitButton()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
