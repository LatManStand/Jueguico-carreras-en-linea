using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Car : NetworkBehaviour{

    public PlayerConnection Owner;

    void Start(){
        
    }

    
    void Update(){

        if (hasAuthority) {

            GetInputs();

        }

    }


    void FixedUpdate() {

        if (hasAuthority) {

        }

    }


    private void GetInputs() {
        


    }

    public bool HasAuthority() {

        return hasAuthority;

    }


    internal void LerpPosition(Vector3 desiredPosition, float smooth) {

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smooth * Time.deltaTime);

    }


    internal void LerpRotation(Quaternion desiredRotation, float smooth) {

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smooth * Time.deltaTime);

    }

    public void SetOwner(PlayerConnection player) {
        this.Owner = player;
    }

}
