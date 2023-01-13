using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustEffect;

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            // Debug.Log("Play the snow thing");
            dustEffect.Play();
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            // Debug.Log("Stahp the snow thing");
            dustEffect.Stop();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
