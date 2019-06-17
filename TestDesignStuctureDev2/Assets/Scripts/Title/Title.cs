using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Button btn_Continew;
    public Button btn_NewGame;
    public Button btn_Option;

    public void Init()
    {
        Debug.Log("Title Init");
        //GPGS연동
        //Data 불러오기
        //Info 불러오기

        //페이드 인 아웃
        //게임 시작 준비 호출


    }

    private void Ready2theGame(int stageLevel)
    {
        //stageLevel 은 나중에 userInfo의 stageLevel로 대체한다.

        //버튼 3개
        //스테이지 레벨이 0 == 이어하기 정보가 없을경우
        if (stageLevel == 0)
        {
            //이어하기 버튼 비활성화
            this.btn_Continew.gameObject.SetActive(false);
        }

        this.btn_Continew.onClick.AddListener(() =>
        {
            Debug.Log("이어 하기");
            //인게임 불러오기(매개변수 stageLevel)
        });

        this.btn_NewGame.onClick.AddListener(() =>
        {
            Debug.Log("새 게임");
            //인게임 불러오기(매개변수 stageLevel)
        });

        this.btn_Option.onClick.AddListener(() =>
        {
            Debug.Log("옵션");
            //옵션 팝업
        });
    }
}
