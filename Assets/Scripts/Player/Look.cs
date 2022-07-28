using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    #region Fields
    private float minVer = -45.0f; // ������������ ������������ ���. ����������� ���� ������.
    private float maxVer = 45.0f; // ������������ ������������ ���. ������������ ���� ������.
    private float rotationX = 0; // ������� ��������� ���� �� ��� �.
    private float sensativityX = 0; // ������� �������� �������� �� ��� �. ������ Input.GetAxis. �������� �� "Stick" �������.
    private float sensativityY = 0; // ������� �������� �������� �� ��� Y. ������ Input.GetAxis. �������� �� "Stick" �������.
    #endregion

    #region Awake, Start, Update, LateUpdate
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationX -= sensativityY;
        rotationX = Mathf.Clamp(rotationX, minVer, maxVer);
        float delta = sensativityX;
        float rotationY = transform.localEulerAngles.y + delta;
        Vector3 newRotation = new Vector3(rotationX, rotationY, 0);
        transform.localEulerAngles = newRotation;
    }
    #endregion

    #region Methods
    /// <summary>
    /// �����, ���������� �������� Stick.
    /// </summary>
    /// <param name="x"> ���������� "Stick" �� ��� X. </param>
    public void LookSensativityX(float x)
    {
        this.sensativityX = x *Time.deltaTime;
    }

    /// <summary>
    /// �����, ���������� �������� Stick.
    /// </summary>
    /// <param name="y"> ���������� "Stick" �� ��� Y. </param>
    public void LookSensativityY(float y)
    {
        this.sensativityY = y * Time.deltaTime;
    }
    #endregion
}
