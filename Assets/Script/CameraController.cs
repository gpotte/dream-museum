using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform Player;
    float xrot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
    

        //CAMERA INPUT ROT
        float sensitivity = 250f;
         float cameraX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
         float cameraY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;

        xrot -= cameraY;
        xrot = Mathf.Clamp(xrot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xrot, 0f, 0f);
        Player.Rotate(Vector3.up * cameraX);

    }
}
