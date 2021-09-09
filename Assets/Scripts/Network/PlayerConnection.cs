using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnection : NetworkBehaviour{

    public Car carPrefab;

    /*
    void Start(){

        if (isLocalPlayer) {

            // Pedimos al server spwanear nuestro coche
            CmdSpawnCar();

        }

    }
    */

    public void SpawnCar() {

        if (isLocalPlayer) {

            // Pedimos al server spwanear nuestro coche
            CmdSpawnCar();

        }

    }

    [Command]
    private void CmdSpawnCar() {

        // Sera ejecutado en el servidor
        Car car = Instantiate(carPrefab, transform.position, transform.rotation);
        car.SetOwner(this);

        // El objeto existe solo en el server. Lo creamos en los clientes tambien
        NetworkServer.SpawnWithClientAuthority(car.gameObject, connectionToClient);

    }

}
