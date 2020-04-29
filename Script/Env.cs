using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Env : MonoBehaviour
{
    public static readonly float[] Map_size = { 550, 550 };
    public static List<float[]> ExistingChunck = new List<float[]>();
    // Start is called before the first frame update
    void Start()
    { 
        //FILL EXISTING CHUNCK (INSTANCIATED AT LAUNCH)
        float[] chunck1 = { -(Map_size[0] / 2f), Map_size[1] / 2f + Map_size[1] };
        ExistingChunck.Add(chunck1);
        float[] chunck2 = { (Map_size[0] / 2f) + Map_size[0], Map_size[1] / 2f + Map_size[1] };
        ExistingChunck.Add(chunck2);
        float[] chunck3 = { -(Map_size[0] / 2f), Map_size[1] / 2f };
        ExistingChunck.Add(chunck3);
        float[] chunck4 = { Map_size[0] / 2f, Map_size[1] / 2f };
        ExistingChunck.Add(chunck4);
        float[] chunck5 = { Map_size[0] / 2f + Map_size[0], Map_size[1] / 2f };
        ExistingChunck.Add(chunck5);
        float[] chunck6 = { -(Map_size[0] / 2f), -(Map_size[1] / 2f) };
        ExistingChunck.Add(chunck6);
        float[] chunck7 = { Map_size[0] / 2f, Map_size[1] / 2f + Map_size[1] };
        ExistingChunck.Add(chunck7);
        float[] chunck8 = { Map_size[0] / 2f, -(Map_size[1] / 2f) };
        ExistingChunck.Add(chunck8);
        float[] chunck9 = { Map_size[0] / 2f + Map_size[0], -(Map_size[1] / 2f) };
        ExistingChunck.Add(chunck9);

    }

    // Update is called once per frame
    void Update()
    {
        print(ExistingChunck.Count);
        
    }
}
