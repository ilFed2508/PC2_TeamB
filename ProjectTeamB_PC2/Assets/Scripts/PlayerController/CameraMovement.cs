using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /// <summary>
    /// Camera View Sensitivity
    /// </summary>
    public float ViewSensitivity;
    /// <summary>
    /// Joystick view Sensitivity
    /// </summary>
    public float JoystickSensitivity;
    /// <summary>
    /// Player Reference
    /// </summary>
    public Transform Player;
    /// <summary>
    /// the camera X axis rotation
    /// </summary>
    private float cameraXrotation;
    /// <summary>
    /// vector2 that stores the inputs for mouse
    /// </summary>
    private Vector2 mouseInputs;
    /// <summary>
    /// vector2 that stores the inputs for joystick
    /// </summary>
    private Vector2 JoystickInputs;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //ViewSensitivity = PersistantObject.MouseS;
    }
    // Start is called before the first frame update
    void Start()
    {
        //lock the cursor in the game
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        ViewSensitivity = PlayerPrefs.GetFloat("MouseS");

        //get the mouse inputs
        GetMouseInputs();

        //get the joystick inputs
        GetJoystickInputs();

        //apply camera rotation
        ApplyCameraRotation(mouseInputs.x, mouseInputs.y);

        //apply camera rotation joystick
        ApplyJoystickCameraRotation(JoystickInputs.x, JoystickInputs.y);
    }

    /// <summary>
    /// get the mouse inputs 
    /// </summary>
    public void GetMouseInputs()
    {
        float mouseX = Input.GetAxis("Mouse X") * ViewSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ViewSensitivity * Time.deltaTime;

        mouseInputs.x = mouseX;
        mouseInputs.y = mouseY;
    }

    public void GetJoystickInputs()
    {
        float mouseX = Input.GetAxis("Right_Analog_Horizontal") * JoystickSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Right_Analog_Vertical") * JoystickSensitivity * Time.deltaTime;

        JoystickInputs.x = mouseX;
        JoystickInputs.y = mouseY;
    }

    /// <summary>
    /// Apply Camera rotation based on inputs
    /// </summary>
    /// <param name="mouseX"></param>
    /// <param name="mouseY"></param>
    public void ApplyCameraRotation(float mouseX, float mouseY)
    {
        //player rotation
        Player.Rotate(Vector3.up * mouseX);

        cameraXrotation -= mouseY;
        cameraXrotation = Mathf.Clamp(cameraXrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(cameraXrotation, 0f, 0f);
    }

    /// <summary>
    /// Apply Camera rotation based on joystick inputs
    /// </summary>
    /// <param name="mouseX"></param>
    /// <param name="mouseY"></param>
    public void ApplyJoystickCameraRotation(float mouseX, float mouseY)
    {
        //player rotation
        Player.Rotate(Vector3.up * mouseX);

        cameraXrotation += mouseY;
        cameraXrotation = Mathf.Clamp(cameraXrotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(cameraXrotation, 0f, 0f);
    }
}
