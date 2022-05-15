using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_camera_movement : MonoBehaviour
{
    private float rotation_speed = 2;

    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.right * Time.deltaTime * rotation_speed);
    }
}
