using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float first_time = 60;
    public Text time_txt;
    public float total_time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Temas_sc>().start == true && FindObjectOfType<Temas_sc>().finish == false)
        {
            first_time -= Time.deltaTime;
            total_time += Time.deltaTime;
            time_txt.text = "" + (int)first_time;
        }

    }
}
