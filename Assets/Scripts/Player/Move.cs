using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    #region Field
    private float ShipSpeed = 200.0f; //TODO: ��������� ������������.
    public float ShipSpeedRear = 60.0f;
    private float currentSpeed = 0.0f;
    #endregion

    #region Awake, Start, Update, LateUpdate
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0,0, -currentSpeed);
        movement = transform.TransformDirection(movement);
        movement *= Time.deltaTime;
        GetComponent<CharacterController>().Move(movement);
    }
    #endregion

    #region Methods
    /// <summary>
    /// ����� ������������� �������� �������� �������.
    /// </summary>
    /// <param name="speed"> ������� ������ ������� "Setter". </param>
    public void SetSpeed(float speed)
    {
        //TODO: ��������� ��������. ������ �������� � �������� �������� �������� �������.
        //400/200, � ������ ������, ����� Setter � �������� �� ����������c�.
        //������ ������� �������� ��������������� ������ Setter'a.
        currentSpeed = Mathf.Min(ShipSpeed, speed) - ShipSpeedRear;
    }
    #endregion
}
