using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraCollisionChecker m_CamColChecker;
    [SerializeField] private Transform m_CameraPos;
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
        CameraMove();
    }
    private void Init()
    {
        m_ScreenWidth = Screen.currentResolution.width;
        m_ScreenHeight = Screen.currentResolution.height;
        m_CurrRadius = m_MaxRadius;
        m_CamColChecker.Init(m_MaxRadius);
    }

    // 1920 / 1920 , 360 / 360
    private void CameraMove()
    {
        m_X_Direction = Mathf.Sin(m_Sensitive * Input.mousePosition.x / m_ScreenWidth);
        m_Z_Direction = Mathf.Cos(m_Sensitive * Input.mousePosition.x / m_ScreenWidth); // 계속 돌아가도 됨.

        m_Y_Direction = Mathf.Lerp(-5.0f, 5.0f, Input.mousePosition.y / m_ScreenHeight);
        m_CameraPos.position = m_PlayerPos.position + m_CameraOffset + new Vector3(m_X_Direction * m_CamColChecker.Distance, m_IsYReverse ? -m_Y_Direction : m_Y_Direction, m_Z_Direction * m_CamColChecker.Distance);
        m_CameraPos.LookAt(m_PlayerPos);
        
        m_CamColChecker.transform.position = m_PlayerPos.position + m_CameraOffset + new Vector3(m_X_Direction * m_MaxRadius, m_IsYReverse ? -m_Y_Direction : m_Y_Direction, m_Z_Direction * m_MaxRadius);
        m_CamColChecker.transform.LookAt(m_PlayerPos);
    }
}
