using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;

public class TestInfo : MonoBehaviour
{
    #region 세이브 로드
    public Button btn_LoadInfo;
    public Button btn_CreatInfo;
    public Button btn_SaveInfo;
    #endregion

    public Button btn_AddGold;
    public Button btn_AddHp;
    public Button btn_ClearLevel;
    public Button btn_AddArtifact;

    private void Start()
    {
        Debug.Log("시작");
        int i = 0;
        
        //데이터 불러오기
        var data = DataManager.Instance;
        data.LoadAllDatas();

        //인포 불러오기
        var info = InfoManager.Instance;

        #region 세이브 로드
        this.btn_LoadInfo.onClick.AddListener(() =>
        {
            info.LoadInfo(info.heroInfoPath);
            info.heroInfo.artifacts = new List<ArtifactData>();
        });

        //인포 생성하기
        this.btn_CreatInfo.onClick.AddListener(() =>
        {
            info.CreateInfo();
        });

        this.btn_SaveInfo.onClick.AddListener(() =>
        {
            info.SaveInfo();
        });
        #endregion

        //
        this.btn_AddGold.onClick.AddListener(() =>
        {
            info.heroInfo.gold += 5;
            Debug.Log(info.heroInfo.gold);
        });
        this.btn_AddHp.onClick.AddListener(() =>
        {
            info.heroInfo.max_hp += 1;
            Debug.Log(info.heroInfo.max_hp);
        });
        this.btn_ClearLevel.onClick.AddListener(() =>
        {
            info.heroInfo.stageLevel += 1;
            Debug.Log(info.heroInfo.stageLevel);
        });
        this.btn_AddArtifact.onClick.AddListener(() =>
        {
            var name = string.Format("아티펙트 {0}", i++);
            Debug.LogFormat("{0} 추가", name);
            info.heroInfo.artifacts.Add(new ArtifactData(name));
        });

    }
}
