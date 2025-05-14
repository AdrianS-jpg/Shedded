using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] 
    static public int maxHealth = 6;
    static public int health;
    static public bool isHit = false;
    public Animator animator;
    // public Slider slider;
    public EnemyMovement eM;

    [Header("Post Processing")]
    PostProcessVolume p_Volume;
    Vignette p_Vignette;
    ChromaticAberration p_Chrome;

    void Start()
    {
        isHit = false;
        health = maxHealth;
        // slider.maxValue = maxHealth;
        // slider.value = health;

        p_Vignette = ScriptableObject.CreateInstance<Vignette>();
        p_Vignette.enabled.Override(true);
        p_Vignette.intensity.Override(1f);

        p_Chrome = ScriptableObject.CreateInstance<ChromaticAberration>();
        p_Chrome.enabled.Override(true);
        p_Chrome.intensity.Override(1f);

        p_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, p_Vignette);
    }

    void Update()
    {
        //slider.value = health;

        if (health <= 0)
        {
            Die();
        }

        if (isHit == true)
        {
            p_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);

            p_Chrome.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
        }
         


    }
    public void Damage()
    {
        health -= 1;
        StartCoroutine(Damagei());
    }

    //private void OnDestroy()
    //{
    //    RuntimeUtilities.DestroyVolume(p_Volume, true, true);
    //}

    private void Die()
    {
        Debug.Log("You Died!");
        health = 6;
        SceneManager.LoadScene("Lose screen");

        // The load scene is here for when we wanna implement it

        //this was being annoying when testing, removed for now
        //he annoying af bro idk why he calls when i RESET THE SCENE BUT OK I GUESS DO YOUR OWN THING
        }
    //this is optimal i promise
    IEnumerator Damagei()
    {

        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(Flashing());
        animator.SetBool("attacking", false);
        GetComponent<Movement>().canDash = false;
        isHit = true;
        gameObject.GetComponent<Movement>().enabled = true;
        yield return new WaitForSeconds(1.5f);
        isHit = false;
        GetComponent<Movement>().movementSpeed = 5;
        GetComponent<Movement>().canDash = true;
        yield break;
    }

    IEnumerator Flashing()
    {
        for (int i = 0; i <= 15; i++)
        {
            if (GetComponent<SpriteRenderer>().color == Color.red) 
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            } else {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            yield return new WaitForSeconds(0.1f);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        yield break;
    }

}

