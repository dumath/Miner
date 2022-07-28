using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpeedSetter : MonoBehaviour, IDragHandler
{
    //Completed.
    //TODO: �������� � ����������� ���.

    #region Fields
    private Image sliderColor; // ������� ��������, ��� ������ ��������� ������ ����.
    private RectTransform slider; // ����� ��������, ��� ��������� ��������, ������.
    public Color MinimalColor; // ���� "SpeedSetter" ��� ����������� ���������.
    public Color MaximalColor; // ���� "SpeedSetter" ��� ������������ ���������.
    private float bottomEdge; // ������ ����� ����� "Slider".
    private float minHeightDrag; // ����������� ������ ����� �� ��� Y.
    private float maxHeightDrag; // ����������� ������ ����� �� ��� Y.
    public float NullSpeedHeight = 60.0f; //TODO: ��������������.
    public UnityEngine.Events.UnityEvent<float> OnValueChange; //����������� ��� ��������� �������� ��������. �������� ������� "Player" �������� ��������.
    #endregion

    #region Awake, Start, Update, LateUpdate
    // Start is called before the first frame update
    void Start()
    {
        /*�������� minHeight � maxHeigth ��������������� �� �������� ������������� �� ������� �����. 
         * �.� ��� ������ ������(� ������ ������).
         * � ������ �� ���������� �����.*/
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
    /// ���������� ������� ����. ��������������. ������e� �����, ����, ��������.
    /// </summary>
    /// <param name="eventData"> ������ �������. </param>
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
