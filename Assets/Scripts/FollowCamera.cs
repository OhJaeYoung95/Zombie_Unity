using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    private Vector3 currentPos;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        transform.position = target.position + currentPos;
    }
}
