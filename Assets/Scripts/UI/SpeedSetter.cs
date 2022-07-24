using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpeedSetter : MonoBehaviour, IDragHandler
{
    //Completed.
    //TODO: Привести в упаковочный вид.

    #region Fields
    private RectTransform slider; // Форма слайдера, при изменении скорости, размер.
    private Image sliderColor; // Палитра скорости, при разных значениях меняет цвет.
    public UnityEngine.Events.UnityEvent<float> OnValueChange; //Срабатывает при изменение слайдера скорости. Передает объекту "Player" значение сокрости.
    private float bottomEdge; // Нижняя грань формы "Slider".
    private float minHeightDrag; // Минимальный размер формы по оси Y.
    private float maxHeightDrag; // Масимальный размер формы по оси Y.
    public Color MinimalColor; // Цвет "SpeedSetter" при минимальных значениях.
    public Color MaximalColor; // Цвет "SpeedSetter" при максимальных значениях.
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
        return currentColor;
    }

    /// <summary>
    /// Обработчик события мыши. Перетаскивание. Изменяeт форму, скорость.
    /// </summary>
    /// <param name="eventData"> Данные события. </param>
    public void OnDrag(PointerEventData eventData)
    {
        // TODO: Убрать магические числа.
        float posYPalitra = (transform.InverseTransformDirection(Input.mousePosition).y - 200)/100;
        sliderColor.color = changeColor(sliderColor.color, posYPalitra);
        float h = Input.mousePosition.y;
        if (h > minHeightDrag && h < maxHeightDrag)
            slider.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, bottomEdge, h);
        OnValueChange.Invoke(h - 60); ;
    }
    #endregion
}
