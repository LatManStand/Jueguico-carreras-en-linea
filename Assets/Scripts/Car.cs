using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Car : NetworkBehaviour
{

    public PlayerConnection Owner;
    public float maxSpeed;
    public float acceleration;
    public float breaks;
    public float rotationAngle = 30f;
    private float speed;

    public float wheelRotationMult;
    public List<GameObject> wheels;


    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }


    void Update()
    {

        //if (hasAuthority)
        if (true)
        {

            GetInputs();
        }

    }

    void FixedUpdate()
    {

        //if (hasAuthority)
        if (true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (speed < 0f)
                {
                    speed += acceleration * Time.deltaTime;
                }
                speed += acceleration * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                speed -= breaks * Time.deltaTime;
            }

            speed = Mathf.Clamp(speed, -maxSpeed / 2f, maxSpeed);

            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                Debug.Log("Derecha");
                Quaternion deltaRotationRight = Quaternion.Euler(new Vector3(0f, rotationAngle, 0f) * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotationRight);
                wheels[0].transform.localRotation = Quaternion.Euler(wheels[0].transform.rotation.x, rotationAngle, 0f);
                wheels[1].transform.localRotation = Quaternion.Euler(wheels[1].transform.rotation.x, rotationAngle, 0f);
            }
            else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                Debug.Log("Izquierda");
                Quaternion deltaRotationLeft = Quaternion.Euler(new Vector3(0f, -rotationAngle, 0f) * Time.deltaTime);
                rb.MoveRotation(rb.rotation * deltaRotationLeft);
                wheels[0].transform.localRotation = Quaternion.Euler(wheels[0].transform.rotation.x, -rotationAngle, 0f);
                wheels[1].transform.localRotation = Quaternion.Euler(wheels[1].transform.rotation.x, -rotationAngle, 0f);
            }
            else //if ((Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.D)) || (Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.A)))
            {
                //Debug.Log("Recto");
                wheels[0].transform.localRotation = Quaternion.Euler(wheels[0].transform.rotation.x, 0f, 0f);
                wheels[1].transform.localRotation = Quaternion.Euler(wheels[1].transform.rotation.x, 0f, 0f);
            }


            float auxY = rb.velocity.y;
            rb.velocity = transform.forward * speed;
            rb.velocity = new Vector3(rb.velocity.x, auxY, rb.velocity.z);
            //rb.MovePosition(transform.position + transform.forward * speed);

            foreach (GameObject wheel in wheels)
            {
                wheel.transform.localRotation = Quaternion.Euler(rb.velocity.magnitude * wheelRotationMult, wheel.transform.localRotation.y, 0);
            }
        }

    }


    private void GetInputs()
    {



    }

    public bool HasAuthority()
    {

        return hasAuthority;

    }


    internal void LerpPosition(Vector3 desiredPosition, float smooth)
    {

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smooth * Time.deltaTime);

    }


    internal void LerpRotation(Quaternion desiredRotation, float smooth)
    {

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smooth * Time.deltaTime);

    }

    public void SetOwner(PlayerConnection player)
    {
        this.Owner = player;
    }

}
