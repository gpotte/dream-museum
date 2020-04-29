using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Specialized;

public class GenerateWorld : MonoBehaviour
{
    //GENERAL SETTING FOR TERRAIN SIZE (TO CHANGE IN THE CHUNK GENERATION ASWELL)
    //MUST NEVER BE ODD NUMBERS
    float[] Map_size = Env.Map_size;

    //ALL VAR USED FOR OBJECT INSTANCIATIONS
    Object[] ObjList;
    Vector3 pos;
    List<Vector3> existingPos = new List<Vector3>();
    List<int> usedObj = new List<int>();

    // Start is called before the first frame update
    void Start() {

        //GENERATING TERRAIN
        GenerateTerrainObj();   

        
    //FETCH THE OBJECTS
        FetchAndPlaceObj();

    //SET CAMERA
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = new Vector3(Map_size[0]/2, 8.75f, Map_size[1]/2);
    }
    //GENERATE TERAIN OBJECT PREFAB 
    void GenerateTerrainObj()
    {
        Material Floor = Resources.Load("Materials/Floor", typeof(Material)) as Material; //TERRAIN MATERIAL
        TerrainData TData = new TerrainData();

        float[,] heightmap = new float[32, 32];
        TData.SetHeights(0, 0, heightmap);
        TData.size = new Vector3(Map_size[0], 1, Map_size[1]);

        var TerrainCreated = Terrain.CreateTerrainGameObject(TData);
        TerrainCreated.GetComponent<Terrain>().materialTemplate = Floor; //SET MATERIAL
        
        //GENERATE 9 FIRST CHUNKS IN A SQUARE
        TerrainCreated = Terrain.CreateTerrainGameObject(TData);
        TerrainCreated.transform.position = new Vector3(-Map_size[0], 0, Map_size[1]);
        TerrainCreated.GetComponent<Terrain>().materialTemplate = Floor;

        TerrainCreated = Terrain.CreateTerrainGameObject(TData);
        TerrainCreated.transform.position = new Vector3(0, 0, Map_size[1]);
        TerrainCreated.GetComponent<Terrain>().materialTemplate = Floor;

        TerrainCreated = Terrain.CreateTerrainGameObject(TData);
        TerrainCreated.transform.position = new Vector3(Map_size[0], 0, Map_size[1]);
        TerrainCreated.GetComponent<Terrain>().materialTemplate = Floor;

        TerrainCreated = Terrain.CreateTerrainGameObject(TData);
        TerrainCreated.transform.position = new Vector3(Map_size[0], 0, 0);
        TerrainCreated.GetComponent<Terrain>().materialTemplate = Floor;

        TerrainCreated = Terrain.CreateTerrainGameObject(TData);
        TerrainCreated.transform.position = new Vector3(Map_size[0], 0, -Map_size[1]);
        TerrainCreated.GetComponent<Terrain>().materialTemplate = Floor;

        TerrainCreated = Terrain.CreateTerrainGameObject(TData);
        TerrainCreated.transform.position = new Vector3(0, 0, -Map_size[1]);
        TerrainCreated.GetComponent<Terrain>().materialTemplate = Floor;

        TerrainCreated = Terrain.CreateTerrainGameObject(TData);
        TerrainCreated.transform.position = new Vector3(-Map_size[0], 0, -Map_size[1]);
        TerrainCreated.GetComponent<Terrain>().materialTemplate = Floor;

        TerrainCreated = Terrain.CreateTerrainGameObject(TData);
        TerrainCreated.transform.position = new Vector3(-Map_size[0], 0, 0);
        TerrainCreated.GetComponent<Terrain>().materialTemplate = Floor;

    }

    //FETCH OBJECTS NOT ALREADY USED & CALL THE INSTANCIATE
    void FetchAndPlaceObj()
    {
        ObjList = Resources.LoadAll("Objects/", typeof(GameObject));
        for (int i = 1; i < 11 && i <= ObjList.Length; i++)
        {
            if (usedObj.Count == ObjList.Length)
                break;
            int j = Random.Range(0, ObjList.Length - 1);
            while (usedObj.IndexOf(j) != -1)
                j = Random.Range(0, ObjList.Length);
            usedObj.Add(j);
            InstantiateObj(ObjList[j]);
        }
    }

    //GET CORRECT COORDINATES & INSTANCIATE
    void InstantiateObj(Object obj)
    {
        //INSTANTIATE AN OBJECT + ALL THE NEEDED COMPONENTS
        pos = determinePos((GameObject)obj);
        existingPos.Add(pos);
        var ObjCreated = (GameObject)Instantiate(obj, pos, Quaternion.identity);
        ObjCreated.SetActive(true);
    }

    //GET CORRECT COORDINATES (NOT USED & CORRECT HEIGHT)
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

