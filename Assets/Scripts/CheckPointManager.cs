using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
  
    public struct CarCheckpoint
    {
        public Car car;
        public int checkpointID;
        public int laps;
        public int totalCheckpoints;

        public CarCheckpoint(Car _car, int _checkpointID)
        {
            car = _car;
            checkpointID = _checkpointID;
            laps = 0;
            totalCheckpoints = 0;
        }

        public void ChangeCheckpoint(int id, bool newLap)
        {
            checkpointID = id;
            totalCheckpoints++;
            if (newLap)
            {
                laps++;
                Debug.Log("Laps: " + laps);
                if (laps == LapsManager.instance.lapsToWin) {

                    Debug.Log("Carrera Terminada");

                }

            }
        }
    }

    public static CheckPointManager instance;

    public List<int> checkpointsID;
    public List<CarCheckpoint> cars;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        cars = new List<CarCheckpoint>();

    }

    void Start() {

        

    }

    public void StartingCheckpoints(int checkpointID)
    {
        if (checkpointsID == null)
        {
            checkpointsID = new List<int>();
        }
        checkpointsID.Add(checkpointID);
        checkpointsID.Sort();
    }

    public void StartCars(Car car)
    {
        if (cars == null)
        {
            cars = new List<CarCheckpoint>();
        }
        cars.Add(new CarCheckpoint(car, 0));
        //cars.Sort((s1, s2) => s1.car.playerControllerId.CompareTo(s2.car.playerControllerId));
    }

    public void CheckpointPassed(int _checkpointID, Car _car)
    {
        int aux = -1;
        for (int i = 0; i < cars.Count; i++)
        {
            if (_car = cars[i].car)
            {
                aux = i;
                i = cars.Count;
            }
        }

        Debug.Log(aux);

        if (aux != -1)
        {

            Debug.Log("primer IF entra");

            if (_checkpointID == checkpointsID[checkpointsID.IndexOf(cars[aux].checkpointID) + 1])
                // Si ha llegado al siguiente checkpoint
            {
                cars[aux].ChangeCheckpoint(_checkpointID, false);
                cars.Sort((s1, s2) => s1.totalCheckpoints.CompareTo(s2.totalCheckpoints));
                Debug.Log("siguiente Checkpoint");

            }
            else if (_checkpointID == checkpointsID.IndexOf(cars[aux].checkpointID) + 1)
            {
                //Si ha terminado la vuelta
                cars[aux].ChangeCheckpoint(_checkpointID, true);
                cars.Sort((s1, s2) => s1.totalCheckpoints.CompareTo(s2.totalCheckpoints));
                Debug.Log("ha terminado la vuelta");
            }
        }
    }

    public Car FirstPlace()
    {
        return cars[0].car;
    }
    public Car SecondPlace()
    {
        return cars[1].car;
    }
    public Car ThirdPlace()
    {
        if (cars.Count <= 3)
        {
            return cars[2].car;
        }
        return null;
    }
    public Car FourthPlace()
    {
        if (cars.Count <= 4)
        {
            return cars[3].car;
        }
        return null;
    }
}
