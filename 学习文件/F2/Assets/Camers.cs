using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camers : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public float smoothing = 3;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        this.transform.LookAt(target.position);
    }
}
