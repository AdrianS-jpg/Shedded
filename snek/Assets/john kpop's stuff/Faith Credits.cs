using UnityEngine;
using UnityEngine.SceneManagement;

public class FaithCredits : MonoBehaviour
{
    public void OnRightArrowButton()
    {
        SceneManager.LoadScene("Scot Credits");
    }

    public void OnLeftArrowButton()
    {
        SceneManager.LoadScene("Adrian Credits");
    }

    public void OnExitButton()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
