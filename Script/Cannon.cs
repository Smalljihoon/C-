using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cannon : MonoBehaviour
{
    [SerializeField] float speed;           // 발사 속도
    [SerializeField] float angleSpeed;      // 회전 속도
    bool isShoot;       // 발사를 했는가?

    void Start()
    {
        
    }

    void Update()
    {
        // Input.GetKey : 누르고 있는 동안 계속
        // Input.GetKeyDown : 눌렀을 때
        // Input.GetKeyUp : 눌렀다 떼어냈을 때
        if (!isShoot)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(Vector3.forward * angleSpeed * Time.deltaTime);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(Vector3.forward * -angleSpeed * Time.deltaTime);
            }
            else if(Input.GetKey(KeyCode.Space))
            {
                isShoot = true;
            }
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Rotate(0,0, 10);
        //}
        //if(Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.Rotate(0, 0, -10);
        //}
        //if( Input.GetKey(KeyCode.Space))
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, transform.right, 100 * Time.deltaTime);
        //}
    }
}
