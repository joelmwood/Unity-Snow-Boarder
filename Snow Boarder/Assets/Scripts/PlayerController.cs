using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;

    public bool canMove = true;

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
        // QuitGame();
    }

    void RotatePlayer()
    {
        if (moveInput.x == -1)
        {
            rb2d.AddTorque(torqueAmount, ForceMode2D.Impulse);
        }
        else if (moveInput.x == 1)
        {
            rb2d.AddTorque(-(torqueAmount), ForceMode2D.Impulse);
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnBoost(InputValue value)
    {
        if (canMove)
        {
            // Debug.Log("You pressed the boost button!");
            surfaceEffector2D.speed = boostSpeed;
            Invoke("ResetSpeed", baseSpeedResetDelay);
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
    // public void EnableControls(){
    //     canMove = true;
    // }


    void RespondToBoost()
    {

    }

    void ResetSpeed()
    {
        surfaceEffector2D.speed = baseSpeed;
    }


    // void QuitGame(){
    //     if(Input.GetKey(KeyCode.Escape)){
    //         Debug.Log("Quit?");
    //     }
    // }
}
