using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    public Transform following;

    public float distance = 15f;
    public float height = 8f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        transform.LookAt(following);
        Vector3 targetPos = following.position + following.forward * -distance;
        targetPos.y += height;
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.05f);
    }
}
