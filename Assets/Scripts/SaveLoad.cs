using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    
    //private BallGroup ballgroup;
    private GGbrahData ggbrah;
    private List<GameObject> goList;
    public int nbBalls;
    public string fileName;

    public void Start()
    {
        ggbrah = new GGbrahData();
        goList = new List<GameObject>();
    }

    public void NewGroup()
    {
        ClearGOList(goList);

        for (int i = 0; i < nbBalls; i++)
        {
            float[] frandom = { Random.value, Random.value, Random.value };
            float[] frandom2 = { Random.Range(0, 15), Random.Range(0, 15), Random.Range(0, 15) };
            float[] frandom3 = { Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5) };
            ggbrah.list.Add(new GGbrahData(frandom, frandom2, frandom3));
        }

        foreach (GGbrahData gg in ggbrah.list)
        {
            GameObject o = GameObject.Instantiate(Resources.Load("Prefabs/ballprefab") as GameObject);

            Vector3 v3 = new Vector3();
            v3.x = gg.position[0];
            v3.y = gg.position[1];
            v3.z = gg.position[2];
            o.transform.position = v3;

            MeshRenderer mr = o.GetComponent<MeshRenderer>();
            Color c = new Color(gg.rgb[0], gg.rgb[1], gg.rgb[2]);

            mr.material.color = c;

            Rigidbody rb = o.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(gg.velocity[0], gg.velocity[1], gg.velocity[2]);
            goList.Add(o);
        }

    }

    public void SaveButton()
    {
        for (int i = 0; i < goList.Count; i++) {
            ggbrah.list[i].position = new float[] { goList[i].transform.position.x, goList[i].transform.position.y, goList[i].transform.position.z };
            MeshRenderer mr = goList[i].GetComponent<MeshRenderer>();
            ggbrah.list[i].rgb = new float[] { mr.material.color.r, mr.material.color.g, mr.material.color.b };
            Rigidbody rb = goList[i].GetComponent<Rigidbody>();
            ggbrah.list[i].velocity = new float[] { rb.velocity.x, rb.velocity.y, rb.velocity.z };
        }
        SaveDataToDisk(fileName, ggbrah);
        Debug.Log("saved");

    }

    public void SaveAsJSON() {


    }
    public void LoadJSON() { }

    public void Loadbutton()
    {
        ggbrah = LoadDataFromDisk<GGbrahData>(fileName);
        int count = ggbrah.list.Count;

        ClearGOList(goList);
        
        for (int i = 0; i < count; i++)
        {
            //GameObject go = GGBrahToGameObject(ggbrah.list[i], i);
            goList.Add(GGBrahToGameObject(ggbrah.list[i], i));
        }
    }

    public void ClearGOList(List<GameObject> list) {

        for (int i = list.Count; i >= 0; i--) {
            Debug.Log("Destroying : " + list[i].name);
            Destroy(list[i]);
            list.RemoveAt(i);
        }

        //foreach (GameObject go in list)
        //{
        //    Destroy(go);
        //    list.Remove(go);
        //}
    }

    public GameObject GGBrahToGameObject(GGbrahData gg, int i) {
        GameObject go = GameObject.Instantiate(Resources.Load("Prefabs/ballprefab") as GameObject);

        go.transform.position = new Vector3(gg.position[0], gg.position[1], gg.position[2]);
        go.GetComponent<Rigidbody>().velocity = new Vector3(gg.velocity[0], gg.velocity[1], gg.velocity[2]);
        go.GetComponent<MeshRenderer>().material.color = new Color(gg.rgb[0], gg.rgb[1], gg.rgb[2]);
        return go;
    }

    public void SaveDataToDisk(string filePath, object toSave)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.streamingAssetsPath + "/" + filePath;
        //string path2 = Path.Combine()
        FileStream file = File.Create(path);
        bf.Serialize(file, toSave);
        file.Close();
    }

    /**
     * Loads the save data from the disk
     */
    public T LoadDataFromDisk<T>(string filePath)
    {
        T toRet;
        string path = Application.streamingAssetsPath + "/" + filePath;
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            toRet = (T)bf.Deserialize(file);
            file.Close();
        }
        else
            toRet = default(T);
        return toRet;
    }
}
