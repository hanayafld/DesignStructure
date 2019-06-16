using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour
{
    private System.Action OnLogoSceneEnd;
    private System.Action OnStartContinew;
    private System.Action OnStartNewGame;
    private System.Action OnEndingEnd;

    private void Start()
    {
        Debug.Log("앱 실행");
        DontDestroyOnLoad(this);

        var operLogo = SceneManager.LoadSceneAsync("Logo");
        operLogo.completed += (AsyncOperation) =>
        {
            Debug.Log("Logo 씬로드 완료");

            var logo = GameObject.FindObjectOfType<Logo>();
            logo.Init();

            logo.OnSeneEnd = () =>
            {
                //로고 씬 엔드
                this.OnLogoSceneEnd();
            };
        };

        this.OnLogoSceneEnd = () =>
        {
            //타이틀 씬 로드
            var operTile = SceneManager.LoadSceneAsync("Title");
            operTile.completed += (AsyncOperation) =>
            {
                Debug.Log("Title 씬로드 완료");

                var title = GameObject.FindObjectOfType<Title>();
                title.Init();

                title.OnStartContinew = () =>
                  {
                      this.OnStartContinew();
                  };

                title.OnStartNewGame = () =>
                {
                    this.OnStartNewGame();
                };

            };
        };

        this.OnStartContinew = () =>
          {
              //인게임 씬 로드
              var operInGame = SceneManager.LoadSceneAsync("InGame");
              operInGame.completed += (AsyncOperation) =>
              {
                  Debug.Log("InGame 씬로드 완료");
                  var inGame = GameObject.FindObjectOfType<InGame>();

                  //인게임 인잇
                  inGame.Init();

                  inGame.OnEndingEnd = () =>
                  {
                      this.OnEndingEnd();
                  };
              };
          };

        this.OnStartNewGame = () =>
        {
            //인트로 씬 로드
            var operIntro = SceneManager.LoadSceneAsync("Intro");
            operIntro.completed += (AsyncOperation) =>
            {
                Debug.Log("Intro 씬로드 완료");
                var intro = GameObject.FindObjectOfType<Intro>();

                //뉴게임 인잇
                intro.Init();
                intro.OnSceneEnd = () =>
                {
                    this.OnStartContinew();
                };
            };
        };

        this.OnEndingEnd = () =>
          {
              var operEnding = SceneManager.LoadSceneAsync("Ending");
              operEnding.completed += (AsyncOperation) =>
              {
                  Debug.Log("Ending 씬로드 완료");
                  var ending = GameObject.FindObjectOfType<Ending>();

                  ending.Init();
                  ending.OnSceneEnd = () =>
                    {
                        this.OnLogoSceneEnd();
                    };
              };
          };
    }
}
