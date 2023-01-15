using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    float reloadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !hasCrashed){
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            // Debug.Log("GROUND!!");
            Invoke("reloadScene", reloadDelay);
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
        }
    }

    void reloadScene(){
        SceneManager.LoadScene(0);
    }
}
