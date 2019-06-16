using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public System.Action OnClearStage;
    public System.Action OnFaildStage;
    public System.Action OnRetryStage;

    public Button btnClearStage;
    public Button btnFaildStage;

    public GameObject youDied;
    public Button btnReTry;
    public Button btnBack2theCamp;

    public Text txtStage;

    public void Init(int stage)
    {
        Debug.Log("Stage 인잇");
        this.txtStage.text = stage.ToString();

        this.btnClearStage.onClick.AddListener(() =>
        {
            Debug.Log("스테이지 클리어");
            this.OnClearStage();
        });

        #region 사망관련
        this.btnFaildStage.onClick.AddListener(() =>
        {
            Debug.Log("클리어 실패");

            this.youDied.SetActive(true);
        });
        
        this.btnReTry.onClick.AddListener(() =>
        {
            Debug.Log("다시하기");
            this.youDied.SetActive(false);
            this.OnRetryStage();
        });

        this.btnBack2theCamp.onClick.AddListener(() =>
        {
            Debug.Log("마을로 돌아가기");
            this.youDied.SetActive(false);
            this.OnFaildStage();
        });
        #endregion
    }
}
