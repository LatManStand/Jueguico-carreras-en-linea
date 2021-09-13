using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnection : NetworkBehaviour{

    public GameObject carPrefab;

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
        GameObject car = Instantiate(carPrefab, transform.position, transform.rotation);
        car.GetComponent<Car>().SetOwner(this);

        // El objeto existe solo en el server. Lo creamos en los clientes tambien
        NetworkServer.SpawnWithClientAuthority(car, connectionToClient);

    }

}
