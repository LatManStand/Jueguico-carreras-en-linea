using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{



    public static SceneLoader instance = null;

    void Awake() {

        if (instance == null) {

            instance = this;

        }
        else if (instance != this) {

            Destroy(gameObject);

        }


        DontDestroyOnLoad(gameObject);
    }


    void Update() {

        if (Input.GetKeyDown(KeyCode.Space)) {

            SceneManager.LoadScene("_Raul");

        }

    }



}
