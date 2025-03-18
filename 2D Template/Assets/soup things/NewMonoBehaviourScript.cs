using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public BoxCollider2D hitbox;
    public BoxCollider2D hurtbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hurtbox = GetComponent<BoxCollider2D>();
        hitbox = GetComponent<BoxCollider2D>();
        hurtbox.enabled = true;
        hitbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hurtbox.IsTouching(hitbox))
        {

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
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
