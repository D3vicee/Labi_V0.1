using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_rotation : MonoBehaviour
{
    public int first_contact = 0;
    public GameObject ball;
    public Rigidbody rb_ball;

    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation = Quaternion.Slerp(Quaternion.Euler(0, 0, 0),Quaternion.Euler(150, 45, 150), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.rotation.z < 0.150f)//sol
        {
            if (transform.rotation.z > 0.150f)// belirli açýya sabitleme
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0.150f);
            }
            else//sabitlenen açýya gelmediði müddetçe hareket edebilir.
            {
                transform.Rotate(0, 0, 1 * Time.deltaTime * 20);
            }
        }
        if (Input.GetKey(KeyCode.W) && transform.rotation.x < 0.150f)//arka
        {
            if (transform.rotation.x > 0.150f)
            {
                transform.rotation = Quaternion.Euler(0.150f , transform.rotation.y, transform.rotation.z);
            }
            else
            {
                transform.Rotate(1 * Time.deltaTime * 20, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.D) && transform.rotation.z > -0.150f) //sað
        {
            if (transform.rotation.z < -0.150f)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -0.150f);
            }
            else
            {
                transform.Rotate(0, 0, -1 * Time.deltaTime * 20);
            }
        }
        if (Input.GetKey(KeyCode.S) && transform.rotation.x > -0.150f)//ön
        {
            if (transform.rotation.x < -0.150f)
            {
                transform.rotation = Quaternion.Euler( -0.150f, transform.rotation.y, transform.rotation.z);
            }
            else
            {
                transform.Rotate(-1 * Time.deltaTime * 20, 0, 0);
            }
        }
    }
}
