using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stick : MonoBehaviour
{
    [SerializeField] private GameObject pimp;
    private Vector3 defaultPimpSize;
    private float _sensativity; 
    private float translateX = 0.0f;
    private float translateY = 0.0f;
    private float minimumTranslate = -26.0f; //Минимальное, допустимое положение Pimp по оси Х(негативное)
    private float maximumTranslate = 26.0f; //Максимальное, допустимое положение Pimp по оси Y(позитивное)
    private bool stickActivated = false;
    //private Color higthLigthColor = Color.cyan;
    private Vector2 startPosition;
    private bool isMouseOver = false; //TODO: Заменить


    // Start is called before the first frame update
    void Start()
    {
        startPosition = pimp.transform.localPosition;
        _sensativity = PlayerPrefs.GetFloat("_sensativity", 20);
    }

    // Update is called once per frame
    void Update()
    {
        
        //TODO: Переделать
        if(Input.GetMouseButton(0) && isMouseOver)
        {
            translateX = Input.GetAxis("Mouse X") * _sensativity;
            translateX = Mathf.Clamp(translateX, minimumTranslate, maximumTranslate);
            translateY = Input.GetAxis("Mouse Y") * _sensativity;
            translateY = Mathf.Clamp(translateY, minimumTranslate, maximumTranslate);
            Vector2 position = new Vector2(translateX, translateY);
            position = Vector2.ClampMagnitude(position, _sensativity);
            pimp.transform.localPosition = position;
            stickActivated = true;
        }
    }

    #region Methods
    public void OnMouseUp()
    {
        stickActivated = false;
        pimp.transform.localPosition = startPosition;
    }

    public void OnMouseOver()
    {
        //this.GetComponent<SpriteRenderer>().color = higthLigthColor;
        this.isMouseOver = true;
    }

    public void OnMouseExit()
    {
        isMouseOver = false;
    }

    public bool IsActivated() => stickActivated;
    #endregion

    #region Propertyes
    public float Sensativity { get => _sensativity; set => _sensativity = value; } // Установка значения скорости перемещения "Pimp"

    #endregion
}
