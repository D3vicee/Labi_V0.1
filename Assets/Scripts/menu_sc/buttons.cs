using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class buttons : MonoBehaviour
{
    public Button[] buttonlar;
    public GameObject level_buttons;
    public GameObject main_menu_scene;
    public GameObject play_menu_scene;

    public Transform left, right, mid;
    public float speed = 10f;
    int play = 0, level = 0;

    public void Update()
    {
        float step = speed * Time.deltaTime;
        if (play == 1)
        {
            main_menu_scene.transform.position = Vector3.MoveTowards(main_menu_scene.transform.position, left.position,step);
            play_menu_scene.transform.position = Vector3.MoveTowards(play_menu_scene.transform.position, mid.position, step);
        }
        if (level == 1) 
        {
            main_menu_scene.transform.position = Vector3.MoveTowards(main_menu_scene.transform.position, mid.position, step);
            play_menu_scene.transform.position = Vector3.MoveTowards(play_menu_scene.transform.position, right.position, step);
        }
        
    }

    public void Play()
    {
        buttonlar[0].gameObject.SetActive(false);
        buttonlar[1].gameObject.SetActive(false);
        level_buttons.SetActive(true);
        play = 1;
        level = 0;
    }
    public void Options()
    {

    }
    public void Ouit()
    {
        buttonlar[0].gameObject.SetActive(false);
        buttonlar[1].gameObject.SetActive(false);
        main_menu_scene.SetActive(false);
    }
    public void Back()
    {
        buttonlar[0].gameObject.SetActive(true);
        buttonlar[1].gameObject.SetActive(true);
        level_buttons.SetActive(false);
        play = 0;
        level = 1;
    }
    public void LevelSelector( int level_number)
    {
        string level = "stage" + level_number;
        SceneManager.LoadScene(level);
    }
}
