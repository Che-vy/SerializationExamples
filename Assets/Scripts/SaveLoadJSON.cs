using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class SaveLoadJSON : MonoBehaviour
{

    public List<GameObject> goList;
    public List<GGbrah> ggList;
    public List<GGbrahData> dataList;
    public string dataNode;
    public string filename;

    public void Awake()
    {
        goList = new List<GameObject>();
        ggList = new List<GGbrah>();
        dataList = new List<GGbrahData>();
    }

    public void Start()
    {


    }


    public void NewButton()
    {
        GameObject go = new GameObject();
        go.AddComponent(typeof(GGbrah));
        GGbrah gg = go.GetComponent<GGbrah>();
        gg.RandomInit();
        ggList.Add(gg);
        goList.Add(go);
    }

    public void SaveButton()
    {
        foreach (GGbrah gg in ggList)
        {
            dataList.Add(gg.ExportAsBallData());
        }
        JsonManager.SaveObjectAsJSONToStreamingAsset(dataList, filename);
    }

    public void Loadbutton()
    {
        dataNode = JsonManager.LoadAllText(filename + ".json");


        foreach (GameObject go in goList) { Destroy(go); }
        goList = new List<GameObject>();
        ggList = new List<GGbrah>();

        dataList = JsonManager.DeserializeJson<List<GGbrahData>>(dataNode);

        for (int i = 0; i < dataList.Count; i++)
        {

            GameObject go = new GameObject();
            go.AddComponent(typeof(GGbrah));
            GGbrah gg = go.GetComponent<GGbrah>();
            gg.Init();
            gg.ImportBallData(dataList[i]);

            ggList.Add(gg);
            goList.Add(go);
        }

    }

}
