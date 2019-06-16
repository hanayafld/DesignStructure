using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGame : MonoBehaviour
{
    public System.Action OnEndingEnd;

    private System.Action OnCampEnd;
    private System.Action OnStageEnd;
    private System.Action OnRetryStage;

    //임시 나중에 지울 것, 스테이지 인포
    private int clearStage = 1;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void Init()
    {
        Debug.Log("InGame 인잇");
        this.clearStage = 1;
        //Camp 씬
        var operCamp = SceneManager.LoadSceneAsync("Camp");
        operCamp.completed += (AsyncOperation) =>
        {
            Debug.Log("Camp 씬로드 완료");
            var camp = GameObject.FindObjectOfType<Camp>();
            camp.Init(this.clearStage);
            camp.OnSceneEnd = () =>
              {
                  //캠프 씬 엔드
                  this.OnCampEnd();
              };
        };

        this.OnCampEnd = () =>
          {
              var operStage = SceneManager.LoadSceneAsync("Stage");
              operStage.completed += (AsyncOperation) =>
                {
                    Debug.Log("Stage 씬로드 완료");
                    var stage = GameObject.FindObjectOfType<Stage>();
                    stage.Init(this.clearStage);

                    stage.OnClearStage = () =>
                    {
                        this.clearStage++;
                        this.OnStageEnd();
                    };

                    stage.OnFaildStage = () =>
                    {
                        this.OnStageEnd();
                    };
                    stage.OnRetryStage = () =>
                     {
                         this.OnRetryStage();
                     };
                };
          };

        this.OnStageEnd = () =>
        {
            if (this.clearStage > 5)
            {
                //엔딩
                Debug.Log("엔딩");
                this.OnEndingEnd();
            }
            else
            {
                operCamp = SceneManager.LoadSceneAsync("Camp");
                operCamp.completed += (AsyncOperation) =>
                {
                    Debug.Log("Camp 씬로드 완료");
                    var camp = GameObject.FindObjectOfType<Camp>();
                    camp.Init(this.clearStage);
                    camp.OnSceneEnd = () =>
                    {
                        //캠프 씬 엔드
                        this.OnCampEnd();
                    };
                };
            }
        };

        this.OnRetryStage = () => 
        {
            this.OnCampEnd();
        };

    }
}