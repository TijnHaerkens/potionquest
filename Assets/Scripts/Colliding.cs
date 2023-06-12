using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliding : MonoBehaviour
{
   

    private Vector3 oldSize;
    private Vector3 newSize;
    private GameObject effectObject;
    public float EffectGreatness = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter(Collision collision)
    {


        Effect effect = collision.collider.gameObject.GetComponent<Effect>();



    }
}
