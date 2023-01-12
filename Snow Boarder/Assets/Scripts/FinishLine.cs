using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    float reloadDelay = 1f;
    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("Player crossed the Finish Line");
            Invoke("reloadScene", reloadDelay);
        }
    }

   void reloadScene(){
        SceneManager.LoadScene(0);
   }
}
