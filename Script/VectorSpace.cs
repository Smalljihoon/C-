using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class VectorSpace : MonoBehaviour
{
    [SerializeField] Transform target;

    // 가상 세계에는 두 가지 좌표계가 존재한다
    //  ㄴ 월드(절대) 좌표 : 고정된 위치값을 가진다.
    //  ㄴ 로컬(상대) 좌표 : 특정 위치를 기준으로 상대적인 좌표.

    // transform.position : 절대 좌표
    // transform.localposition : 상대 좌표

    void Start()
    {
        // transform.rotation : 월드좌표 상 회전 축
        // transform.localRotation : 로컬좌표 상 회전 축
        // transform.rotation = Quaternion.Euler(0, 0, 30);
        // transform.localRotation = Quaternion.Euler(0, 0, 30);

        // 로컬 좌표상(나를 기준으로) 얼만큼 회전하겠는가?
        // 기본 값은 Space.Self다
        transform.Rotate(Vector3.forward * 30f);
    }

    void position()
    {
        //transform.position = new Vector3(3, 3);       // 월드 상 3,3으로 이동해라
        //transform.localPosition = new Vector3(3, 3);  // 대상 기준으로부터 3,3만큼 이동해라

        // 우측 벡터
        // Vector3.right : 절대 좌표상 우측을 향하는 단위 벡터 (1,0)
        // transform.right : 로컬 좌표상 우측을 향하는 단위 벡터 (vx, vy)
        // transform.position += Vector3.right * 3;
        // transform.position += transform.right * 3;

        // 로컬 좌표계 기준 이동량만큼 움직여라
        // 기본 값은 Space.Self(로컬)이지만 World를 대입해 좌표계를 변경할 수 있다.
        // transform.Translate(Vector3.right * 3, Space.World);

        // RelativeTo:Transform
        // => 대상 오브젝트의 로컬 좌표계 기준으로 움직여라
        // transform.Translate(Vector3.right * 3, target);

        //Debug.Log(transform.root);      // 계층 구조상 최상위 객체
        //Debug.Log(transform.parent);    // 내 바로 위(상위) 객체
    }

    void Update()
    {
        float speed = 10f;
        // 특정 위치를 기준(pivot)으로 잡고 특정 축으로 회전한다.
        // transform.RotateAround(target.position, Vector3.forward, 1f);

        /*
        Vector3 dir = (target.position - transform.position).normalized;
        transform.position += dir * 10f * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, target.position); // 상대와 나의 거리
        float movement = speed * Time.deltaTime;        // 속도 대비 이동량
        if (distance < movement)
        {
            transform.position += dir * distance;
        }
        else
            transform.position += dir * movement;
        */

        // Vector3.Distance(Vector3, Vector3):float
        // = A와 B사이의 거리 값을 리턴한다.
    
        // Vector3.MoveTowards(Vector3, Vector3, float):Vector3
        // = A가 B위치로 c만큼 움직였을때의 위치값을 반환하라

        // MoveTowards : 동일한 속도를 가지는 등속운동
        // Lerp : 거리에 따른 부드러운 움직임
        // transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // transform.position = Vector3.Lerp(transform.position, target.position, 10 * Time.deltaTime);
    }

}
