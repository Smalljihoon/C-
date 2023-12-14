using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Cannon : MonoBehaviour
{
    [SerializeField] float speed;           // �߻� �ӵ�
    [SerializeField] float angleSpeed;      // ȸ�� �ӵ�
    bool isShoot;       // �߻縦 �ߴ°�?

    void Start()
    {
        
    }

    void Update()
    {
        // Input.GetKey : ������ �ִ� ���� ���
        // Input.GetKeyDown : ������ ��
        // Input.GetKeyUp : ������ ������� ��
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
