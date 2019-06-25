using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public System.Action<HeroInfo> OnStageClear;
    public System.Action OnStageRetry;
    public System.Action OnStageReturn;

    public Text txt_StageLevel;

    public Button btn_StageClear;
    public Button btn_Defeat;

    public GameObject ui_Defeat;
    public Button btn_Retry;
    public Button btn_Return;

    private HeroInfo heroInfo;

    public void Init(HeroInfo heroInfo)
    {
        Debug.Log("Stage Init");
        this.heroInfo = heroInfo;
        this.txt_StageLevel.text = string.Format("Stage : {0}", this.heroInfo.stageLevel);

        

        #region 게임 기능

        //이동, 전투 반복
        //BGM시작, 메트로놈 같이 시작
        //적 조우시 전투


        //스테이지 클리어시 this.OnStageEnd();
        btn_StageClear.onClick.AddListener(() =>
        {
            this.OnStageClear(this.heroInfo);
        });

        //패배시 YouDied팝업 띄우고
        this.btn_Defeat.onClick.AddListener(() =>
        {
            this.ui_Defeat.SetActive(true);
        });
        //btn_Restart시, this.OnStageRestart;
        this.btn_Retry.onClick.AddListener(() =>
        {
            //페이드 아웃하면서 ui_Defeat SetActive(false);
            this.ui_Defeat.SetActive(false);

            this.OnStageRetry();
        });

        //btn_Return시, this.OnStageReturn;
        this.btn_Return.onClick.AddListener(() =>
        {
            //페이드 아웃하면서 ui_Defeat SetActive(false);
            this.ui_Defeat.SetActive(false);

            this.OnStageReturn();
        });
        #endregion

    }
}
