using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocketAnimation : MonoBehaviour
{
    //Completed.
    //TODO: Привести в упаковочный вид.

    #region Fields
    private RectTransform missileLauncherButton; // Поле доступа к свойствам формы.
    private float leftEdge; // Левая грань формы.
    private bool isReloading = false; // False - Ракета готова к запуску.
    private float currentMaxWidth; // Максимальная ширина формы, задается в редакторе Unity.
    private float currentWidth; // Текущая ширина формы. Момент перезарядки.
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
            //TODO: Добавить световую индикацию перезарядки.
            currentWidth = Mathf.Lerp(missileLauncherButton.rect.width, currentMaxWidth, Time.deltaTime);
            missileLauncherButton.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, leftEdge, currentWidth);
        }
    }
    #endregion

    #region Methods
    // TODO: Заменить идентификатор.
    // TODO: Добавить описание.
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
