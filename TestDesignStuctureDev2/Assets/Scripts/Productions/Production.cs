using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Production : MonoBehaviour
{
    public System.Action OnSceneEnd;
    public Button btn_Skip;

    public void Init()
    {
        Debug.Log("Intro Init");

        this.btn_Skip.onClick.AddListener(() =>
        {
            OnSceneEnd();
        });
    }
}
