using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    //씬 종료시 호출
    public System.Action OnStartContinew;
    public System.Action OnStartNewGame;

    public Image imgDim;

    public Button btnContinew;
    public Button btnNewGame;
    public Button btnOption;

    private System.Action OnFadeInComplete;
    private System.Action OnFadeOutComplete;

    public void Init()
    {
        Debug.Log("Title 인잇");
        this.OnFadeInComplete = () =>
          {
              //Dim오브젝트 비활성화
              this.Ready2Game();
          };
        StartCoroutine(this.FadeIn());
    }

    private void Ready2Game()
    {
        Debug.Log("Ready2Game");

        this.btnContinew.onClick.AddListener(() =>
        {
            Debug.Log("이어 하기");
            this.OnFadeOutComplete = () =>
            {
                this.OnStartContinew();
            };
            StartCoroutine(this.FadeOut());
        });

        this.btnNewGame.onClick.AddListener(() =>
        {
            Debug.Log("새로 하기");
            this.OnFadeOutComplete = () =>
            {
                this.OnStartNewGame();
            };
            StartCoroutine(this.FadeOut());
        });

        this.btnOption.onClick.AddListener(() =>
        {
            Debug.Log("옵션 팝업");

        });
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
