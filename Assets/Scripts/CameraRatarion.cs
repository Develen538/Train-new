using UnityEngine;

public class CameraRatarion : MonoBehaviour
{
    private float X, Y;
    private int speeds = 200;
    private float eulerX = 0, eulerY = 0;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        X = Input.GetAxis("Mouse X") * speeds * Time.deltaTime;
        Y = -Input.GetAxis("Mouse Y") * speeds * Time.deltaTime;

        eulerX = (transform.rotation.eulerAngles.x + Y) % 360;
        eulerY = (transform.rotation.eulerAngles.y + X) % 360;
        transform.rotation = Quaternion.Euler(eulerX, eulerY, 0);

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
