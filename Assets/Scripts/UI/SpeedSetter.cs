using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpeedSetter : MonoBehaviour, IDragHandler
{
    //Completed.
    //TODO: Привести в упаковочный вид.

    #region Fields
    private Image sliderColor; // Палитра скорости, при разных значениях меняет цвет.
    private RectTransform slider; // Форма слайдера, при изменении скорости, размер.
    public Color MinimalColor; // Цвет "SpeedSetter" при минимальных значениях.
    public Color MaximalColor; // Цвет "SpeedSetter" при максимальных значениях.
    private float bottomEdge; // Нижняя грань формы "Slider".
    private float minHeightDrag; // Минимальный размер формы по оси Y.
    private float maxHeightDrag; // Масимальный размер формы по оси Y.
    public float NullSpeedHeight = 60.0f; //TODO: Масштабировать.
    public UnityEngine.Events.UnityEvent<float> OnValueChange; //Срабатывает при изменение слайдера скорости. Передает объекту "Player" значение сокрости.
    #endregion

    #region Awake, Start, Update, LateUpdate
    // Start is called before the first frame update
    void Start()
    {
        /*Значения minHeight и maxHeigth инициализирутся от размеров установленных до запуска сцены. 
         * Т.е его полная высота(в данном случае).
         * И больше не изменяются кодом.*/
        sliderColor = GetComponent<Image>();
        slider = GetComponent<RectTransform>();
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
    /// Обработчик события мыши. Перетаскивание. Изменяeт форму, цвет, скорость.
    /// </summary>
    /// <param name="eventData"> Данные события. </param>
    public void OnDrag(PointerEventData eventData)
    {
        float offset = Mathf.InverseLerp(minHeightDrag, maxHeightDrag, eventData.position.y);
        sliderColor.color = Color.Lerp(MinimalColor, MaximalColor, offset);
        float currentMousePositionY = eventData.position.y;
        if (currentMousePositionY > minHeightDrag && currentMousePositionY < maxHeightDrag)
        {
            slider.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, bottomEdge, currentMousePositionY);
            OnValueChange.Invoke(currentMousePositionY - NullSpeedHeight);
        }
    }
    #endregion
}
