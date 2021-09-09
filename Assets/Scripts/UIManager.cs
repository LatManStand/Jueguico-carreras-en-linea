using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIManager : NetworkBehaviour{

    public static UIManager Instance;

    public Text playersCountText;
    public Text buttonPlayText;
    public GameObject menuCanvas;


    [SyncVar]
    public int amountOfPlayers = 0;

    void Awake() {

        Instance = this;

    }

    
    void Update(){

        if (isServer) {
            
            if(amountOfPlayers != NetworkManager.singleton.numPlayers) {

                CmdUpdatePlayers(NetworkManager.singleton.numPlayers);

            }

        }else {

            buttonPlayText.text = "Waiting for host";

        }

    }

    void OnEnable() {

        StartCoroutine(UpdateCoroutine());

    }

    public void UpdatePlayersCount() {

        playersCountText.text = amountOfPlayers + " / 2 Players joined";


    }

    public IEnumerator UpdateCoroutine() {

        while (true) {

            yield return new WaitForSeconds(1f);
            UpdatePlayersCount();


        }

    }

    public void EnableMenu() {

        menuCanvas.SetActive(true);

    }

    public void DisableMenu() {

        menuCanvas.SetActive(false);

    }

    [Command]
    private void CmdUpdatePlayers(int numPlayers) {

        amountOfPlayers = numPlayers;

    }

}
