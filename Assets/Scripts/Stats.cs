using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Stats")]
public class Stats : ScriptableObject
{
    // Start is called before the first frame update
    public float Velocity;
    public float damage;
    public float hardness;
    public float bouncy;
}
