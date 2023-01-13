using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 1f;

    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float boostSpeed = 24f;
    [SerializeField] float baseSpeed = 12f;
    float baseSpeedResetDelay = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();

    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
        // QuitGame();
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-(torqueAmount));
        }
    }
    void RespondToBoost(){
        if(Input.GetKey(KeyCode.Space )){
            // Debug.Log("You pressed the boost button!");
            surfaceEffector2D.speed = boostSpeed;
            Invoke("ResetSpeed", baseSpeedResetDelay);
        }
    }

    void ResetSpeed(){
        surfaceEffector2D.speed = baseSpeed;
    }

    // void QuitGame(){
    //     if(Input.GetKey(KeyCode.Escape)){
    //         Debug.Log("Quit?");
    //     }
    // }
}
