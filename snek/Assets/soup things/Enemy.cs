using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    public CircleCollider2D hitbox;
    public BoxCollider2D hurtbox;
    public boxeslol boxeslol;
    public int health = 50;
    public List<GameObject> targetList = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        hurtbox.enabled = true;
        hitbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitbox == hurtbox)
        {
            Debug.Log("tiohtoiert");
        }

        if (hitbox.IsTouching(GameObject.Find("target").GetComponent<targetcolliderscript>().hurtbox) == true){
            Debug.Log("asasdfasasdfasdfsadfsaddf");
            health = health - 3;
        }
        
    }

    private void OnMouseEnter()
    {
        Debug.Log("asfasdfasdf");
    }

    private void OnMouseDown()
    {
        Debug.Log("adasdfas");
        if (hitbox.enabled == true) {
            hitbox.enabled = false;
        } else
        {
            hitbox.enabled = true;
        }

    }
}
