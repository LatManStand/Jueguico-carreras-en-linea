using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int id;

    private void Start()
    {
        CheckPointManager.instance.StartingCheckpoints(id);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckPointManager.instance.CheckpointPassed(id, other.transform.root.GetComponent<Car>());
            Debug.Log("CheckpointID: "+ id);
        }
    }

}
