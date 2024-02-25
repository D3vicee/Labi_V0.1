using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_buttons : MonoBehaviour
{
    public GameObject revive_but;
    public GameObject ball;
    public GameObject arrow;
    public GameObject start_zone;
    public Text finish_txt = null;
    public float[] zone_times = { 0, 30 ,30 };
    // Update is called once per frame
    private void Start()
    {
        finish_txt.text = " This round will not be easy as the previously. One more thing, lights is must be open ";
    }
    void Update()
    {
        if (FindObjectOfType<Timer>().first_time <= 0 )
        {
            ball.transform.position = start_zone.transform.position;
            FindObjectOfType<Timer>().first_time = 30 + zone_times[FindObjectOfType<Temas_sc>().zone];
        }
        print(FindObjectOfType<Temas_sc>().zone);
    }

    public void Revive() 
    { 
        ball.transform.position = start_zone.transform.position;
        finish_txt.text = "";
        FindObjectOfType<Timer>().first_time = zone_times[FindObjectOfType<Temas_sc>().zone];
        FindObjectOfType<Timer>().first_time = 0;
    }
}
