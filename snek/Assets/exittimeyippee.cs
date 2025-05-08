using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exittimeyippee : MonoBehaviour
{

    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("d");
        if (collision.gameObject == player)
        {
            Debug.Log("as");
            SceneManager.LoadScene("Win screen");
        }

    }
}
