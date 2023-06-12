using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour, IInteractable
{
    private Rigidbody _rb;
    
    private bool interactedWith = false;
    private UnityEngine.Collider coll;
    public Stats _stats;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<UnityEngine.Collider>();
        _rb = GetComponent<Rigidbody>();

        
        if (_stats.bouncy > 0)
        {

            coll.material.bounciness = 1;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        CanThrow();
      
    }

    public void Interact()
    {
        if (interactedWith == false)
        {
            interactedWith = true;
            

            gameObject.transform.parent = Camera.main.transform;
            //gameObject.transform.position = Player.transform.position;
            _rb.isKinematic = true;
            gameObject.transform.rotation = Camera.main.transform.rotation;

            gameObject.layer = LayerMask.NameToLayer("Item");

        } else if (interactedWith == true)
        {

            interactedWith = false;
            _rb.isKinematic = false;
            gameObject.transform.parent = null;
        }
    }


    private void CanThrow()
    {
        
        if (interactedWith == true)
        {
            

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("throwing");
                interactedWith = false;
                _rb.isKinematic = false;
                gameObject.transform.parent = null;
                _rb.AddForce(Camera.main.transform.forward * _stats.Velocity, ForceMode.Impulse);


            }
        }
    } 
}
