using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "boxeslol", menuName = "Scriptable Objects/boxeslol")]
public class boxeslol : ScriptableObject
{
    public List<Collider2D> hitboxList = new List<Collider2D>();
    public List<GameObject> hurtboxList = new List<GameObject>();
}
