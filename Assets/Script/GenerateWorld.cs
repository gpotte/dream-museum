using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GenerateWorld : MonoBehaviour
{
    float[] Map_size = { 550, 550 };
    Object[] ObjList;
    Vector3 pos;
    List<Vector3> existingPos = new List<Vector3>();

    // Start is called before the first frame update
    void Start() {
    //GENERATING TERRAIN
       TerrainData TData = new TerrainData();
        float[,] heightmap = new float[32, 32];
        TData.SetHeights(0, 0, heightmap);
        TData.size = new Vector3(Map_size[0], 1, Map_size[1]);
        var TerrainCreated = Terrain.CreateTerrainGameObject(TData);
        TerrainCreated.AddComponent<Rigidbody>();
        TerrainCreated.GetComponent<Rigidbody>().useGravity = false;
        Material Floor = Resources.Load("Materials/Floor", typeof(Material)) as Material;
        print(TerrainCreated.GetComponent<Terrain>().materialTemplate = Floor);
    //FETCH THE OBJECTS
        ObjList = Resources.LoadAll("Objects/", typeof(GameObject));
        List<int> usedObj = new List<int>();
        for (int i = 1; i < 11 && i <= ObjList.Length; i++)
        {
            int j = Random.Range(0, ObjList.Length -1);
            while(usedObj.IndexOf(j) != -1)
              j = Random.Range(0, ObjList.Length);
            usedObj.Add(j);
            InstantiateObj(ObjList[j]);
        }

        //SET CAMERA
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector3(Map_size[0]/2, 8.75f, Map_size[1]/2);
    }

    void InstantiateObj(Object obj)
    {
        //INSTANTIATE AN OBJECT + ALL THE NEEDED COMPONENTS
        pos = determinePos((GameObject)obj);
        existingPos.Add(pos);
        var ObjCreated = (GameObject)Instantiate(obj, pos, Quaternion.identity);
        ObjCreated.SetActive(true);
    }

    Vector3 determinePos(GameObject obj)
    {
        Vector3 size =  obj.GetComponent<Renderer>().bounds.size;
        float longside = Mathf.Max(Mathf.Max(size.x, size.y), size.z); ;
   
        pos = new Vector3(Random.Range(5.0f, Map_size[0] - 5), longside / 1.5f, Random.Range(5.0f, Map_size[1] - 5));
        foreach(Vector3 exist in existingPos)
        {
            if (Mathf.Abs(pos[0] - exist[0]) < 25 &&  Mathf.Abs(pos[2] - exist[2]) < 15)
                return (determinePos(obj));
        }
        return (pos);
    }
       
    

    // Update is called once per frame
    void Update()
    { }
}

