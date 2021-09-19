using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Car : NetworkBehaviour
{
    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor; // is this wheel attached to motor?
        public bool steering; // does this wheel apply steer angle?
    }
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public float brakeTorque;
    public float decelerationForce;

    public float currentTorque;
    public float currentBrake;

    public PlayerConnection Owner;

    public SelectedCarManager selectedCar;

    public MeshFilter body;



    void Start()
    {

        selectedCar = FindObjectOfType<SelectedCarManager>();
        body.mesh = selectedCar.currentMesh;


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
            float motor = maxMotorTorque * Input.GetAxis("Vertical");
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

            foreach (AxleInfo axleInfo in axleInfos)
            {
                if (axleInfo.steering)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;
                }
                if (axleInfo.motor)
                {
                    if (motor != 0f)
                    {
                        axleInfo.leftWheel.brakeTorque = 0f;
                        axleInfo.rightWheel.brakeTorque = 0f;
                        axleInfo.leftWheel.motorTorque = motor;
                        axleInfo.rightWheel.motorTorque = motor;
                    }
                    else
                    {
                        axleInfo.leftWheel.brakeTorque = decelerationForce;
                        axleInfo.rightWheel.brakeTorque = decelerationForce;
                        axleInfo.leftWheel.motorTorque = 0.1f;
                        axleInfo.rightWheel.motorTorque = 0.1f;
                    }
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    axleInfo.leftWheel.brakeTorque = brakeTorque;
                    axleInfo.rightWheel.brakeTorque = brakeTorque;
                    axleInfo.leftWheel.motorTorque = 0.1f;
                    axleInfo.rightWheel.motorTorque = 0.1f;
                }
                else if (Input.GetKeyUp(KeyCode.Space))
                {
                    axleInfo.leftWheel.brakeTorque = 0f;
                    axleInfo.rightWheel.brakeTorque = 0f;
                }
                axleInfo.leftWheel.GetWorldPose(out Vector3 position, out Quaternion rotation);
                axleInfo.leftWheel.transform.GetChild(0).position = position;
                axleInfo.leftWheel.transform.GetChild(0).rotation = rotation;

                axleInfo.rightWheel.GetWorldPose(out position, out rotation);
                axleInfo.rightWheel.transform.GetChild(0).position = position;
                axleInfo.rightWheel.transform.GetChild(0).rotation = rotation;
            }
        }

    }


    private void GetInputs()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
            foreach (AxleInfo axleInfo in axleInfos)
            {
                axleInfo.leftWheel.brakeTorque = 0.1f;
                axleInfo.rightWheel.brakeTorque = 0.1f;
                axleInfo.leftWheel.motorTorque = 0.1f;
                axleInfo.rightWheel.motorTorque = 0.1f;
            }
        }


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

    internal void SetColor(Mesh color)
    {

        body.mesh = color;

    }


    public void SetOwner(PlayerConnection player)
    {
        this.Owner = player;
    }



}
