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

    void Awake() {

        m_Car = GetComponent<Car>();

    }

   
    void Update(){

        SyncCar();
        
    }

    private void SyncCar() {

        if (m_Car.HasAuthority()) {

            SendData();

        }else {

            SyncOtherCars();

        }

    }

    private void SyncOtherCars() {

        m_Car.LerpPosition(m_LastPosition, smoothFactor);
        m_Car.LerpRotation(m_LastRotation, smoothFactor);

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

    [ClientRpc]
    private void RpcRecieveTransformData(Vector3 position, Quaternion rotation) {

        // Estoy en el cliente

        if (!m_Car.HasAuthority()) {

            // No necesitamos actualizar o precedir el local player data

            m_LastPosition = position;
            m_LastRotation = rotation;

        }

    }
}
