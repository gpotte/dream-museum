using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRot : MonoBehaviour
{
    
    Quaternion Coord;
    float rotTime;
    Quaternion currentPos;
    //bool Rotating;
    Quaternion velocity;

    void Start()
    {
        Coord = randomizerotation();
        float time = RandomTime();
        rotTime = time >= 5 ? time : 0;
        currentPos = new Quaternion(1, 1, 1, 0);
        
        while (rotTime == 0){
            time = RandomTime();
            rotTime = time >= 5 ? time : 0;
        }
        transform.rotation = currentPos;
        velocity = SetRot(Coord, rotTime, currentPos);
        currentPos = new Quaternion(currentPos.x + velocity.x, currentPos.y + velocity.y, currentPos.z + velocity.z, 0);
        transform.rotation = currentPos;
    }

    Quaternion randomizerotation()
    {
        return new Quaternion(Random.Range(-540, 980), Random.Range(-720, 980), Random.Range(-800, 980), 0);
    }

    float RandomTime()
    {
        return Random.Range(-10, 15);
    }

    Quaternion SetRot(Quaternion coord, float time, Quaternion pos )
    {
        float SpeedX = (coord.x - pos.x) / time * Time.deltaTime;
        float SpeedY = (coord.y - pos.y) / time * Time.deltaTime;
        float SpeedZ = (coord.z - pos.z) / time * Time.deltaTime;
        return new Quaternion (SpeedX, SpeedY, SpeedZ, 0);
    }

    Renderer rend;
void OnCollisionStay(Collision jeej)
    {
        print("lol");
    }

    void Update()
    {
       rotTime -= Time.deltaTime;
        if (rotTime <= 0)
        {
            Coord = randomizerotation();
            float time = RandomTime();
            rotTime = time >= 5 ? time : 0;
            while (rotTime == 0)
            {
                time = RandomTime();
                rotTime = time >= 5 ? time : 0;
            }
            velocity = SetRot(Coord, rotTime, currentPos);
        }
            //currentPos += velocity;
        currentPos = new Quaternion(currentPos.x + velocity.x, currentPos.y + velocity.y, currentPos.z + velocity.z, 0);
        transform.rotation = currentPos;
        
    }

}

