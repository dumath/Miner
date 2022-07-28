using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocketAnimation : MonoBehaviour
{
    //Completed.
    //TODO: �������� � ����������� ���.

    #region Fields
    private RectTransform missileLauncherButton; // ���� ������� � ��������� �����.
    private float leftEdge; // ����� ����� �����.
    private bool isReloading = false; // False - ������ ������ � �������.
    private float currentMaxWidth; // ������������ ������ �����, �������� � ��������� Unity.
    private float currentWidth; // ������� ������ �����. ������ �����������.
    #endregion

    #region Awake, Start, Update, LateUpdate
    // Start is called before the first frame update
    void Start()
    {
        missileLauncherButton = GetComponent<RectTransform>();
        currentMaxWidth = missileLauncherButton.rect.width;
        leftEdge = missileLauncherButton.position.x + missileLauncherButton.rect.xMin;
    }

    // Update is called once per frame
    void Update()
    {
        if(isReloading)
        {
            //TODO: �������� �������� ��������� �����������.
            currentWidth = Mathf.Lerp(missileLauncherButton.rect.width, currentMaxWidth, Time.deltaTime);
            missileLauncherButton.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, leftEdge, currentWidth);
        }
    }
    #endregion

    #region Methods
    // TODO: �������� �������������.
    // TODO: �������� ��������.
    public void ReloadingOperation(float timeOperation)
    {
        if(isReloading)
        {
            isReloading = !isReloading;
            return;
        }
        isReloading = !isReloading;
        missileLauncherButton.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, leftEdge, 40.0f);
    }
    #endregion
}
