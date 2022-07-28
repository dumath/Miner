using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    #region Fields
    private float minVer = -45.0f; // Ограничитель вертикальной оси. Минимальный угол обзора.
    private float maxVer = 45.0f; // Ограничитель вертикальной оси. Максимальный угол обзора.
    private float rotationX = 0; // Текущее положение угла по оси Х.
    private float sensativityX = 0; // Текущее скорость вращения по оси Х. Аналог Input.GetAxis. Приходит от "Stick" объекта.
    private float sensativityY = 0; // Текущее скорость вращения по оси Y. Аналог Input.GetAxis. Приходит от "Stick" объекта.
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
    /// Метод, вызываемый событием Stick.
    /// </summary>
    /// <param name="x"> Координата "Stick" по оси X. </param>
    public void LookSensativityX(float x)
    {
        this.sensativityX = x *Time.deltaTime;
    }

    /// <summary>
    /// Метод, вызываемый событием Stick.
    /// </summary>
    /// <param name="y"> Координата "Stick" по оси Y. </param>
    public void LookSensativityY(float y)
    {
        this.sensativityY = y * Time.deltaTime;
    }
    #endregion
}
