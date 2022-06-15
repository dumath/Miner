using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject pimp;

    private float minVer = -80.0f; // ����������� �������� ����(������������ ��������).
    private float maxVer = 80.0f; // ������������ �������� ����(������������ ��������).

    private float sensativity = 9.0f; // �������� �������� ������� �� ���������.
    private float deltaX; // �������� ��������� �� ��� X.
    private float deltaY; // �������� ��������� �� ��� Y.
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        deltaX = 0.0f;
        deltaY = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (pimp.GetComponent<Stick>().IsActivated())
        {
            deltaX -= Input.GetAxis("Mouse Y") * sensativity;
            deltaX = Mathf.Clamp(deltaX, minVer, maxVer);
            float delta = Input.GetAxis("Mouse X") * sensativity;
            deltaY = transform.localEulerAngles.y + delta;
            transform.eulerAngles = new Vector3(deltaX, deltaY, 0);
        }
    }
    
}
