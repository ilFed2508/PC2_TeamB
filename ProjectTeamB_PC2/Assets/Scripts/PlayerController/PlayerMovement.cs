using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Player controller reference
    /// </summary>
    public CharacterController controller;
    /// <summary>
    /// Player speed while on the Ground
    /// </summary>
    public float GroundSpeed;
    /// <summary>
    /// Player speed while in air
    /// </summary>
    public float AirSpeed;
    /// <summary>
    /// Gravity value 
    /// </summary>
    public float GravityValue;
    /// <summary>
    /// velocity vector 
    /// </summary>
    Vector3 velocity;
    /// <summary>
    /// ground layer for the raycast
    /// </summary>
    public LayerMask groundlayer;
    /// <summary>
    /// bool value that represents if the player is on ground
    /// </summary>
    public bool isGrounded;
    /// <summary>
    /// jump height value
    /// </summary>
    public float JumpHeight;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastGroundCalculation();

        if (isGrounded == true)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButton("Joystick_Cross"))
            {
                Jump();
            }

            CalculateMovement(GravityValue, GroundSpeed);
        }
        if (isGrounded == false)
        {
            CalculateMovement(GravityValue, AirSpeed);
        }
    }

    /// <summary>
    /// calculate the movement of the player
    /// </summary>
    /// <param name="gravity"></param>
    /// <param name="Movespeed"></param>
    public void CalculateMovement(float gravity, float Movespeed)
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //control movement
        Vector3 move = (transform.right * x) + (transform.forward * z);
        move.Normalize();
        controller.Move(move * Movespeed * Time.deltaTime);


        //control gravity
        velocity.y += (-gravity * 0.5f) * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    /// <summary>
    /// jump method
    /// </summary>
    public void Jump()
    {
        velocity.y = Mathf.Sqrt(JumpHeight * -2f * -GravityValue);       
    }

    /// <summary>
    /// raycast calculation for the ground 
    /// </summary>
    public void RaycastGroundCalculation()
    {
        float raydistance = (this.transform.localScale.y) * ((this.transform.localScale.y / 100) * 10);
        isGrounded = Physics.Raycast(this.transform.position, Vector3.down, (this.transform.localScale.y) + raydistance, groundlayer);
        Vector3 offsetray = new Vector3(0f, (this.transform.localScale.y) + raydistance, 0);

        Debug.DrawRay(transform.position, -offsetray, Color.red);
    }
}
