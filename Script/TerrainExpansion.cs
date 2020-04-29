using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TerrainExpansion : MonoBehaviour
{
    Vector3 CurrentPos;
    float[] Map_size = { 550, 550 };
    float[] CurrentChunck = { 0, 0, 0, 0 };
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPos = transform.position;
        CurrentChunck[0] = Mathf.Floor(CurrentPos[0] / Map_size[0]) * Map_size[0]; //CURRENT CHUNK MIN X
        CurrentChunck[1] = (Mathf.Floor(CurrentPos[0] / Map_size[0]) + 1) * Map_size[0]; //CURRENT CHUNCK MAX X
        CurrentChunck[2] = Mathf.Floor(CurrentPos[2] / Map_size[1]) * Map_size[1]; // CURRENT CHUNK MIN Z
        CurrentChunck[3] = (Mathf.Floor(CurrentPos[2] / Map_size[1]) + 1) * Map_size[1]; // CURRENT CHUNK MAX Z

        if (Mathf.Abs(CurrentPos[0] - CurrentChunck[0]) < Map_size[0] / 10f || Mathf.Abs(CurrentPos[0] - CurrentChunck[1]) < Map_size[0] / 10f || Mathf.Abs(CurrentPos[2] - CurrentChunck[2]) < Map_size[1] / 10f || Mathf.Abs(CurrentPos[2] - CurrentChunck[3]) < Map_size[1] / 10f) //DETECT IF THE PLAYER IS LEAVING THE CHUNCK
            print("lol");
    }
}
