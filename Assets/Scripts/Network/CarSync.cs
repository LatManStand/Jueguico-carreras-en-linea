using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CarSync : NetworkBehaviour{

    public float smoothFactor = 10f;
    public float threshold = 0.1f;

    private Vector3 m_LastPosition;
    private Quaternion m_LastRotation;

    private Car m_Car;

    private bool sync = false;

    void Awake() {

        m_Car = GetComponent<Car>();
        

        if (m_Car.HasAuthority()) {

            
            
      

        }

    }

    void Start() {

        Invoke(nameof(StartSync), 0.1f);
        

    }

    private void StartSync() {

        sync = true;

        /*
        if (m_Car.HasAuthority()) {

            CmdSendColorData(m_Car.body.mesh);

        }else {

            SyncColorCars(m_Car.body.mesh);

        }
        */

    }

    void Update(){

        if (sync) {

            SyncCar();

        }
        
        
    }

    private void SyncCar() {

        if (m_Car.HasAuthority()) {
            
            SendData();

            if (!FindObjectOfType<CameraFollower>().hasCar) {
                FindObjectOfType<CameraFollower>().car = this.transform;
                FindObjectOfType<CameraFollower>().hasCar = true;
            
            }

        }
        else {

            SyncOtherCars();

        }

    }

    private void SyncOtherCars() {

        m_Car.LerpPosition(m_LastPosition, smoothFactor);
        m_Car.LerpRotation(m_LastRotation, smoothFactor);

    }

    private void SyncColorCars(Mesh color) {

        m_Car.SetColor(color);

    }

    private void SendData() {

        CmdSendTransformData(m_Car.transform.position, m_Car.transform.rotation);

    }

    [Command]
    private void CmdSendTransformData(Vector3 position, Quaternion rotation) {

        // Estoy en el servidor

        m_LastPosition = position;
        m_LastRotation = rotation;

        RpcRecieveTransformData(m_LastPosition, m_LastRotation);

    }
    /*
    [Command]
    private void CmdSendColorData(Mesh color) {

        m_Car.body.mesh = color;

        RpcRecieveColorData(m_Car.body.mesh);

    }
    */

    [ClientRpc]
    private void RpcRecieveTransformData(Vector3 position, Quaternion rotation) {

        // Estoy en el cliente

        if (!m_Car.HasAuthority()) {

            // No necesitamos actualizar o precedir el local player data

            m_LastPosition = position;
            m_LastRotation = rotation;

        }

    }

    /*
    [ClientRpc]
    private void RpcRecieveColorData(Mesh color) {

        if (!m_Car.HasAuthority()) {

            m_Car.body.mesh = color;

        }


    }
    */

}
