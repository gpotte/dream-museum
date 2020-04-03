using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Universe;


public class GenerateWorld : MonoBehaviour
{

    Object[] ObjList;
    Vector3 pos;
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(WaitForManager());
    //GENERATING TERRAIN
        TerrainData TData = new TerrainData();
        float[,] heightmap = new float[32, 32];
        TData.SetHeights(0, 0, heightmap);
        TData.size = new Vector3(256, 1, 256);
        var TerrainCreated = Terrain.CreateTerrainGameObject(TData);
        TerrainCreated.AddComponent<Rigidbody>();
        TerrainCreated.GetComponent<Rigidbody>().useGravity = false;
    //FETCH THE OBJECTS
        ObjList = Resources.LoadAll("Models", typeof(GameObject));

        InstantiateObj(ObjList[0]);
        
    }

    private Rigidbody rigid;
    private MeshCollider collider;
    private randomRot RR;

    void InstantiateObj(Object obj)
    {
    //INSTANTIATE AN OBJECT + ALL THE NEEDED COMPONENTS
        pos = new Vector3(0, 1, 0); 
        var ObjCreated = (GameObject)Instantiate(ObjList[0], pos, Quaternion.identity);
        ObjCreated.AddComponent<MeshFilter>();
        MeshFilter Mesh = ObjCreated.GetComponent<MeshFilter>();
        ObjCreated.SetActive(true);
        ObjCreated.AddComponent<MeshRenderer>();
        collider = ObjCreated.AddComponent<MeshCollider>();
        collider.sharedMesh = Mesh.mesh;
        collider.convex = true;
        rigid = ObjCreated.AddComponent<Rigidbody>();
        rigid.useGravity = false;
        rigid.isKinematic = true;
        ObjCreated.AddComponent<randomRot>();
    }

    private IEnumerator WaitForManager()
    {
        while (MyManager.Instance == null)
            yield return null;
    }
        
       
    

    // Update is called once per frame
    void Update()
    { }
}

