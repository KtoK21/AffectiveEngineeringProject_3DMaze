using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float RotateSpeed = 200f;
    public float MoveSpeed = 5f;

    bool isRotate = false;
    bool isMove = false;

    Vector3 fromPosition;
    Vector3 toPosition;

    Quaternion fromRotation;
    Quaternion toRotation;

    // Use this for initialization
    void Start()
    {
        fromPosition = transform.position;
        toPosition = Vector3.zero;
        toRotation = Quaternion.identity;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isMove)
                toPosition += transform.forward.normalized;
            else
            {
                fromPosition = transform.position;
                toPosition = transform.position + transform.forward.normalized;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {/*
            if (isMove)
                toPosition += transform.forward.normalized;
            else
            {
                fromPosition = transform.position;
                toPosition = transform.position - transform.forward.normalized;
            }
            */
            transform.LookAt(transform.position - transform.forward.normalized);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (isRotate)
                toRotation *= Quaternion.Euler(0, 270, 0);
            else
            {
                fromRotation = transform.rotation;
                toRotation = transform.rotation * Quaternion.Euler(0, 270, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isRotate)
                toRotation *= Quaternion.Euler(0, 90, 0);
            else
            {
                fromRotation = transform.rotation;
                toRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
            }
        }
        ///////////////////////Get Input

        if (toPosition != Vector3.zero)
        {
            isMove = true;
            transform.position = Vector3.MoveTowards(transform.position, toPosition, MoveSpeed * Time.deltaTime);
        }

        else if (toRotation != Quaternion.identity)
        {
            isRotate = true;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotateSpeed * Time.deltaTime);
        }

        if (transform.position == toPosition)
        {
            fromPosition = transform.position;
            toPosition = Vector3.zero;
            isMove = false;
        }
        if (transform.rotation == toRotation)
        {
            toRotation = Quaternion.identity;
            isRotate = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Goal")
        {
            GameManagement.isClear = true;
        }
        else
        {
            transform.position = fromPosition;
            toPosition = Vector3.zero;

            isMove = false;
        }
    }
}
