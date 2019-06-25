using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public Dictionary<int, HeroData> dicHeroData;

    //ex
    //public Dictionary<int, MonsterData> dicMonsterData;

    void Awake()
    {
        DataManager.Instance = this;
        this.dicHeroData = new Dictionary<int, HeroData>();
    }

    public void LoadAllDatas()
    {
        Debug.Log("데이터 로드");

        #region 로드데이터 호출
        this.dicHeroData = this.LoadData<HeroData>("Datas/HeroData");

        //ex
        //this.dicMonsterData = this.LoadData<MonsterData>("Datas/MonsterData");
        #endregion
    }

    private Dictionary<int, T> LoadData<T>(string path) where T : RawData
    {
        var data = Resources.Load<TextAsset>(path);
        var arrData = JsonConvert.DeserializeObject<T[]>(data.text);
        var dicData = arrData.ToDictionary(x => x.id, x => (T)x);
        return dicData;
    }
}
