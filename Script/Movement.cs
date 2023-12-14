using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameLoop
// = 게임은 기본적으로 반복된다.
// Init -> Input -> Update -> Render -> Input...

// Init         : 초기값을 세팅하는 단계
// Input      : 유저의 입력을 받는 단계
// Update    : 값을 처리하는 단계
// Render    : 값을 화면에 그리는 단계

public class Movement : MonoBehaviour
{

    // private이지만 컴포넌트에는 노출시키겠다. [SerializeField]
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] int MoveSpeed;

    // 유니티 이벤트 함수
    // => 사용자가 아닌 유니티가 부르는 함수

    // 게임이 실행되었 때 최초에 1회 불리는 초기화 함수
    void Start()
    {
        Vector3 v = new Vector3(1, 2);
        Vector3 w = new Vector3(3, 1);
        // A는 v+w로 이동
        // B는 w+v로 이동

        // transform은 나의 공간상의 속성
        // position은 위치 값.
        transform.position = v + w;
        transform.position = Vector3.zero;


        float d = Mathf.Sqrt(Mathf.Pow(x,2)+Mathf.Pow(y,2));
        Vector3 movement = new Vector3(x, y);
        float distance = movement.magnitude;
        Debug.Log($"distance : {distance}");

        // 내가 붙어있는 오브젝트의 Transform 컴포넌트에 접근한다
        // 내부에 있는 position(위치) 값을 1,0으로 대입한다
    }

    // 프레임마다 호출되는 함수
    void Update()
    {
        
        // 키보드 입력
        // Input.GetKeyDown : 키보드를 눌렀을 경우 true리턴
        /*
        if(Input.GetKeyDown(KeyCode.W))
        {
            // 현재 나의 위치에 v(1,0)을 더한다 => 해당 방향으로 이동한다.
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
        // Time.deltaTime : float = 이전 프레임에서 현재 프레임까지 걸린 시간(ms)
        // 프레임 차이에 따른 이동량을 보정하기 위해 곱해준다

        // 우측 벡터(Vector3.right 1,0) * 크기(scalar) => 이동량(movement)
        //transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        /*
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        else if(Input.GetKey(KeyCode.LeftArrow))
            transform.position -= Vector3.right * MoveSpeed * Time.deltaTime;
        
        

        // Horizontal : 수평, 가로
        // Vertical : 수직, 세로
        // Input.GetAxisRaw : Input Moudle에 작성된 값에 따라 -1, 0, 1의 값을 리턴한다.
        // 왼쪽을 누르면 -1, 안누르면 0, 오른쪽을 누르면 1
        Vector3 hor = Input.GetAxisRaw("Horizontal") * Vector3.right;   //수평에 대한 벡터(방향)
        Vector3 ver = Input.GetAxisRaw("Vertical") * Vector3.up;        // 수직에 대한 벡터(방향)
        Vector3.dir = (hor + ver).normalized;                          // 벡터의 크기가 1인 벡터로 반환한다.

        // ver과 hor은 각각  다른 벡터이다
        // 두 벡터를 더해 방향 벡터를 만들고 크기를 1로 만들어 단위 벡터로 변환한다
        // 이제 내가 가고자 하는 "방향"에 속도인 "크기"를 곱해 캐릭터를 이동시킨다.
        transform.position += dir * MoveSpeed * x * Time.deltaTime;
        */
    }
}


// 게임에서 사용하는 수학 
// 1. 공간을 다루는 수학 : 벡터 > 행렬 
// 2. 물체를 다루는 수학 : 점 > 삼각형
// 3. 회전을 다루는 수학 : 삼각함수 > 사원수

/*
  * 공간을 다루는 수학은 가상 공간을 구축하고 분석하는데 사용한다.
  * 가상공간은 벡터로 이루어져있고 행렬을 이용해 원하는대로 변환한다.
  * 
  *  물체를 다루는 수학은 물체의 외형을 설정하고 화면에 표시(Render) 한다.
 */

// 수와 집합
// 자연수 : 물건을 세거나 순서를 지정하기 위해 사용하는 수의 집합 ( N )
// 정수 : 자연수와 음수, 0을 포함하는 수의 집합 ( Z )
// 유리수 : 분모가 0이 아닌 두 정수의 비율 혹은 분수로 나타낼 수 있는 수의 집합 ( Q )
// 무리수 : 두 정수의 비 혹은 분수로 나타낼 수 없는 수의 집합 ( I )
// 실수 : 유리수와 무리수를 포함하는 수의 집합 ( R )
// 복소수 : 실수와 제곱하면 -1이 되는 허수 단위 i를 조합해 a+bi형태로 표현하는 수의 집합 ( C )
// 사원수 : 실수와 제곱하면 -1이 되는 세 허수 단위 i, j, k를 조합해 a + bi + cj + dk 형태로 표현하는 수의 집합( H )

// 연산과 수의 구조
// = 수집합의 고유한 특징은 원소를 이용해 연산을 한다.
//    대표적으로 사칙연산이 있는데 두 원소를 이용해 새로운 원소를 만들기 떄문에 '이항연산'이라고도 한다.
// A 0 B = a + b = a * b

// 이항 연산의 특성, 성질
// 1. 닫혀있다 : 같은 집합에 속한 두 수를 투입한 이항 연산의 결과가 항상 투입한 집하에 속한다.
// 2. 교환법칙 : 임의의 두 수를 연산할 때 순서에 상관없이 결과에 동일하다. ( A+B = B + A, A * B = B * A )
// 3. 결합법칙 : 연산이 두 번 이상 연속될 때, 무엇을 먼저 연산하건 결과가 동일하다. ( (A + B) + C = A + (B + C) )
// 4. 분배법칙 : 서로 다른 2가지 연산에 대해 아래와 같은 규칙이 성립
//                  식1. a * (B+C) = a*b + a*c
//                  식2. (b+C) * a = b*a + b*c
// 5. 항등원 : 임의의 수와 연산 결과를 항상 동일한 수로 만들어주는 수 ( A + 0 = A, A * 1 = A )
// 6. 역원 : 임의의 수와 연산 결과를 항등원으로 만들어주는 수 ( a + (-a) = 0, a * (1 / a ) = 1 )
//         ㄴ> 덧셈에서는 주어진 수의 부호가 반대가 되므로 '반대수'라 불린다.
//         ㄴ> 곱셈에서는 분자가 1이고 주어진 수가 분모가 되므로 '역수'라 불린다.

// +(덧셈)은 위 공리를 모두 만족한다.

// 7. 두 번째 연산에 대해 닫혀있다.
// 8. 두 번째 연산에 대해 결합법칙이 성립한다.
// 9. 첫 번째 연산과 두번째 연ㅐ 분배 법칙이 성립
// 10. 두 번째 연산에 대해 교환법칙이 성립한다.

// 위의 모든 공리적 만족하는 수 집합을 체의 구조를 가졌다.
// 유리수, 실수가 체의 구조를 가지는 특별한 집합이다. 따라서 예외 상황없이 곱셈과 덧셈을 자유롭게 사용할 수 있다.

// 뺼셈과 나눗셈은 어떻게?
// a - b != b - a => a + (-b) = (-b)+a
// a / b != b / a => a ( 1 / b) = (1 / b ) a 


// 결과) 따라서 수 집합의 구조를 분석할 때는 곱셈과 덧셈으로 충분하다.

// 벡터 공간 ( Vector Space ) 
// 두 개 이상의 실수를 곱집합으로 묶어 형성된 집합. 해당 공간의 원소를 벡터 (Vector)


// 벡터의 합 : v1(x1,y1) + v2(x2,y2) => (x1+x2, y1+y2)
// 스칼라 곱 : a * v(x,y) => (a*x, a*y)

// 벡터 합의 결합법칙 : u + (v + w) = ( u + v ) + w
// 벡터 합의 교환법칙 : u + v = v + u
// 벡터 합의 항등원 : v + 0 = v
// 벡터 합의 역원 : v + (-v) = 0
// 스칼라 곱의 호환성 : a(bv) = (ab)v
// 스칼라 곱의 항등원 :
// 벡터 합의 분배 : a(v+w) = a*v + a*w
// 스칼라 덧셈의 분배 : (a+b)v = a*v + b*v