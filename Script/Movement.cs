using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameLoop
// = ������ �⺻������ �ݺ��ȴ�.
// Init -> Input -> Update -> Render -> Input...

// Init         : �ʱⰪ�� �����ϴ� �ܰ�
// Input      : ������ �Է��� �޴� �ܰ�
// Update    : ���� ó���ϴ� �ܰ�
// Render    : ���� ȭ�鿡 �׸��� �ܰ�

public class Movement : MonoBehaviour
{

    // private������ ������Ʈ���� �����Ű�ڴ�. [SerializeField]
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] int MoveSpeed;

    // ����Ƽ �̺�Ʈ �Լ�
    // => ����ڰ� �ƴ� ����Ƽ�� �θ��� �Լ�

    // ������ ����Ǿ� �� ���ʿ� 1ȸ �Ҹ��� �ʱ�ȭ �Լ�
    void Start()
    {
        Vector3 v = new Vector3(1, 2);
        Vector3 w = new Vector3(3, 1);
        // A�� v+w�� �̵�
        // B�� w+v�� �̵�

        // transform�� ���� �������� �Ӽ�
        // position�� ��ġ ��.
        transform.position = v + w;
        transform.position = Vector3.zero;


        float d = Mathf.Sqrt(Mathf.Pow(x,2)+Mathf.Pow(y,2));
        Vector3 movement = new Vector3(x, y);
        float distance = movement.magnitude;
        Debug.Log($"distance : {distance}");

        // ���� �پ��ִ� ������Ʈ�� Transform ������Ʈ�� �����Ѵ�
        // ���ο� �ִ� position(��ġ) ���� 1,0���� �����Ѵ�
    }

    // �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        
        // Ű���� �Է�
        // Input.GetKeyDown : Ű���带 ������ ��� true����
        /*
        if(Input.GetKeyDown(KeyCode.W))
        {
            // ���� ���� ��ġ�� v(1,0)�� ���Ѵ� => �ش� �������� �̵��Ѵ�.
            transform.position += new Vector3(1, 0);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(x, y) * -1f;
        }
        */
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.up * MoveSpeed;
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            transform.position += Vector3.up * -MoveSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.right * -MoveSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * MoveSpeed;
        }

        /*
        // Time.deltaTime : float = ���� �����ӿ��� ���� �����ӱ��� �ɸ� �ð�(ms)
        // ������ ���̿� ���� �̵����� �����ϱ� ���� �����ش�

        // ���� ����(Vector3.right 1,0) * ũ��(scalar) => �̵���(movement)
        //transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        /*
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        else if(Input.GetKey(KeyCode.LeftArrow))
            transform.position -= Vector3.right * MoveSpeed * Time.deltaTime;
        
        

        // Horizontal : ����, ����
        // Vertical : ����, ����
        // Input.GetAxisRaw : Input Moudle�� �ۼ��� ���� ���� -1, 0, 1�� ���� �����Ѵ�.
        // ������ ������ -1, �ȴ����� 0, �������� ������ 1
        Vector3 hor = Input.GetAxisRaw("Horizontal") * Vector3.right;   //���� ���� ����(����)
        Vector3 ver = Input.GetAxisRaw("Vertical") * Vector3.up;        // ������ ���� ����(����)
        Vector3.dir = (hor + ver).normalized;                          // ������ ũ�Ⱑ 1�� ���ͷ� ��ȯ�Ѵ�.

        // ver�� hor�� ����  �ٸ� �����̴�
        // �� ���͸� ���� ���� ���͸� ����� ũ�⸦ 1�� ����� ���� ���ͷ� ��ȯ�Ѵ�
        // ���� ���� ������ �ϴ� "����"�� �ӵ��� "ũ��"�� ���� ĳ���͸� �̵���Ų��.
        transform.position += dir * MoveSpeed * x * Time.deltaTime;
        */
    }
}


// ���ӿ��� ����ϴ� ���� 
// 1. ������ �ٷ�� ���� : ���� > ��� 
// 2. ��ü�� �ٷ�� ���� : �� > �ﰢ��
// 3. ȸ���� �ٷ�� ���� : �ﰢ�Լ� > �����

/*
  * ������ �ٷ�� ������ ���� ������ �����ϰ� �м��ϴµ� ����Ѵ�.
  * ��������� ���ͷ� �̷�����ְ� ����� �̿��� ���ϴ´�� ��ȯ�Ѵ�.
  * 
  *  ��ü�� �ٷ�� ������ ��ü�� ������ �����ϰ� ȭ�鿡 ǥ��(Render) �Ѵ�.
 */

// ���� ����
// �ڿ��� : ������ ���ų� ������ �����ϱ� ���� ����ϴ� ���� ���� ( N )
// ���� : �ڿ����� ����, 0�� �����ϴ� ���� ���� ( Z )
// ������ : �и� 0�� �ƴ� �� ������ ���� Ȥ�� �м��� ��Ÿ�� �� �ִ� ���� ���� ( Q )
// ������ : �� ������ �� Ȥ�� �м��� ��Ÿ�� �� ���� ���� ���� ( I )
// �Ǽ� : �������� �������� �����ϴ� ���� ���� ( R )
// ���Ҽ� : �Ǽ��� �����ϸ� -1�� �Ǵ� ��� ���� i�� ������ a+bi���·� ǥ���ϴ� ���� ���� ( C )
// ����� : �Ǽ��� �����ϸ� -1�� �Ǵ� �� ��� ���� i, j, k�� ������ a + bi + cj + dk ���·� ǥ���ϴ� ���� ����( H )

// ����� ���� ����
// = �������� ������ Ư¡�� ���Ҹ� �̿��� ������ �Ѵ�.
//    ��ǥ������ ��Ģ������ �ִµ� �� ���Ҹ� �̿��� ���ο� ���Ҹ� ����� ������ '���׿���'�̶�� �Ѵ�.
// A 0 B = a + b = a * b

// ���� ������ Ư��, ����
// 1. �����ִ� : ���� ���տ� ���� �� ���� ������ ���� ������ ����� �׻� ������ ���Ͽ� ���Ѵ�.
// 2. ��ȯ��Ģ : ������ �� ���� ������ �� ������ ������� ����� �����ϴ�. ( A+B = B + A, A * B = B * A )
// 3. ���չ�Ģ : ������ �� �� �̻� ���ӵ� ��, ������ ���� �����ϰ� ����� �����ϴ�. ( (A + B) + C = A + (B + C) )
// 4. �й��Ģ : ���� �ٸ� 2���� ���꿡 ���� �Ʒ��� ���� ��Ģ�� ����
//                  ��1. a * (B+C) = a*b + a*c
//                  ��2. (b+C) * a = b*a + b*c
// 5. �׵�� : ������ ���� ���� ����� �׻� ������ ���� ������ִ� �� ( A + 0 = A, A * 1 = A )
// 6. ���� : ������ ���� ���� ����� �׵������ ������ִ� �� ( a + (-a) = 0, a * (1 / a ) = 1 )
//         ��> ���������� �־��� ���� ��ȣ�� �ݴ밡 �ǹǷ� '�ݴ��'�� �Ҹ���.
//         ��> ���������� ���ڰ� 1�̰� �־��� ���� �и� �ǹǷ� '����'�� �Ҹ���.

// +(����)�� �� ������ ��� �����Ѵ�.

// 7. �� ��° ���꿡 ���� �����ִ�.
// 8. �� ��° ���꿡 ���� ���չ�Ģ�� �����Ѵ�.
// 9. ù ��° ����� �ι�° ���� �й� ��Ģ�� ����
// 10. �� ��° ���꿡 ���� ��ȯ��Ģ�� �����Ѵ�.

// ���� ��� ������ �����ϴ� �� ������ ü�� ������ ������.
// ������, �Ǽ��� ü�� ������ ������ Ư���� �����̴�. ���� ���� ��Ȳ���� ������ ������ �����Ӱ� ����� �� �ִ�.

// �E���� �������� ���?
// a - b != b - a => a + (-b) = (-b)+a
// a / b != b / a => a ( 1 / b) = (1 / b ) a 


// ���) ���� �� ������ ������ �м��� ���� ������ �������� ����ϴ�.

// ���� ���� ( Vector Space ) 
// �� �� �̻��� �Ǽ��� ���������� ���� ������ ����. �ش� ������ ���Ҹ� ���� (Vector)


// ������ �� : v1(x1,y1) + v2(x2,y2) => (x1+x2, y1+y2)
// ��Į�� �� : a * v(x,y) => (a*x, a*y)

// ���� ���� ���չ�Ģ : u + (v + w) = ( u + v ) + w
// ���� ���� ��ȯ��Ģ : u + v = v + u
// ���� ���� �׵�� : v + 0 = v
// ���� ���� ���� : v + (-v) = 0
// ��Į�� ���� ȣȯ�� : a(bv) = (ab)v
// ��Į�� ���� �׵�� :
// ���� ���� �й� : a(v+w) = a*v + a*w
// ��Į�� ������ �й� : (a+b)v = a*v + b*v