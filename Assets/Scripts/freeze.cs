using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class freeze : MonoBehaviour
{

    public MeshRenderer meshRenderer;
    public Texture iceTexture;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void effect()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        meshRenderer = collision.collider.gameObject.GetComponent<MeshRenderer>();

        

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Item") || collision.collider.gameObject.layer == LayerMask.NameToLayer("itemMask"))
        {
            meshRenderer.material.color = new Color(0.5509434f, 0.9227951f, 1f);


            meshRenderer.material.SetTexture("_DetailMask", iceTexture);
            meshRenderer.material.SetTexture("_DetailAlbedoMap", iceTexture);
            meshRenderer.material.SetTexture("_DetailNormalMap", iceTexture);

            
            collision.rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            
        }

         
        
    }
}
