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
        // 오일러 각도 : 사람이 이해하는 각도 체계
        // 쿼터니언(사원수) : 기계가 이해하는 각도 체계
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));

        // 만약 상대와 나의 각도가 36도 일 때 거리가 4라면 상대의 좌표는 어디인가?
        // 나의 좌표는 (3,4)로 가정한다.

        // Degree각도 : 사람이 이해하는 각도 체계 0~360도
        // Radian각도 : 기계가 이해하는 각도 체계 호도법
        // Deg2Ran = Degree to radian = 디그리 각도를 라디안 각도로 변환시켜주는 값.

        // 내 위치와 상대의 위치를 알고 있다면 각도와 거리를 계산할 수 있다.
        Vector3 targetPos = new Vector3(4, 12);
        Vector3 myPos = new Vector3(1, 2);

        float x = Mathf.Abs(targetPos.x - myPos.x);     // 나와 상대의 x축 상 거리(=절대값)
        float y = Mathf.Abs(targetPos.y - myPos.y);     // 나와 상대의 y축 상 거리(=절대값)

        // Tan(@) = y / x
        // @ = Atan(y / x)

        // Tan의 반대가 Atan이다
        // Tan(@) = y/x (==) @ = Atan(y/x)
        float angle = (Mathf.Atan2(y,x) *Mathf.Rad2Deg);
        float distance = Mathf.Sqrt(x*x + y*y);
        Debug.Log($"각도 {angle}도");
        Debug.Log($"거리 {distance}m");
        //Debug.Log($"각도 : {(Mathf.Atan2(y, x) * Mathf.Rad2Deg)}도");
        //Debug.Log(Mathf.Sqrt(x * x + y * y));

        // 내 위치와 상대와의 각도, 거리를 알고 있으면 좌표를 계산할 수 있다.
        x = Mathf.Cos(angle * Mathf.Deg2Rad) * distance;
        y = Mathf.Sin(angle * Mathf.Deg2Rad) * distance;

        Debug.Log($"상대 위치 : {myPos + new Vector3(x, y)}");

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
        // 매 프레임마다 z축으로 1도씩 회전시킨다.
        // 회전하고 싶은 축에 원하는 각도를 곱한다.
        //transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 1));
        if (Input.GetKey(KeyCode.R))
        {
            transform.rotation *= Quaternion.Euler(Vector3.forward * 30f * Time.deltaTime);
        }

        // 라인 랜더러를 이용해 선을 그린다.
        lineRenderer.positionCount = vertexCount;

        for (int i = 0; i < vertexCount; i++)
        {
            float radian = i * Mathf.Deg2Rad;
            Vector3 pos = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian));
            lineRenderer.SetPosition(i, pos * radius);
        }

        
        
        // 내 위치(A)에서 상대 위치(B)로 향하는 벡터를 구하고 싶다.
        // = B - A
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle - 90f);
        transform.position += dir.normalized * Time.deltaTime;      // 상대방의 방향으로 1의 속도만큼 움직인다.

        transform.position = new Vector3(Mathf.Sin(Time.time), Mathf.Cos(Time.time % 90));
    }
}

/*
 * 삼각함수
 *  = 직각 삼각형에서의 각 변에 대한 비율
 *  
 *  밑변 = a 높이 = b 빗변 = c 각도 = @
 *  
 *  sin(@) = (빗변 분의 높이) b/c
 *  cos(@) = (빗변 분의 밑변) a/c
 *  tan(@) = (밑변 분의 높이) b/a
 *  
 *  피타고라스의 정리 = a² + b² = c²
 *  1. c가 1이라면 
 *      ㄴa=Cos(@), b=Sin(@)
 *  2. 반지름이 r일때
 *      ㄴ r²(Cos@ + Sin@) = r²
 *      ㄴ Cos²@ + Sin²@ = 1
 */



/*
 * 밑변을 a, 높이를 b, 빗변을 c라고 정의한다.
 * 빗변과 밑변의 사잇각을 A라고 가정하자.
 * 
 * 각 A가 같다면 SIN(높이/빗변), COS(밑변/빗변), TAN(높이/밑변)
 *
 */