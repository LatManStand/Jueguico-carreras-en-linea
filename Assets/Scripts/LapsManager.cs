using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapsManager : MonoBehaviour{

    public int lapsToWin;

    public static LapsManager instance = null;

   
    void Awake() {

        if (instance == null) {

            instance = this;

        }
        else if (instance != this) {

            Destroy(gameObject);

        }


     
    }


}
