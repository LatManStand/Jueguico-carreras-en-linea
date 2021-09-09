using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {


    public static GameManager Instance;


    void Awake() {

        Instance = this;

    }


    public void StartGame() {

        if (isServer) {

            CmdStartGame();

        }

    }


    private List<PlayerConnection> GetCurrentPlayers() {

        PlayerConnection[] foundPlayers = FindObjectsOfType<PlayerConnection>();

        return new List<PlayerConnection>(foundPlayers);

    }

    private void SpawnPlayerCars(List<PlayerConnection> players) {

        foreach (PlayerConnection player in players) {

            player.SpawnCar();

        }

    }

    private void InitPlay() {

        List<PlayerConnection> currentPlayers = GetCurrentPlayers();
        SpawnPlayerCars(currentPlayers);
        UIManager.Instance.DisableMenu();

    }

    [Command]
    private void CmdStartGame() {

        RpcStartGame();

    }

    [ClientRpc]
    private void RpcStartGame() {

        InitPlay();

    }

    void Start(){
        
    }

    
    void Update(){
        
    }
}
