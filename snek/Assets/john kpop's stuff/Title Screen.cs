using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Globalization;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public new List<Sprite> comicImages = new List<Sprite>();
    [SerializeField]
    static public new List<Vector2> comicPlaces = new List<Vector2>()
    {
    new Vector2(-391,0),
    new Vector2(444,0),
    new Vector2(0,235),
    new Vector2(-457,-235),
    new Vector2(143,-235),
    new Vector2(600,-235),
    new Vector2(-417,163),
    new Vector2(417,163),
    new Vector2(0,-217),
    new Vector2(0,-380),
    new Vector2(-484,0),
    new Vector2(0,0),
    new Vector2(492,0),
    new Vector2(0,214),
    new Vector2(-418,-256),
    new Vector2(417,-256),
    };
    static public int number = 0;
    public GameObject comicPanel;

    public void Update()
    {
        if (number == 2 || number == 6)
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<comicPanel>().enabled = true;
        }
    }
    public void OnStartButton ()
    {
        DestroyallChildern();
        Instantiate(comicPanel, comicPlaces[0], Quaternion.identity, gameObject.transform);
    }

    public void DestroyallChildern()
    {
        for (int i = gameObject.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
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
