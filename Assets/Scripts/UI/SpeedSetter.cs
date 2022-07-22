using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpeedSetter : MonoBehaviour, IDragHandler
{
    //Completed.
    //TODO: ������ SliderEvent
    //TODO: �������� � ����������� ���.

    #region Fields
    private RectTransform slider; // ����� ��������, ��� ��������� ��������, �������� �����(������).
    private Image sliderColor; // ������� ��������, ��� ������� ���������, ������ ����.
    public Slider.SliderEvent OnValueChange; // �������������� � Slider. ��� �������� �������� ������� ��������, ������������� �������������.
    private float bottomEdge; // ������ ����� ����� "Slider".
    private float minHeightDrag; // ����������� ������ ����� �� ��� Y.
    private float maxHeightDrag; // ����������� ������ ����� �� ��� Y.
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
    /// ���������� ��� ��������� ��������. ������ ���� �����. 
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
    /// ���������� ������� ����. ��������������. ������e� �����, ��������.
    /// </summary>
    /// <param name="eventData"> ������ �������. </param>
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
