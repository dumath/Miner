using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    private float _speed; //Скорость перемещения коробля в пространстве.
    private float acceleration; // Ускорение корабля.
    private float currentSpeed; //Действующая скорость.
    private CharacterController ship;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<CharacterController>();
        acceleration = 0.5f;
        currentSpeed = 0.0f;
        this._speed = PlayerPrefs.GetFloat("_speed", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < _speed)
            currentSpeed += acceleration;
        else if (currentSpeed > _speed)
            currentSpeed -= acceleration;
        Vector3 newPos = new Vector3(0.0f, 0.0f, -currentSpeed * Time.deltaTime);
        newPos = transform.TransformDirection(newPos);
        ship.Move(newPos);
    }

    public float Speed
    {
        get => Speed;
        set
        {
            if (value >= -5 && value <= 100)
                _speed = value;
        }
    }
}
