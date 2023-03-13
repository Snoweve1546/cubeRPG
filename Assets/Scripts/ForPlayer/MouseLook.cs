using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //靈敏度數值
    [SerializeField] float mouseSensitivity = 100f;
    //在Inspector裡面會空出一小格做出分叉
    [Space]
    //tooltip可以用來幫一個資訊做註解
    [Tooltip("123456")]
    //能用來分類使用方式的變數
    [Header("MouseY")]
    //用來儲放玩家Transform，轉鏡頭時身體會跟著旋轉(rotate)
    [SerializeField] Transform playerBody;
    //
    [SerializeField] float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //獲取滑鼠移動情況 
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
