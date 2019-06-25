using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;

public class InfoManager : MonoBehaviour
{
    public static InfoManager Instance;

    [HideInInspector]
    public string heroInfoPath = "Info/HeroInfo.json";
    [HideInInspector]
    public HeroInfo heroInfo;

    void Awake()
    {
        InfoManager.Instance = this;
    }

    public void LoadInfo(string path)
    {
        this.heroInfo = new HeroInfo();

        if (File.Exists(path))
        {
            Debug.Log("파일을 찾았습니다.");
            var json = File.ReadAllText(path);
            var heroInfo = JsonConvert.DeserializeObject<HeroInfo>(json);
            this.heroInfo = heroInfo;
        }
        else
        {
            Debug.Log("파일을 찾지 못했습니다. 신규 생성 해주세요.");
            this.heroInfo = null;
        }
    }

    public void CreateInfo()
    {
        Debug.Log("신규 생성");

        var data = DataManager.Instance;
        data.LoadAllDatas();
        this.heroInfo = new HeroInfo();

        this.heroInfo.id = 0;
        this.heroInfo.stageLevel = 0;
        this.heroInfo.max_hp = data.dicHeroData[0].default_hp;
        this.heroInfo.gold = 0;
        this.heroInfo.artifacts = null;
        this.SaveInfo();
    }

    public void SaveInfo()
    {
        Debug.Log("세이브 인포");
        var json = JsonConvert.SerializeObject(this.heroInfo);
        System.IO.File.WriteAllText(this.heroInfoPath, json);
    }

}
