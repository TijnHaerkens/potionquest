using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour
{
    private Vector3 oldSize;
    private Vector3 newSize;
    private GameObject effectObject;
    public float effectGreatness = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Effect()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        MeshRenderer ms = gameObject.GetComponent<MeshRenderer>();

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            //creates old size of the object collided with
            oldSize = collision.collider.gameObject.transform.localScale;

            //creates a link with own object effect greatness
            Colliding myscript = gameObject.GetComponent<Colliding>();
            newSize = collision.collider.gameObject.transform.localScale * myscript.EffectGreatness;

            effectObject = collision.collider.gameObject;

            StartCoroutine(scaleOverTime(effectObject, newSize, 1f));

            ms.enabled = false;

            if (collision.collider.gameObject.tag == ("Potion"))
            {
                Colliding potionScript = collision.collider.gameObject.GetComponent<Colliding>();
                potionScript.EffectGreatness = potionScript.EffectGreatness * myscript.EffectGreatness;
            }
        }

    }
    bool isScaling = false;

    IEnumerator scaleOverTime(GameObject effect, Vector3 toScale, float duration)
    {

        //Make sure there is only one instance of this function running
        if (isScaling)
        {
            yield break; ///exit if this is still running
        }
        isScaling = true;

        float counter = 0;

        //Get the current scale of the object to be moved
        Vector3 startScaleSize = effect.transform.localScale;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            effect.transform.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
            yield return null;
        }


        isScaling = false;
        Destroy(gameObject);
    }
}
