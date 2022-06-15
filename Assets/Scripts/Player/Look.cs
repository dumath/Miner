using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject pimp;

    private float minVer = -80.0f; // ћинимальное значение угла(вертикальное вращение).
    private float maxVer = 80.0f; // ћаксимальное значение угла(вертикальное вращение).

    private float sensativity = 9.0f; // —корость вращени€ коробл€ на плоскости.
    private float deltaX; // ¬еличина изменени€ по оси X.
    private float deltaY; // ¬еличина изменени€ по оси Y.
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
