using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCarManager : MonoBehaviour{



    public static SelectedCarManager instance = null;

    public Mesh currentMesh;

    void Awake(){
        
        if(instance == null) {

            instance = this;
        
        }else if(instance != this) {

            Destroy(gameObject); 

        } 
           
 
        DontDestroyOnLoad(gameObject); 
    }



}
