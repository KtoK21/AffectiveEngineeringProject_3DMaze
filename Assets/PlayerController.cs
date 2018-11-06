using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float LookSensitivity = 3f;
    private PlayerMotor motor;
    private Vector3 fixedPosition;
	// Use this for initialization
	void Start () {
        motor = GetComponent<PlayerMotor>();

    }
	
	// Update is called once per frame
	void Update () {

        fixedPosition = transform.position;

        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = cam.transform.right * xMove;
        Vector3 moveVertical = cam.transform.forward * zMove;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0, yRot, 0) * LookSensitivity;

        motor.Rotate(rotation);
        
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 CameraRotation = new Vector3(xRot, 0f, 0f) * LookSensitivity;

        motor.RotateCamera(CameraRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Goal")
        {
            GameManagement.isClear = true;
        }
        else
        {
            transform.position = fixedPosition;
        }
    }
}
