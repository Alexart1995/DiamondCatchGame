using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    // Start is called before the first frame update
    // position of the targer
    public Transform target;

    private Vector3 offset;

    void Awake()
    {
        // position of ous camera - position of our player
        offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
