using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour
{
    private System.Action OnLogoSceneEnd;

    private void Awake()
    {
        //이 씬을 제거하지 않음
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        //로고 씬 불러오기
        //로고 씬 끝나면 타이틀 씬 불러오기
    }
}
