using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Temas_sc : MonoBehaviour
{
    float finish_counter = 3;
    float finish_counter_2 = 3;
    public GameObject timer;
    public Button revive_but;
    public Text finish_txt = null;
    public GameObject arrow;
    public Rigidbody rb;
    public List<GameObject> portal_enter_list = new List<GameObject>();
    public List<GameObject> portal_exit_list = new List<GameObject>();
    public List<GameObject> light_sources = new List<GameObject>();
    public List<GameObject> door_list = new List<GameObject>();
    public List<GameObject> door_key_list = new List<GameObject>();
    public bool[] doors_status = { false, false, false};
    static bool[] ligth_status = { false ,false, false};
    Animator animator;
    public Animator door_animator;
    public Animator door_1_animator;
    float portal_anim_time = 0.5f;
    public int revive_counter = 0;
    public int zone = 0;
    public bool start = false;
    public bool finish = false;
    public int level_number = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        arrow.transform.position = transform.position;
        print("portal time "+portal_anim_time);
        if ( animator.GetBool("isPortal") == true)
        {
            portal_anim_time -= Time.deltaTime ;
            if(portal_anim_time <= 0.0f )
            {
                animator.SetBool("isPortal", false);
                portal_anim_time = 0.5f;
            }
        }
        if (revive_counter >= 2 && ligth_status[1] == true)
        {
            door_key_list[0].gameObject.SetActive(true);
        }
        if (doors_status[0] == true)
            door_key_list[0].gameObject.SetActive(false);
        if (doors_status[1] == true)
            door_key_list[1].gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        //baþlangýç ve bitiþ noktalarýnýn içerisi
        if (other.gameObject.name == "start_zone")
        {
            print(" baþlamaya hazir");
            start = false;
        }
        if (other.gameObject.name == "finish_zone")
        {
            if (level_number == 1)
            {
                ligth_status[2] = true;
            }

            if (ligth_status[2] == true)
            {
                finish_counter -= Time.deltaTime * 2;
                if (finish_counter <= 0)
                {
                    finish_txt.text = "Round Completed, Total Time: " + (int)FindObjectOfType<Timer>().total_time + "seconds";
                    finish = true;
                    print("Oyun sonlandý");
                    level_number ++;

                        string level = "stage" + level_number;
                        SceneManager.LoadScene(level);
              
                }
                else
                {
                    finish_txt.text = "" + (int)finish_counter;
                }
            }
            else
            {
                finish_txt.text = "Remember that! Light must be on. I think you should to REVIVE";
            }

        }

        //portal içerisi
        if (other.gameObject.name == "portal_1_enter")
        {
            transform.position = portal_exit_list[0].transform.position;
            animator.SetBool("isPortal", true);
            portal_anim_time = 0.5f;
        }
        if (other.gameObject.name == "portal_2_enter")
        {
            transform.position = portal_exit_list[1].transform.position;
            animator.SetBool("isPortal", true);
            portal_anim_time = 0.5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //start finish tespit
        if (other.gameObject.name == "start_zone")
        {
            //revive
            revive_counter++;
            print("baþladý, " + revive_counter);
            finish_txt.text = "";
            start = true;

        }
        if (other.gameObject.name == "finish_zone")
        {
            finish_txt.text = "";
            finish_counter = 3;
        }

        if (other.gameObject.tag == "door_keys")
        {
            if(other.gameObject.name == "0")
                doors_status[0] = true;
            if (other.gameObject.name == "1")
                doors_status[1] = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // portallarýn açýlmasý
        if (other.gameObject.tag == "portal_keys")
        {
            int key_num = Int32.Parse(other.gameObject.name);
            portal_enter_list[key_num ].gameObject.SetActive(true);
        }
        // ýþýklarýn açýlmasý
        if (other.gameObject.tag == "light_keys")
        {
            int key_num = Int32.Parse(other.gameObject.name);
            light_sources[key_num - 1].gameObject.SetActive(true);
            ligth_status[key_num - 1 ] = true;

            //if (doors_status[0] == false && other.gameobject.name == "2")
            //{
            //    revive_but.gameobject.setactive(true);
            //}

        }

        // kapýlarýn açýlmasý
        if (other.gameObject.tag == "door_keys")
        {
            int key_num = Int32.Parse(other.gameObject.name);
            if (key_num == 0)
            {
                door_animator.SetBool("door_open", true);
                zone = 1;
                FindObjectOfType<Timer>().first_time += 30; 
            }
            if (key_num == 1)
            {
                door_1_animator.SetBool("door_1_open", true);
                zone = 2;
                FindObjectOfType<Timer>().first_time += 30;
            }
        }

        // yaylý tuzaklar
        if (other.gameObject.tag == "yay_z")
        {
            if (transform.position.z - other.gameObject.transform.position.z < 0)
            {
                //print("" + (arrow.transform.position.z - other.gameObject.transform.position.z));
                rb.AddForce(-Vector3.fwd * 500);
            }
            if (transform.position.z - other.gameObject.transform.position.z > 0)
            {
               // print("" + (arrow.transform.position.z - other.gameObject.transform.position.z));
                rb.AddForce(Vector3.fwd * 500);
            }
        }
        if (other.gameObject.tag == "yay_x")
        {
            if (transform.position.x - other.gameObject.transform.position.x < 0)
            {
                //print("" + (arrow.transform.position.x - other.gameObject.transform.position.x));
                rb.AddForce(-Vector3.right * 500);
            }
            if (transform.position.x - other.gameObject.transform.position.x > 0)
            {
                //print("" + (arrow.transform.position.x - other.gameObject.transform.position.x));
                rb.AddForce(Vector3.right * 500);
            }
        }
    }

}
