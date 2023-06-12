using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactmovement : MonoBehaviour
{
    //Cam
    private GameObject _eyes;

    //Interact
    [SerializeField] public KeyCode _interactKey;
    [SerializeField] private float interactRange;
    [SerializeField] private GameObject interactVisual;


    //Masks
    [SerializeField] private LayerMask chestMask;
    [SerializeField] private LayerMask itemMask;

    

    void Start()
    {
        _eyes = GameObject.Find("PlayerCamera");
    }

    // Update is called once per frame
    void Update()
    {
        CanInteract();
        if (Input.GetKeyDown(_interactKey))
        {
            TryInteract();
            
        }
    }
    private void TryInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(_eyes.transform.position, _eyes.transform.forward, out hit, interactRange))
        {
            IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
    private void CanInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(_eyes.transform.position, _eyes.transform.forward, out hit, interactRange, chestMask) || Physics.Raycast(_eyes.transform.position, _eyes.transform.forward, out hit, interactRange, itemMask))
        {
            interactVisual.SetActive(true);
        }
        else
        {
            interactVisual.SetActive(false);
        }

    }


}
