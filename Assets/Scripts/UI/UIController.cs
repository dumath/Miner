using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject playerShip; 
    [SerializeField] private GameObject stick; 
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private Text position;
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        settingsWindow.SetActive(false);
        position.text = playerShip.transform.position.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        position.text = playerShip.transform.position.ToString();
    }


    #region Methods
    /// <summary>
    /// ������� �� ���� ��������, ��������� �������� ����������� "Ship".
    /// </summary>
    /// <param name="speed">�������� �������� ����������� Ship.</param>
    public void SetSpeed(float speed)
    {
        playerShip.GetComponent<Move>().Speed = speed;
    } 

    /// <summary>
    /// ������� �� ���� ��������, ��������� �������� ����������� "Pimp".
    /// </summary>
    /// <param name="sensativityValue"> �������� �������� �����������.</param>
    public void SetStickSensativity(float sensativityValue)
    {
        stick.GetComponentInChildren<Stick>().Sensativity = sensativityValue;
    }

    /// <summary>
    /// ���� �������� ������ ����.
    /// </summary>
    public void OpenSettingsWindow()
    {
        if (!settingsWindow.activeSelf)
            settingsWindow.SetActive(true);
    }

    /// <summary>
    /// �������� ���� �������� ������ ����.
    /// </summary>
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    #endregion
}
