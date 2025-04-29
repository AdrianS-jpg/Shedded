using UnityEngine;
using UnityEngine.InputSystem;

public class upgrade : MonoBehaviour
{
    static public bool healthOnKillBool = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healthOnKillAct()
    {
        healthOnKillBool = true;
    }

    public void healthOnKillThing()
    {
        if (PlayerHealth.maxHealth > PlayerHealth.health)
        {
            PlayerHealth.health += 1;
        }
        
    }

    public void increasedKnockback() { 
        
    }
}
