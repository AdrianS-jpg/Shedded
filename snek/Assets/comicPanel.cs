using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class comicPanel : MonoBehaviour
{
    public NewMonoBehaviourScript canvas;
    public bool click = false;
    public SpriteRenderer spr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        click = false;
        spr = GetComponent<SpriteRenderer>();
        canvas = GameObject.Find("Canvas").GetComponent<NewMonoBehaviourScript>();
        spr.color = new Color (spr.color.r,spr.color.g,spr.color.b,0);
        spr.sprite = canvas.comicImages[NewMonoBehaviourScript.number];
        transform.localPosition = NewMonoBehaviourScript.comicPlaces[NewMonoBehaviourScript.number];
        NewMonoBehaviourScript.number++;
        StartCoroutine(fade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fade()
    {   
        while (spr.color.a < 1.0f)
        {
           
            if (click == true)
            {
                spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 1f);
                Instantiate(gameObject, new Vector2(0,0), Quaternion.identity, canvas.transform);
                yield break;
            } else
            {
                spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, spr.color.a + 0.02f);
            }
            if (Input.GetMouseButtonDown(0)) {
                click = true;

            }
            yield return new WaitForSeconds(0.05f);
            Debug.Log("s");
        }
        Instantiate(gameObject, new Vector2(0, 0), Quaternion.identity, canvas.transform);
        if (NewMonoBehaviourScript.number == 2 || NewMonoBehaviourScript.number == 6 || NewMonoBehaviourScript.number == 10 || NewMonoBehaviourScript.number == 13)
        {
           canvas.DestroyallChildern();
            Instantiate(gameObject, new Vector2(0, 0), Quaternion.identity, canvas.transform);
        } 
       
        yield break;
    }

    private void OnMouseDown()
    {
        click = true;
    }
}
