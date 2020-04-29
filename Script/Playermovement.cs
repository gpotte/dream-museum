using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float PanSpeed = 12f;
    public float Grav = -9.81f;
    public CharacterController controller;

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        float posz = 0;
        float posx = 0;
        //CAMERA INPUT MOVEMENT
        if (Input.GetKey("w") || Input.GetKey("z"))
        {
            posz = 1; }
        if (Input.GetKey("s"))
            posz = -1;
        if (Input.GetKey("a") || Input.GetKey("q"))
            posx = -1;
        if (Input.GetKey("d"))
            posx = 1;
        if (Input.GetKey("escape"))
            Application.Quit();
        Vector3 move = transform.right * posx + transform.forward * posz;
        controller.Move(move * PanSpeed * Time.deltaTime);
        velocity.y += Grav * Time.deltaTime;
    }
}
