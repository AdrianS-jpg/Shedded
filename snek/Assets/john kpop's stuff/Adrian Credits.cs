using UnityEngine;
using UnityEngine.SceneManagement;

public class AdrianCredits : MonoBehaviour
{
    public void OnRightArrowButton()
    {
        SceneManager.LoadScene("Faith Credits");
    }

    public void OnLeftArrowButton()
    {
        SceneManager.LoadScene("Ember Credits");
    }

    public void OnExitButton()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
