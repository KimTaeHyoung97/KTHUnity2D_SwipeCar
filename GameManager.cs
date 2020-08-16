using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UI 사용 시 필수적으로 들어가야한다.

public class GameManager : MonoBehaviour
{
    private GameObject car, flag;
    private Text distance;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("car"); // Find = statick,public,최적화에 좋지않다.
        flag = GameObject.Find("flag"); // 오브젝트명으로 찾아내고, string
        distance = GameObject.Find("Distance").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float length = flag.transform.position.x - car.transform.position.x;
        Text textUI = distance.GetComponent<Text>();
        textUI.text = "목표 지점까지 " + length.ToString("F2") + 'm';
        //없는 컴퍼넌트를 가져오게 되면 NULL이다.
    }
    public void UpdateText(string text)
    {
        distance.text = text;
    }
}
