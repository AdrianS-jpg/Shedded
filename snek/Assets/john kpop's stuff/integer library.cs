using UnityEngine;

[CreateAssetMenu(fileName = "integerlibrary", menuName = "Scriptable Objects/integerlibrary")]
public class integerlibrary : ScriptableObject
{
    public float playerSpeed = 10f;
    public float playerHealth = 100;
    public float  enemyAmount= 100;
    public float enemyHealth= 100;
    public float enemySpeed = 10f; 
}
