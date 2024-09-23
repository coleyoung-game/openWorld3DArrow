using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    [SerializeField] private float m_Radious;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"m_Radious Sin :{Mathf.Sin(m_Radious*Time.time)}");
        transform.position = new Vector3(m_Radious * Mathf.Sin(Time.time), 0, m_Radious * Mathf.Cos(Time.time));
    }
}
