using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class healthChnage : MonoBehaviour
{
    public List<Sprite> healths = new List<Sprite>();
    public GameObject healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.health != 0)
        {
            healthBar.GetComponent<SpriteRenderer>().sprite = healths[PlayerHealth.health - 1];
        } else
        {
            healthBar.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
