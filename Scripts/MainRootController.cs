using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainRootController : MonoBehaviour
{
    public bool canMove;

    public GameObject ship;

    public float rotateSpeed;
    public float maxRotateSpeed;
    public float rotateAcceleration;
    public float stabilizationCoefficient;

    public float leanAngle;
    public float maxLeanAngle;
    public float leanAcceleration;
    public float stabilizationCoefficient2;

    public int movementState; //0 means no movement, 1 means turning left, 2 means turning right

    void Start()
    {
        ship = GameObject.Find("SpaceShip");
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.A) || Input.touchCount > 0 && Input.GetTouch(0).position.x < Screen.width / 2 && Input.GetTouch(0).position.y < Screen.height * 0.6f)
            {
                movementState = 1;
            }

            else if (Input.GetKey(KeyCode.D) || Input.touchCount > 0 && Input.GetTouch(0).position.x > Screen.width / 2 && Input.GetTouch(0).position.y < Screen.height * 0.6f)
            {
                movementState = 2;
            }

            else
            {
                movementState = 0;
            }
        }


    }

    void FixedUpdate()
    {
        Turn(movementState);
    }

    public void Turn(int state)
    {

        if (state == 0)
        {
            rotateSpeed = Mathf.Lerp(rotateSpeed, 0f, stabilizationCoefficient);
            leanAngle = Mathf.Lerp(leanAngle, 0f, stabilizationCoefficient2);
        }

        if (state == 1)
        {
            rotateSpeed = Mathf.Lerp(rotateSpeed, +maxRotateSpeed, rotateAcceleration);
            leanAngle = Mathf.Lerp(leanAngle, maxLeanAngle, stabilizationCoefficient2);
        }

        if (state == 2)
        {
            rotateSpeed = Mathf.Lerp(rotateSpeed, -maxRotateSpeed, rotateAcceleration);
            leanAngle = Mathf.Lerp(leanAngle, -maxLeanAngle, stabilizationCoefficient2);
        }

        transform.Rotate(0f, 0f, rotateSpeed);

        ship.transform.localRotation = Quaternion.Euler(ship.transform.localRotation.x, ship.transform.localRotation.y, ship.transform.localRotation.z + leanAngle);
    }

}
