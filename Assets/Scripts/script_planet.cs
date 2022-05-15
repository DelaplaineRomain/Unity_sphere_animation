using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_planet : MonoBehaviour
{

    private float angle = Mathf.PI * 0.5f;
    private float angle_y = Mathf.PI * 0.5f;
    public float radius = 3;
    [SerializeField] private float rotation_speed = 1;

    private Vector3 newTranslation;

    private bool space_key_pressed = false;
    private bool y_key_pressed = false;


    // Start is called before the first frame update
    void Start()
    {
        var rand = new System.Random();
        angle_y *= (float)rand.NextDouble();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            space_key_pressed = !space_key_pressed;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            y_key_pressed = !y_key_pressed;
        }

        // mouse click dtection
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.name.ToLower() == "center")
                {
                    var rand = new System.Random();

                    var RGBcolor1 = new byte[3];
                    rand.NextBytes(RGBcolor1);

                    var RGBcolor2 = new byte[3];
                    rand.NextBytes(RGBcolor2);

                    hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = new Color32(RGBcolor1[0], RGBcolor1[1], RGBcolor1[2], 255);
                    GetComponent<MeshRenderer>().material.color = new Color32(RGBcolor2[0], RGBcolor2[1], RGBcolor2[2], 255);
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (space_key_pressed)
        {
            float x = radius * Mathf.Cos(angle);
            float y = 0;
            if (y_key_pressed)
            {
                y = radius * Mathf.Cos(angle_y);
            }
            float z = radius * Mathf.Sin(angle);

            newTranslation.Set(x, y, z);

            transform.position = newTranslation + GameObject.FindGameObjectWithTag("center").transform.position;

            angle += Time.deltaTime * rotation_speed;
            angle_y += Time.deltaTime * rotation_speed;
        }
    }
}

