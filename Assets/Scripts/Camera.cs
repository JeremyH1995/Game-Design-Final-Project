using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if(transform.position.x < 33.11)
                transform.position += new Vector3(speed * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(transform.position.x > -33.4)
            transform.position += new Vector3(-speed * Time.deltaTime,0,0);
        }
    }
}
