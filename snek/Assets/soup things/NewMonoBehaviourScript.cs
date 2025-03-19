using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public BoxCollider2D hitbox;
    public BoxCollider2D hurtbox;
    public boxeslol boxeslol;
    public int health = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        hurtbox = GetComponent<BoxCollider2D>();
        hitbox = GetComponent<BoxCollider2D>();
        hurtbox.enabled = true;
        hitbox.enabled = false;
        boxeslol.hurtboxList.Add(hurtbox);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < boxeslol.hurtboxList.Count; i++)
        {
            if (hitbox.IsTouching(boxeslol.hurtboxList[i]))
            {
                Debug.Log("asasdfasasdfasdfsadfsaddf");
                health = health - 3;
            }
        }
    }

    //public void OnCollisionEnter2D(BoxCollider2D coll)
    //{
    //    for (int i = 0; i < boxeslol.hurtboxList.Count; i++)
    //    {
    //        if (boxeslol.hurtboxList[i] == coll)
    //        {
    //            health = health - 3;
    //            break;
    //        }
    //    }
    //}

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
