using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_PlayerPos;
    [SerializeField] private Transform m_Raycaster;
    [SerializeField] private float m_MaxRadius;
    [SerializeField] private bool m_IsYReverse;
    [SerializeField] private float m_Sensitive;
    [SerializeField] private Vector3 m_CameraOffset;

    private float m_CurrRadius;

    private float m_ScreenWidth;
    private float m_ScreenHeight;

    private float m_X_Direction;
    private float m_Y_Direction;
    private float m_Z_Direction;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        RotateForMouse();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            m_CurrRadius = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            m_CurrRadius = m_MaxRadius;
        }
    }


    private void Init()
    {
        m_ScreenWidth = Screen.currentResolution.width;
        m_ScreenHeight = Screen.currentResolution.height;
        m_CurrRadius = m_MaxRadius;
    }

    // 1920 / 1920 , 360 / 360
    private void RotateForMouse()
    {
        m_X_Direction = m_CurrRadius * Mathf.Sin(m_Sensitive * Input.mousePosition.x / m_ScreenWidth);
        m_Z_Direction = m_CurrRadius * Mathf.Cos(m_Sensitive * Input.mousePosition.x / m_ScreenWidth); // 계속 돌아가도 됨.

        m_Y_Direction = Mathf.Lerp(-5.0f, 5.0f, Input.mousePosition.y / m_ScreenHeight);
        transform.position = m_PlayerPos.position + m_CameraOffset + new Vector3(m_X_Direction, m_IsYReverse ? -m_Y_Direction : m_Y_Direction, m_Z_Direction);
        transform.LookAt(m_PlayerPos);
        //Ray ray;
        //RaycastHit t_RayHit;
        //Debug.DrawRay(m_Raycaster.position, m_Raycaster.forward * m_MaxRadius, Color.red, 0.01f);
        //// TODO: raycast를 쏘는 GameObject를 하나 더 둔다. 그 GameObject의 위치는 변하지 않는다.
        //if (Physics.Raycast(m_Raycaster.position, m_Raycaster.forward * m_MaxRadius, out t_RayHit, m_MaxRadius))
        //{
        //    if(t_RayHit.collider.gameObject.CompareTag("Box"))
        //    {
        //        m_CurrRadius = 1;
        //    }
        //    else if (t_RayHit.collider.gameObject.CompareTag("Player"))
        //    {
        //        m_CurrRadius = m_MaxRadius;
        //    }
        //    Debug.Log("!");
        //    //m_CurrRadius = 1;//Vector3.Distance(transform.position, t_RayHit.transform.position);
        //    Debug.Log($"m_CurrRadius :{m_CurrRadius}");
        //    //if (Vector3.Distance(transform.position, t_RayHit.transform.position))
        //}
    }
}
