using UnityEngine;
using UnityEngine.SceneManagement;
public class win : MonoBehaviour
{
   

   
        public string player = "Player"; // The tag of the object that triggers the game reset
        // Reference to the game manager script

        private void OnCollisionEnter(Collision collision)
        {
        Debug.Log(collision.gameObject);
            if (collision.gameObject)
            {
            Debug.Log("won");
            SceneManager.LoadScene("SampleScene");
            }
        }
    }
