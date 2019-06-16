using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public System.Action OnSceneEnd;
    public Button btnSkipEnding;

    public void Init()
    {
        Debug.Log("Ending 인잇");

        this.btnSkipEnding.onClick.AddListener(() =>
        {
            Debug.Log("엔딩 스킵");
            this.OnSceneEnd();
        });
    }
}
