using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //�F�ӫ׼ƭ�
    [SerializeField] float mouseSensitivity = 100f;
    //�bInspector�̭��|�ťX�@�p�氵�X���e
    [Space]
    //tooltip�i�H�Ψ����@�Ӹ�T������
    [Tooltip("123456")]
    //��ΨӤ����ϥΤ覡���ܼ�
    [Header("MouseY")]
    //�Ψ��x�񪱮aTransform�A�����Y�ɨ���|��۱���(rotate)
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
        //����ƹ����ʱ��p 
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
