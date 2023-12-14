using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float radius;
    [SerializeField] int vertexCount;
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        // ���Ϸ� ���� : ����� �����ϴ� ���� ü��
        // ���ʹϾ�(�����) : ��谡 �����ϴ� ���� ü��
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));

        // ���� ���� ���� ������ 36�� �� �� �Ÿ��� 4��� ����� ��ǥ�� ����ΰ�?
        // ���� ��ǥ�� (3,4)�� �����Ѵ�.

        // Degree���� : ����� �����ϴ� ���� ü�� 0~360��
        // Radian���� : ��谡 �����ϴ� ���� ü�� ȣ����
        // Deg2Ran = Degree to radian = ��׸� ������ ���� ������ ��ȯ�����ִ� ��.

        // �� ��ġ�� ����� ��ġ�� �˰� �ִٸ� ������ �Ÿ��� ����� �� �ִ�.
        Vector3 targetPos = new Vector3(4, 12);
        Vector3 myPos = new Vector3(1, 2);

        float x = Mathf.Abs(targetPos.x - myPos.x);     // ���� ����� x�� �� �Ÿ�(=���밪)
        float y = Mathf.Abs(targetPos.y - myPos.y);     // ���� ����� y�� �� �Ÿ�(=���밪)

        // Tan(@) = y / x
        // @ = Atan(y / x)

        // Tan�� �ݴ밡 Atan�̴�
        // Tan(@) = y/x (==) @ = Atan(y/x)
        float angle = (Mathf.Atan2(y,x) *Mathf.Rad2Deg);
        float distance = Mathf.Sqrt(x*x + y*y);
        Debug.Log($"���� {angle}��");
        Debug.Log($"�Ÿ� {distance}m");
        //Debug.Log($"���� : {(Mathf.Atan2(y, x) * Mathf.Rad2Deg)}��");
        //Debug.Log(Mathf.Sqrt(x * x + y * y));

        // �� ��ġ�� ������ ����, �Ÿ��� �˰� ������ ��ǥ�� ����� �� �ִ�.
        x = Mathf.Cos(angle * Mathf.Deg2Rad) * distance;
        y = Mathf.Sin(angle * Mathf.Deg2Rad) * distance;

        Debug.Log($"��� ��ġ : {myPos + new Vector3(x, y)}");

        //float distance = 4f;
        //float angle = 36f;
        //float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        //float y = Mathf.Sin(angle * Mathf.Deg2Rad);

        //Vector2 my = new Vector3(3, 4);
        //Vector2 position = my + (new Vector2(x, y) * distance);
        //Debug.Log(position);

       
    }

    // Update is called once per frame
    void Update()
    {
        // �� �����Ӹ��� z������ 1���� ȸ����Ų��.
        // ȸ���ϰ� ���� �࿡ ���ϴ� ������ ���Ѵ�.
        //transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 1));
        if (Input.GetKey(KeyCode.R))
        {
            transform.rotation *= Quaternion.Euler(Vector3.forward * 30f * Time.deltaTime);
        }

        // ���� �������� �̿��� ���� �׸���.
        lineRenderer.positionCount = vertexCount;

        for (int i = 0; i < vertexCount; i++)
        {
            float radian = i * Mathf.Deg2Rad;
            Vector3 pos = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian));
            lineRenderer.SetPosition(i, pos * radius);
        }

        
        
        // �� ��ġ(A)���� ��� ��ġ(B)�� ���ϴ� ���͸� ���ϰ� �ʹ�.
        // = B - A
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle - 90f);
        transform.position += dir.normalized * Time.deltaTime;      // ������ �������� 1�� �ӵ���ŭ �����δ�.

        transform.position = new Vector3(Mathf.Sin(Time.time), Mathf.Cos(Time.time % 90));
    }
}

/*
 * �ﰢ�Լ�
 *  = ���� �ﰢ�������� �� ���� ���� ����
 *  
 *  �غ� = a ���� = b ���� = c ���� = @
 *  
 *  sin(@) = (���� ���� ����) b/c
 *  cos(@) = (���� ���� �غ�) a/c
 *  tan(@) = (�غ� ���� ����) b/a
 *  
 *  ��Ÿ����� ���� = a�� + b�� = c��
 *  1. c�� 1�̶�� 
 *      ��a=Cos(@), b=Sin(@)
 *  2. �������� r�϶�
 *      �� r��(Cos@ + Sin@) = r��
 *      �� Cos��@ + Sin��@ = 1
 */



/*
 * �غ��� a, ���̸� b, ������ c��� �����Ѵ�.
 * ������ �غ��� ���հ��� A��� ��������.
 * 
 * �� A�� ���ٸ� SIN(����/����), COS(�غ�/����), TAN(����/�غ�)
 *
 */