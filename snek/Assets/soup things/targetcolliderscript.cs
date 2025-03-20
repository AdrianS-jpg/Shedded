using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class targetcolliderscript : MonoBehaviour
{
    public CircleCollider2D hitbox;
    public BoxCollider2D hurtbox;
    public boxeslol boxeslol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hurtbox.enabled = true;
        hitbox.enabled = false;
        GameObject.Find("enemy").GetComponent<Enemy>().targetList.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (hitbox.IsTouching(GameObject.Find("enemy").GetComponent<Enemy>().hurtbox) == true)
        {
            Debug.Log("asasdfasasdfasdfsadfsaddf");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnMouseDown()
    {
        Debug.Log("adasdfas");
        if (hitbox.enabled == true)
        {
            hitbox.enabled = false;
        }
        else
        {
            hitbox.enabled = true;
        }

    }

    IEnumerator Attack()
    {
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            yield return null;
        }
    }
}
