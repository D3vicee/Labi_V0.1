using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_cs : MonoBehaviour
{

    public GameObject ball;
    public GameObject plane;
    public float camera_distance = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 zet = ball.transform.position;
        zet.y = zet.y + camera_distance;
        transform.position = zet;

    }
}
