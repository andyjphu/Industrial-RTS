using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System;

[ExecuteAlways]
public class GenerateMap : MonoBehaviour
{
    public GameObject Map;
    public GameObject MapExample;

    public List<UnityCell> MapData = new List<UnityCell>();

    [Serializable]
    public class JSONCell
    {
        public string id, terrain, building;
    }

    [Serializable]
    public class JSONMapData
    {
        public JSONCell[] JSONCellData;
    }

    private TextAsset file;

    private void OnDrawGizmos()
    {
    }

    public class UnityCell
    {
        public int centerX, centerY;
        public string terrain, building, id;

        public UnityCell(string _id, string _terrain, string _building)
        {
            centerX = Int32.Parse(_id.Split(",")[0]);
            centerY = Int32.Parse(_id.Split(",")[1]);
            id = _id;
            terrain = _terrain;
            building = _building;
        }
    }

    public class UnityVoxel
    {
        public int centerX, centerY, centerZ;
        public string terrain, building, unit;
    }

    /*
    public UnityCell toUnityCell(int centerX, int centerY, string terrain, string building)
    {
        UnityCell tempCell = new UnityCell(centerX
        tempCell.centerX = centerX;

        return tempCell;
    }
    */

    private void Awake()
    {
        //--
        file = Resources.Load("JSONMapData") as TextAsset;
        //print(file.text);
        JSONMapData json = JsonUtility.FromJson<JSONMapData>(file.text);
        //Debug.Log(json.JSONCellData);

        foreach (JSONCell cell in json.JSONCellData)
        {
            MapData.Add(new UnityCell(cell.id, cell.terrain, cell.building));
            //print("added");
            //print(MapData[0].building);
        }

        bool childExists = false;
        foreach (Transform child in Map.transform)
        {
            foreach (UnityCell cell in MapData)
            {
                if (cell.id == "-69,-69")
                {
                    childExists = true;
                }
            }
            print(child.name);
        }
        if (childExists)
        {
            print("child does exist");
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}