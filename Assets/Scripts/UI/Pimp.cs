using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pimp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    //���������.
    //TODO:����������. �������������� � Unity Slider.
    public Slider.SliderEvent sensativityXEvent;
    public Slider.SliderEvent sensativityYEvent;

    #region Fields
    private Color currentColor; //����������� ���� �� ��������� ����� �� ������ "Pimp".
    private Vector3 centerPoint; //����������� ��������� ������� "Pimp".
    private float radius; //������ ������� "Pimp".
    private float sensativityX; //�������� �������� �� ��� X, �� ������ ��������� ������� "Pimp".
    private float sensativityY; //�������� �������� �� ��� Y, �� ������ ��������� ������� "Pimp"
    public float Sensativity = 100.0f; //�������� ��������. 
    #endregion

    #region Awake, Start, Update, LateUpdate
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
    #endregion

    #region Mouse Events
    /// <summary>
    /// �����������, ��� ��������� ����� �� ������ "Pimp". �������� ����.
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        currentColor = GetComponent<Image>().color;
        GetComponent<Image>().color = Color.cyan;
    }

    /// <summary>
    /// ����������� ��� ������ ����� �� ������� "Pimp". ���������� ���� �� ��������.
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = currentColor;
    }

    /// <summary>
    /// ����������� ��� �������������� ������� "Pimp". ������ �������� �������� ���������� SliderEvent �������.
    /// </summary>
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = Input.mousePosition;
        newPosition = Vector3.MoveTowards(centerPoint, newPosition, radius);
        transform.position = newPosition;
        sensativityX = transform.position.x - centerPoint.x;
        sensativityY = transform.position.y - centerPoint.y;
        OnSensativityChanged();
    }

    /// <summary>
    /// ����������� ��� ������� ������ ����. ���������� ������ "Pimp" � �������� ��������� � ������������� �������� �������.
    /// </summary>
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.position = centerPoint;
        sensativityX = 0;
        sensativityY = 0;
        OnSensativityChanged();
    }

    /// <summary>
    /// ��������������� ����� ������� Slider.SliderEvent.
    /// </summary>
    public void OnSensativityChanged()
    {
        if (sensativityYEvent.GetPersistentEventCount() == 0 && sensativityXEvent.GetPersistentEventCount() == 0)
            return;
        sensativityXEvent.Invoke(sensativityX / Sensativity);
        sensativityYEvent.Invoke(sensativityY / Sensativity);
    }

    /// <summary>
    /// ������ ����������.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    #endregion

}
