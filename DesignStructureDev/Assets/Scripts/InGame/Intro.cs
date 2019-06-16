using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public System.Action OnSceneEnd;

    public Button btnIntroSkip;

    public void Init()
    {
        Debug.Log("Intro 인잇");
        //튜토리얼 진행

        //인트로 진행

        //인트로 진행이 끝날경우
        this.btnIntroSkip.onClick.AddListener(() =>
        {
            //인트로 스킵
            this.OnSceneEnd();
        });
    }
}
