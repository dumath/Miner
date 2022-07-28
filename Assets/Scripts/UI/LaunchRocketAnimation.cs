using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocketAnimation : MonoBehaviour
{
    private RectTransform missileLauncherButton;
    private float leftEdge;
    private bool isReloading = false;
    private float currentMaxWidth;
    private float currentWidth;
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
            //TODO: ƒобавить световую индикацию перезар€дки.
            currentWidth = Mathf.Lerp(missileLauncherButton.rect.width, currentMaxWidth, Time.deltaTime);
            missileLauncherButton.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, leftEdge, currentWidth);
        }
    }

    public void ReloadingOperation(float timeOperation)
    {
        if(isReloading)
        {
            isReloading = !isReloading;
            return;
        }
        isReloading = !isReloading;
        missileLauncherButton.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, leftEdge, 0.0f);
    }
}
