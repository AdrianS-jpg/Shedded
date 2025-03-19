using UnityEngine;

public class targetcolliderscript : MonoBehaviour
{
    public BoxCollider2D hurtbox;
    public boxeslol boxeslol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hurtbox = GetComponent<BoxCollider2D>();
        hurtbox.enabled = true;
        boxeslol.hurtboxList.Add(hurtbox);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
