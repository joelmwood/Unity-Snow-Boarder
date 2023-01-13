using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    float reloadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            finishEffect.Play();
            Debug.Log("Player crossed the Finish Line");
            Invoke("reloadScene", reloadDelay);
            GetComponent<AudioSource>().Play();
        }
    }

   void reloadScene(){
        SceneManager.LoadScene(0);
   }
}
