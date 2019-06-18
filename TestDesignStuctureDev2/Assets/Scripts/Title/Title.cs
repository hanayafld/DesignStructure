using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public System.Action OnTitleSceneEnd;

    public Button btn_Continew;
    public Button btn_NewGame;
    public Button btn_Option;

    //인포 매니져에서 받아올 스테이지 레벨
    private int stageLevel;

    public void Init()
    {
        Debug.Log("Title Init");
        //GPGS연동
        //Data 불러오기
        //Info 불러오기
        //test
        this.stageLevel = 1;
        //페이드 인 아웃
        //게임 시작 준비 호출
        this.Ready2theGame();

    }

    private void Ready2theGame()
    {
        #region 씬 전환
        //stageLevel 은 나중에 userInfo의 stageLevel로 대체한다.
        Debug.Log("Ready2theGame");
        //버튼 3개
        //스테이지 레벨이 0 == 이어하기 정보가 없을경우
        if (this.stageLevel == 0)
        {
            //이어하기 버튼 비활성화
            this.btn_Continew.gameObject.SetActive(false);
        }

        this.btn_Continew.onClick.AddListener(() =>
        {
            Debug.Log("이어 하기");
            //인게임 불러오기
            this.InGameInit(this.stageLevel);
        });

        this.btn_NewGame.onClick.AddListener(() =>
        {
            Debug.Log("새 게임");
            //인게임 불러오기
            this.InGameInit(0);
        });
        #endregion

        this.btn_Option.onClick.AddListener(() =>
        {
            Debug.Log("옵션");
            //옵션 팝업
        });
    }

    private void InGameInit(int stageLevel)
    {
        var operInGame = SceneManager.LoadSceneAsync("InGame");
        operInGame.completed += (AsyncOperation) =>
          {
              Debug.Log("InGame 씬 로드");
              var inGame = GameObject.FindObjectOfType<InGame>();
              inGame.OnInGameSceneEnd = () =>
                {
                    //
                    this.OnTitleSceneEnd();
                };
              inGame.Init(stageLevel);
          };
    }
}
