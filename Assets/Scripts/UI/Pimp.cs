using UnityEngine;
using UnityEngine.UI;

public class Pimp : MonoBehaviour
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
    /// �����������, ��� ��������� ����� �� ������ "Pimp". �������� ����.
    /// </summary>
    public void OnMouseEnter()
    {
        currentColor = GetComponent<Image>().color;
        GetComponent<Image>().color = Color.cyan;
    }

    /// <summary>
    /// ����������� ��� ������ ����� �� ������� "Pimp". ���������� ���� �� ��������.
    /// </summary>
    public void OnMouseExit()
    {
        GetComponent<Image>().color = currentColor;
    }

    /// <summary>
    /// ����������� ��� �������������� ������� "Pimp". ������ �������� �������� ���������� SliderEvent �������.
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
    /// ����������� ��� ������� ������ ����. ���������� ������ "Pimp" � �������� ��������� � ������������� �������� �������.
    /// </summary>
    public void OnMouseUp()
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
        sensativityXEvent.Invoke(sensativityX);
        sensativityYEvent.Invoke(sensativityY);
    }
    #endregion

}
