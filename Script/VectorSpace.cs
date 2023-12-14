using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class VectorSpace : MonoBehaviour
{
    [SerializeField] Transform target;

    // ���� ���迡�� �� ���� ��ǥ�谡 �����Ѵ�
    //  �� ����(����) ��ǥ : ������ ��ġ���� ������.
    //  �� ����(���) ��ǥ : Ư�� ��ġ�� �������� ������� ��ǥ.

    // transform.position : ���� ��ǥ
    // transform.localposition : ��� ��ǥ

    void Start()
    {
        // transform.rotation : ������ǥ �� ȸ�� ��
        // transform.localRotation : ������ǥ �� ȸ�� ��
        // transform.rotation = Quaternion.Euler(0, 0, 30);
        // transform.localRotation = Quaternion.Euler(0, 0, 30);

        // ���� ��ǥ��(���� ��������) ��ŭ ȸ���ϰڴ°�?
        // �⺻ ���� Space.Self��
        transform.Rotate(Vector3.forward * 30f);
    }

    void position()
    {
        //transform.position = new Vector3(3, 3);       // ���� �� 3,3���� �̵��ض�
        //transform.localPosition = new Vector3(3, 3);  // ��� �������κ��� 3,3��ŭ �̵��ض�

        // ���� ����
        // Vector3.right : ���� ��ǥ�� ������ ���ϴ� ���� ���� (1,0)
        // transform.right : ���� ��ǥ�� ������ ���ϴ� ���� ���� (vx, vy)
        // transform.position += Vector3.right * 3;
        // transform.position += transform.right * 3;

        // ���� ��ǥ�� ���� �̵�����ŭ ��������
        // �⺻ ���� Space.Self(����)������ World�� ������ ��ǥ�踦 ������ �� �ִ�.
        // transform.Translate(Vector3.right * 3, Space.World);

        // RelativeTo:Transform
        // => ��� ������Ʈ�� ���� ��ǥ�� �������� ��������
        // transform.Translate(Vector3.right * 3, target);

        //Debug.Log(transform.root);      // ���� ������ �ֻ��� ��ü
        //Debug.Log(transform.parent);    // �� �ٷ� ��(����) ��ü
    }

    void Update()
    {
        float speed = 10f;
        // Ư�� ��ġ�� ����(pivot)���� ��� Ư�� ������ ȸ���Ѵ�.
        // transform.RotateAround(target.position, Vector3.forward, 1f);

        /*
        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * 10f * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, target.position); // ���� ���� �Ÿ�
        float movement = speed * Time.deltaTime;        // �ӵ� ��� �̵���
        if (distance < movement)
        {
            transform.position += dir * distance;
        }
        else
            transform.position += dir * movement;
        */

        // Vector3.Distance(Vector3, Vector3):float
        // = A�� B������ �Ÿ� ���� �����Ѵ�.
    
        // Vector3.MoveTowards(Vector3, Vector3, float):Vector3
        // = A�� B��ġ�� c��ŭ ������������ ��ġ���� ��ȯ�϶�

        // MoveTowards : ������ �ӵ��� ������ ��ӿ
        // Lerp : �Ÿ��� ���� �ε巯�� ������
        // transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // transform.position = Vector3.Lerp(transform.position, target.position, 10 * Time.deltaTime);
    }

}
