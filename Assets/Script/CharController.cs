using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    private float m_XPos;
    private float m_ZPos;
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
        transform.Translate(new Vector3(m_XPos, 0, m_ZPos));
    }

    private void RotatePlayer()
    {

    }
}
