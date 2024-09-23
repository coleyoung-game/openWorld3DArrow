using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    [SerializeField] private Button m_Btn_URL;
    void Start()
    {
        m_Btn_URL.onClick.AddListener(() => OnButtonClick());
    }


    private void OnButtonClick()
    {
        Application.OpenURL("https://github.com/coleyoung-game");
    }
}
