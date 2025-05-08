using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public static Audio instance = null;


    public static Audio Instance
    {
        get { return instance; }
    }

    private void Awake()
    {

        if (instance != null)
        {
            Destroy(this.gameObject);
          
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
       
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            Audio.instance.GetComponent<AudioSource>().Pause();
        }
    }

}
