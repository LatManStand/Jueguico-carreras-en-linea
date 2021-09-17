using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectorManager : MonoBehaviour{


    private MeshFilter body;

    public float rotationSpeed;

    public GameObject currentBody;
    public GameObject fullCar;

    public Mesh redCar;
    public Mesh yellowCar;
    public Mesh darkBlueCar;
    public Mesh blueCar;
    public Mesh orangeCar;
    public Mesh grayCar;

    void Start() {

        body = currentBody.GetComponent<MeshFilter>();

    }

    void Update() {

        fullCar.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

    }


    public void SetRedCar() {

        body.mesh = redCar;

    }

    public void SetYellowCar() {

        body.mesh = yellowCar;

    }


    public void SetDarkBlueCar() {

        body.mesh = darkBlueCar;

    }

    public void SetBlueCar() {

        body.mesh = blueCar;

    }

    public void SetOrangeCar() {

        body.mesh = orangeCar;

    }


    public void SetGrayCar() {

        body.mesh = grayCar;

    }

}
