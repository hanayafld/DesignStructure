using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    //씬 종료시 호출
    public System.Action OnSeneEnd;

    public Image imgLogo;
    public Image imgDim;

    private System.Action OnFadeInComplete;
    private System.Action OnFadeOutComplete;


    public void Init()
    {
        Debug.Log("Logo 인잇");

        this.OnFadeInComplete = () =>
        {
            Debug.Log("Logo FadeIn 완료");

            this.OnFadeOutComplete = () =>
            {
                Debug.Log("Logo FadeOut 완료");

                //페이드 아웃완료, 타이틀 씬 로드 준비
                this.OnSeneEnd();
            };
            StartCoroutine(this.FadeOut());
        };
        StartCoroutine(this.FadeIn());
    }

    #region Fade In/Out (Dim 기준)
    public IEnumerator FadeIn()
    {
        var color = this.imgDim.color;
        float alpha = color.a;

        while (true)
        {
            alpha -= 0.016f;
            color.a = alpha;
            this.imgDim.color = color;

            if (alpha <= 0)
            {
                alpha = 0;
                break;
            }
            yield return null;
        }
        this.imgDim.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        this.OnFadeInComplete();
    }

    public IEnumerator FadeOut()
    {
        this.imgDim.gameObject.SetActive(true);
        var color = this.imgDim.color;
        float alpha = color.a;

        while (true)
        {
            alpha += 0.016f;
            color.a = alpha;
            this.imgDim.color = color;

            if (alpha >= 1)
            {
                alpha = 1;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(2);
        this.OnFadeOutComplete();
    }
    #endregion

}

