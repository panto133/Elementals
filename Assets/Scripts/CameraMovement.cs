using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float verticalSpeed = 15f;
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime * Input.GetAxis("Vertical")) ;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -moveSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            transform.position += new Vector3(0, -verticalSpeed * Time.deltaTime*Input.GetAxis("Mouse ScrollWheel")*10);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 3, 20), transform.position.z);
        }
        transform.position += transform.right * moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
    }
}
