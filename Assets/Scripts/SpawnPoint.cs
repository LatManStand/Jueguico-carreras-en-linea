using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour{

    public PlayerConnection Owner { get; private set; }


    public bool IsEmpty() {

        return Owner == null;

    }

    public void Take(PlayerConnection player) {

        Owner = player;

    }

    public void Release() {

        Owner = null;

    }

    private void OnDrawGizmos() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }


}
