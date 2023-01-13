using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    float reloadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground"){
            crashEffect.Play();
            Debug.Log("GROUND!!");
            Invoke("reloadScene", reloadDelay);
        }
    }

    void reloadScene(){
        SceneManager.LoadScene(0);
    }
}
