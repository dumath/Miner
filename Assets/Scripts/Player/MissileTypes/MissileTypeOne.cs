using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTypeOne : MonoBehaviour
{
    //Completed
    //TODO: �������� �������� ������� ���������.
    //TODO: ������� �������� ��������, ������.

    #region Constants
    private const float MISSILE_SPEED = 400.0f; // ������������ �������� ������ ������.
    private const float MISSILE_ACCELERATION = 0.2f; // ��������� ������.
    #endregion

    #region Fields
    [SerializeField] private ParticleSystem engine; // ������� ������ ��������� ������.
    private bool isLaunchAllowed = false; // �������� ������?
    public float Speed = 0.1f;
    #endregion

    #region Awake, Start, Update, LateUpdate
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLaunchAllowed)
        {
            transform.Translate(0.0f, Speed * Time.deltaTime, 0.0f, Space.Self);
            if (Speed < MISSILE_SPEED)
            {
                Speed += MISSILE_ACCELERATION;
            }
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// ����� ������� ������ �� ������. 
    /// </summary>
    /// <param name="shipSpeed"> �������� ������� - ����������� �������� ������. </param>
    public void Launch(float shipSpeed)
    {
        //TODO: ����������� ������� ������. ���� 4 ������� �� �������.(���������� ��������, �� ���� ���������� �������� �������).
        isLaunchAllowed = !isLaunchAllowed;
        Speed += shipSpeed;
    }
    #endregion
}
