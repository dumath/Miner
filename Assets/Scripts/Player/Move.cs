using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    #region Field
    private float ShipSpeed = 200.0f; //TODO: Поставить ограничитель.
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
    /// Метод устанавливает значение скорости корабля.
    /// </summary>
    /// <param name="speed"> Текущая высота объекта "Setter". </param>
    public void SetSpeed(float speed)
    {
        //TODO: Временная заглущка. Высоту перевсти в значение скорости текущего корабля.
        //400/200, в данном случае, чтобы Setter в холостую не растягивалcя.
        //Каждая единица скорости соответствовала высоте Setter'a.
        currentSpeed = Mathf.Min(ShipSpeed, speed) - ShipSpeedRear;
    }
    #endregion
}
