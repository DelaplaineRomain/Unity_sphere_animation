using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_planet_generation : MonoBehaviour
{
    public GameObject planet_prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var rand = new System.Random();

            float radius = 1.5f + (float)rand.NextDouble() * 15;

            Vector3 delta_pos = new Vector3(0, 0, radius);
            Vector3 pos_initial = GameObject.Find("Center").transform.position + delta_pos;

            GameObject new_planet = Instantiate(planet_prefab, pos_initial, Quaternion.identity);
            new_planet.GetComponent<script_planet>().radius = radius;

        }
    }

}
