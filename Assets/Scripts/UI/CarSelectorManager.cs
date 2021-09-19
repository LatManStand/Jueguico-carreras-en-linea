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

    public SelectedCarManager selectedCar;

    void Start() {

        body = currentBody.GetComponent<MeshFilter>();
        selectedCar.currentMesh = redCar;

    }

    void Update() {

        fullCar.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

    }


    public void SetRedCar() {

        body.mesh = redCar;
        selectedCar.currentMesh = redCar;
    }

    public void SetYellowCar() {

        body.mesh = yellowCar;
        selectedCar.currentMesh = yellowCar;

    }


    public void SetDarkBlueCar() {

        body.mesh = darkBlueCar;
        selectedCar.currentMesh = darkBlueCar;

    }

    public void SetBlueCar() {

        body.mesh = blueCar;
        selectedCar.currentMesh = blueCar;

    }

    public void SetOrangeCar() {

        body.mesh = orangeCar;
        selectedCar.currentMesh = orangeCar;

    }


    public void SetGrayCar() {

        body.mesh = grayCar;
        selectedCar.currentMesh = grayCar;

    }

}
