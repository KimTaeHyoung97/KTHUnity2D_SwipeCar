using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float carspeed = 0;
    private Vector2 startPos;
    private bool isMove = false;
    private GameManager gm;
 

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 왼쪽버튼을 누르면 속도 설정
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;//벡터 2로 변경시 z가 짤림, 벡터3로 변경시 z가 추가 //(0,0,0) (x,y,0)
                                           // new Vecter2(Input.mousePosition.x,Input.mousePosition.y);

            Debug.Log(Input.mousePosition);

        }
        else if(Input.GetMouseButtonUp(0) && !isMove)        
        {
            isMove = true;
            Vector2 endPos = Input.mousePosition;
            float swipeLength = (endPos.x - startPos.x);
            carspeed = swipeLength / 700f;//원래는 const 상수로 해야함(일괄적인 처리)

            GetComponent<AudioSource>().Play();
        }
        //멈췄다고 가정할 때
        if(Mathf.Abs(carspeed) < 0.002f && isMove)
        {
            //깃발에 닿았을때
            if(transform.position.x > 5.85f && transform.position.x < 8.25f)
            {
                gm.UpdateText("clear!");
            }
            //그렇지 않을때
            else
            {
                //데스모션
                transform.Rotate(0, 3.2f, 0);
                transform.Translate(0, 0.04f, 0);


                gm.UpdateText("GameOver");

            }
        }
        if(isMove && //움직이는 상태이고
            transform.position.x <= -7.7f || transform.position.x >= 7.7f)//밖으로 나간다면
        {
            carspeed = -carspeed;
        }



        //우측으로 이동 transform.Translate(speed, 0, 0); 0.2f;
        transform.Translate(carspeed, 0, 0);//나(현재위치)를 기준으로 오른쪽으로 이동하겠다.
        //transform.position = transform.position + new Vector3(carspeed, 0, 0);
        //transform.position += new Vector3(carspeed, 0, 0);//내 현재 위치에서 더해준다.

        //속도 등비로 감소(0.98배)
        carspeed *= 0.98f;

        // 좌표계
        //-상대좌표 = 기준:오브젝트

        //-월드좌표 = 기준:게임

        //-스크린좌표 = 기준:플레이가 보는 화면,왼쪽아래가 0,0임

        //Canbers
        //  어떤 오브젝트에 어떤 컴포넌트 어떤 기능
    }
}
