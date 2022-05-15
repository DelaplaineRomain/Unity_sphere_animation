using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_planet : MonoBehaviour
{
    public Transform center_rotation;

    private float angle;
    [SerializeField] private float radius = 3;
    [SerializeField] private float rotation_speed = 1;

    private Vector3 newTranslation;

    private bool space_key_pressed = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            space_key_pressed = !space_key_pressed;
        }
    }

    private void LateUpdate()
    {
        if (space_key_pressed)
        {
            float x = radius * Mathf.Cos(angle);
            float y = transform.position.y;
            float z = radius * Mathf.Sin(angle);

            newTranslation.Set(x, y, z);

            transform.position = newTranslation + center_rotation.position;

            angle += Time.deltaTime * rotation_speed;
        }
    }
}

