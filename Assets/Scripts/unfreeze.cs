using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unfreeze : MonoBehaviour
{
    public MeshRenderer meshRenderer;
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
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Item") || collision.collider.gameObject.layer == LayerMask.NameToLayer("itemMask"))
        {
            meshRenderer = collision.collider.gameObject.GetComponent<MeshRenderer>();
            meshRenderer.material.color = new Color(0,0,0);

            collision.rigidbody.constraints = RigidbodyConstraints.None;

        }



    }
}
