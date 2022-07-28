using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaunchRocketButton : MonoBehaviour, IPointerClickHandler
{
    //Completed.
    //TODO: �������� � ����������� ���.

    #region Fields
    public int fullClip = 4; // ��������� ���������� ������.
    public int currentMissilesInClip; // ���������� �����, ���������� � ������.
    public float reloadTime = 10.0f; // ����� ����������� ������.
    public float preparationTime = 5.0f; // ����� ���������� ������ ����� �������(������ �� ������).
    private Image clipSkin; // ����������� ������ � UI.
    public Color emptyClipColor; // ���� ������ ������.
    public Color fullClipColor; // ���� ������ ������.
    [SerializeField] private UnityEngine.Events.UnityEvent LaunchEvent; // ��������� ������� � Click.
    #endregion

    #region Awake, Start, Update, LateUpdate
    // Start is called before the first frame update
    void Start()
    {
        currentMissilesInClip = fullClip;
        clipSkin = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Methods
    /// <summary>
    /// ����� ��������� ������, ���� ������ �� ������, ��� ������ ���� �� ������� "Clip" � UI.
    /// </summary>
    /// <param name="eventData"> ������ ������� ����. </param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentMissilesInClip != 0)
        {
            LaunchEvent.Invoke();
            clipSkin.color = Color.Lerp(fullClipColor, emptyClipColor, 1.0f / currentMissilesInClip);
            StartCoroutine(Launch(preparationTime));
            currentMissilesInClip--;
        }
        else
        {
            clipSkin.color = fullClipColor;
            StartCoroutine(Launch(reloadTime));
            currentMissilesInClip = fullClip;
        }
    }

    /// <summary>
    /// ����� ��������� ��������(script.cs) ����������/����������� ������.
    /// </summary>
    /// <param name="operationTime"> ��������� �������� ���������� ��� ����������� ������. </param>
    /// <returns> �������� ���������. </returns>
    private IEnumerator Launch(float operationTime)
    {
        GetComponent<LaunchRocketAnimation>().ReloadingOperation(operationTime);
        enabled = !enabled;
        yield return new WaitForSeconds(operationTime);
        enabled = !enabled;
        GetComponent<LaunchRocketAnimation>().ReloadingOperation(operationTime);
    }
    #endregion
}


