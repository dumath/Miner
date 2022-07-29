using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTypeOne : MonoBehaviour
{
    //Completed
    //TODO: Наладить свечение частицы двигателя.
    //TODO: Описать свойства контакта, взрыва.

    #region Constants
    private const float MISSILE_SPEED = 400.0f; // Максимальная скорость полета ракеты.
    private const float MISSILE_ACCELERATION = 0.2f; // Ускорение ракеты.
    #endregion

    #region Fields
    [SerializeField] private ParticleSystem engine; // Система частиц двигателя ракеты.
    private bool isLaunchAllowed = false; // Разрешен запуск?
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
    /// Метод запуска ракеты из обоймы. 
    /// </summary>
    /// <param name="shipSpeed"> Скорость коробля - изначальная скорость ракеты. </param>
    public void Launch(float shipSpeed)
    {
        //TODO: Продебажить двойной запуск. Пока 4 кассеты не описаны.(Увеличение скорости, за счет присвоения скорости коробля).
        isLaunchAllowed = !isLaunchAllowed;
        Speed += shipSpeed;
    }
    #endregion
}
