using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    [SerializeField] private Animator m_Anim;
    [SerializeField] private Transform m_CamPos;
    private float m_XPos;
    private float m_ZPos;
    private bool m_IsMove;
    private bool m_IsRotate = false;
    void Start()
    {
        
    }

    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        m_XPos = Input.GetAxis("Horizontal") * m_Speed;
        m_ZPos = Input.GetAxis("Vertical") * m_Speed;
        //m_IsMove = m_XPos != 0 || m_ZPos != 0;
        //m_Anim.SetBool("IsWalk", m_IsMove);
        transform.Translate(new Vector3(m_XPos, 0, m_ZPos));
        //Vector3 t_CamQuater = m_CamPos.eulerAngles;
        //if (m_IsMove && !m_IsRotate)
        //{
        //    if (m_XPos > 0)
        //        t_CamQuater.y += 90;
        //    else if(m_XPos < 0)
        //        t_CamQuater.y -= 90;
        //    else if(m_ZPos < 0)
        //        t_CamQuater.y += 180;
        //    transform.rotation = Quaternion.Euler(new Vector3(0, t_CamQuater.y, 0));
        //    m_IsRotate = true;
        //}
        //else
        //    m_IsRotate = false;
    }

    private void RotatePlayer()
    {

    }
}
