using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpeedSetter : MonoBehaviour, IDragHandler
{
    //Completed.
    //TODO: Убрать SliderEvent
    //TODO: Привести в упаковочный вид.

    #region Fields
    private RectTransform slider; // Форма слайдера, при изменении скорости, меняется форма(размер).
    private Image sliderColor; // Палитра скорости, при высоких значениях, меняет цвет.
    public Slider.SliderEvent OnValueChange; // Позаимствовано у Slider. Для отправки значения текущей скорости, установленной пользователем.
    private float bottomEdge; // Нижняя грань формы "Slider".
    private float minHeightDrag; // Минимальный размер формы по оси Y.
    private float maxHeightDrag; // Масимальный размер формы по оси Y.
    public Color MinimalColor;
    public Color MaximalColor;
    #endregion

    #region Awake, Start, Update, LateUpdate
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<RectTransform>();
        sliderColor = GetComponent<Image>();
        bottomEdge = slider.position.y + slider.rect.yMin;
        minHeightDrag = bottomEdge * 2;
        maxHeightDrag = slider.rect.height;
        Debug.Log(minHeightDrag);
        Debug.Log(maxHeightDrag);
        slider.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, bottomEdge, minHeightDrag);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    #endregion

    #region Methods
    /// <summary>
    /// Вызывается при изменении скорости. Меняет цвет формы. 
    /// </summary>
    /// <param name="currentColor"></param>
    /// <param name="offSet"></param>
    /// <returns></returns>
    private Color changeColor(Color currentColor, float offSet)
    {
        currentColor = Color.Lerp(MinimalColor, MaximalColor, offSet);
        //currentColor.g = -offSet;
        //currentColor.r = offSet*2;
        return currentColor;
    }

    /// <summary>
    /// Обработчик события мыши. Перетаскивание. Изменяeт форму, скорость.
    /// </summary>
    /// <param name="eventData"> Данные события. </param>
    public void OnDrag(PointerEventData eventData)
    {
        float posYPalitra = (transform.InverseTransformDirection(Input.mousePosition).y - 200)/100;
        sliderColor.color = changeColor(sliderColor.color, posYPalitra);
        float h = Input.mousePosition.y;
        if (h > minHeightDrag && h < maxHeightDrag)
            slider.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, bottomEdge, h);
        OnValueChange.Invoke(h - 60); ;
    }
    #endregion
}
