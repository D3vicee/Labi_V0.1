using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    public AudioClip[] sound_effects;
    public AudioSource sound_source, light_sound_source;
    public GameObject ball;
    Vector3 last_position;
    float last_time;
    public float time_rate = 1f;

    private void FixedUpdate()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="yay_x" || other.gameObject.tag == "yay_z" )
        {
            sound_source.volume = 0.5f;
            sound_source.PlayOneShot(sound_effects[1]);
            sound_source.volume = 1f;

        }
        if (other.gameObject.tag == "light_keys")
        {
            sound_source.volume = 0.5f;
            sound_source.PlayOneShot(sound_effects[0]);
            sound_source.volume = 1f;
        }
    }
}
