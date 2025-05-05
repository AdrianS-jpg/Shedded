using UnityEngine;
using UnityEngine.SceneManagement;

public class CereseCredits : MonoBehaviour
{

    public void OnRightArrowButton()
    {
        SceneManager.LoadScene("Ember Credits");
    }

    public void OnLeftArrowButton()
    {
        SceneManager.LoadScene("Scot Credits");
    }

    public void OnExitButton()
    {
        SceneManager.LoadScene("Title Screen");
    }

}
