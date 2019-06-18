using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGame : MonoBehaviour
{
    public System.Action OnInGameSceneEnd;

    //인포 매니져에서 받아올 스테이지 레벨
    private int stageLevel;

    #region 씬 전환
    private System.Action OnStartCamp;
    private System.Action OnStartStage;
    private System.Action OnStartProduction;

    #endregion

    public void Init(int stageLevel)
    {
        Debug.Log("InGame Init");
        //test
        this.stageLevel = stageLevel;

        //타이틀로 돌아가기전까지 이 오브젝트를 파괴하지 말라.
        DontDestroyOnLoad(this);

        #region 씬 전환
        //새 게임(인트로 시작), 이어하기(캠프 시작)
        if (stageLevel == 0)
        {
            //인트로 실행
            Debug.Log("Intro 실행");
            var operIntro = SceneManager.LoadSceneAsync("Intro");
            operIntro.completed += (AsyncOperation) =>
            {
                Debug.Log("Intro 씬 로드");
                var intro = GameObject.FindObjectOfType<Intro>();
                intro.OnProductionSkip = () =>
                {
                    //인트로 엔드
                    this.OnStartStage();
                };
                intro.Init();

            };
        }
        else
        {
            //Camp 로드
            Debug.LogFormat("Camp : {0} 실행", stageLevel);
        }

        //인트로가 끝나면 캠프 튜토리얼 Stage00
        //stage 끝나면 production production 끝나면 stageLevel++, Camp 로드
        //스테이지 시작

        //현재의 캠프가 끝나면 stage 로드

        //stage 클리어시 연출(stageLevel) 로드(if(stageLevel==5)//Ending

        //연출 끝나면 stageLevel++, Camp로드

        this.OnStartCamp = () =>
        {
            if(this.stageLevel>5)
            {
                //엔딩
                var operEnding = SceneManager.LoadSceneAsync("Ending");
                operEnding.completed += (AsyncOperation) =>
                {
                    Debug.Log("Ending 씬 로드");
                    var ending = GameObject.FindObjectOfType<Ending>();
                    ending.OnProductionSkip = () =>
                      {
                          //엔딩 끝나면
                          this.OnInGameSceneEnd();
                          //인포에 stageLevel 0으로 초기화 하기


                          Destroy(this);
                      };
                    ending.Init();
                };
            }
            else
            {
                //캠프 시작
                var operCamp = SceneManager.LoadSceneAsync("Camp");
                operCamp.completed += (AsyncOperation) =>
                {
                    Debug.Log("Camp 씬 로드");
                    var camp = GameObject.FindObjectOfType<Camp>();
                    camp.OnCampEnd = () =>
                    {
                        this.OnStartStage();
                    };
                    //끝나면 스테이지 시작
                    camp.Init(this.stageLevel);
                };
            }
        };

        this.OnStartStage = () =>
        {
            //스테이지 시작
            var operStage = SceneManager.LoadSceneAsync("Stage");
            operStage.completed += (AsyncOperation) =>
            {
                Debug.Log("Stage 씬 로드");
                var stage = GameObject.FindObjectOfType<Stage>();

                stage.OnStageClear = () =>
                  {
                      //스테이지 클리어
                      this.OnStartProduction();
                  };

                stage.OnStageRetry = () =>
                {
                    //스테이지 재도전
                    this.OnStartStage();
                };

                stage.OnStageReturn = () =>
                {
                    //마을로 귀환
                    this.OnStartCamp();
                };
                stage.Init(this.stageLevel);
            };
            //끝나면 연출 시작
        };

        this.OnStartProduction = () =>
        {
            //프로덕션 시작
            switch (this.stageLevel)
            {
                case 0:
                    Pro_StageSceneLoad<Pro_Stage00>("Pro_Stage00");
                    break;
                case 1:
                    Pro_StageSceneLoad<Pro_Stage01>("Pro_Stage01");
                    break;
                case 2:
                    Pro_StageSceneLoad<Pro_Stage02>("Pro_Stage02");
                    break;
                case 3:
                    Pro_StageSceneLoad<Pro_Stage03>("Pro_Stage03");
                    break;
                case 4:
                    Pro_StageSceneLoad<Pro_Stage04>("Pro_Stage04");
                    break;
                case 5:
                    Pro_StageSceneLoad<Pro_Stage05>("Pro_Stage05");
                    break;
            }
            //끝나면 캠프 시작
        };

        //Ending 끝나면 타이틀로 돌아가면서 InGame 오브젝트 파괴
        #endregion
    }

    //프로덕션용 씬 로드 메서드
    private void Pro_StageSceneLoad<T>(string SceneName) where T : Production
    {
        var operPro_Stage = SceneManager.LoadSceneAsync(SceneName);
        operPro_Stage.completed += (AsyncOperation) =>
        {
            Debug.Log("Pro_Stage 씬 로드");
            var pro_Stage = GameObject.FindObjectOfType<T>();
            pro_Stage.OnProductionSkip = () =>
              {
                  this.stageLevel++;
                  this.OnStartCamp();
              };
            pro_Stage.Init();
        };
    }
}
