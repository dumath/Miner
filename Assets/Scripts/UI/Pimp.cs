using UnityEngine;
using UnityEngine.UI;

public class Pimp : MonoBehaviour
{
    //Завершено.
    //TODO:Подправить. Позаимствовано у Unity Slider.
    public Slider.SliderEvent sensativityXEvent;
    public Slider.SliderEvent sensativityYEvent;

    #region Fields
    private Color currentColor; //Действующий цвет до наведения мышки на объект "Pimp".
    private Vector3 centerPoint; //Центральное положение объекта "Pimp".
    private float radius; //Радиус объекта "Pimp".
    private float sensativityX; //Скорость вращения по оси X, на основе положения объекта "Pimp".
    private float sensativityY; //Скорость вращения по оси Y, на основе положения объекта "Pimp"
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        centerPoint = transform.position;
        radius = GetComponent<CircleCollider2D>().radius * 1.4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Mouse Events
    /// <summary>
    /// Срабатывает, при наведении мышки на объект "Pimp". Изменяет цвет.
    /// </summary>
    public void OnMouseEnter()
    {
        currentColor = GetComponent<Image>().color;
        GetComponent<Image>().color = Color.cyan;
    }

    /// <summary>
    /// Срабатывает при выходе мышке из объекта "Pimp". Возвращает цвет на исходный.
    /// </summary>
    public void OnMouseExit()
    {
        GetComponent<Image>().color = currentColor;
    }

    /// <summary>
    /// Срабатывает при перетаскивании объекта "Pimp". Задает скорость вращения связанного SliderEvent объекта.
    /// </summary>
    public void OnMouseDrag()
    {
        Vector3 newPosition = Input.mousePosition;
        newPosition = Vector3.MoveTowards(centerPoint, newPosition, radius);
        transform.position = newPosition;
        sensativityX = transform.position.x - centerPoint.x;
        sensativityY = transform.position.y - centerPoint.y;
        OnSensativityChanged();
    }

    /// <summary>
    /// Срабатывает при отпуске кнопки мыши. Возвращает объект "Pimp" в исходное положение и останавливает вращение объекта.
    /// </summary>
    public void OnMouseUp()
    {
        transform.position = centerPoint;
        sensativityX = 0;
        sensativityY = 0;
        OnSensativityChanged();
    }  

    /// <summary>
    /// Вспомогательный метод события Slider.SliderEvent.
    /// </summary>
    public void OnSensativityChanged()
    {
        if (sensativityYEvent.GetPersistentEventCount() == 0 && sensativityXEvent.GetPersistentEventCount() == 0)
            return;
        sensativityXEvent.Invoke(sensativityX);
        sensativityYEvent.Invoke(sensativityY);
    }
    #endregion

}
