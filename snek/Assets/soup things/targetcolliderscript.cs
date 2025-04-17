using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class targetcolliderscript : MonoBehaviour
{
    public PolygonCollider2D hitbox;
    public CapsuleCollider2D hurtbox;
    public boxeslol boxeslol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hurtbox.enabled = true;
        hitbox.enabled = true;
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

}
