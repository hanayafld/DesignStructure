using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camp : MonoBehaviour
{
    public System.Action OnSceneEnd;

    public Button btnPopupUI;

    public GameObject tradePopUp;
    public Button btnComplete;
    public Text txtStage;

    public void Init(int stage)
    {
        Debug.Log("Camp 인잇");
        this.txtStage.text = stage.ToString();

        this.btnPopupUI.onClick.AddListener(() =>
        {
            this.tradePopUp.SetActive(true);

        });

        this.btnComplete.onClick.AddListener(() => 
        {
            //팝업 닫기
            //연출(상인 이동)
            //페이드아웃
            //씬 종료
            this.OnSceneEnd();
        });
    }
}
