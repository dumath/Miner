using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaunchRocketButton : MonoBehaviour, IPointerClickHandler
{
    //Completed.
    //TODO: Привести в упаковочный вид.

    #region Fields
    public int fullClip = 4; // Полностью заряженная обойма.
    public int currentMissilesInClip; // Количество ракет, оставшееся в обойме.
    public float reloadTime = 10.0f; // Время перезарядки обоймы.
    public float preparationTime = 5.0f; // Время подготовки ракеты после выпуска(обойма не пустая).
    private Image clipSkin; // Изображение обоймы в UI.
    public Color emptyClipColor; // Цвет пустой обоймы.
    public Color fullClipColor; // Цвет полной обоймы.
    [SerializeField] private UnityEngine.Events.UnityEvent LaunchEvent; // Связанное событие с Click.
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
    /// Метод запускает ракету, если обойма не пустая, при щелчке мыши на объекте "Clip" в UI.
    /// </summary>
    /// <param name="eventData"> Данные события мыши. </param>
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
    /// Метод запускает Анимацию(script.cs) подготовки/перезаяодки ракеты.
    /// </summary>
    /// <param name="operationTime"> Временной интервал подготовки или перезарядки ракеты. </param>
    /// <returns> Итератор короутины. </returns>
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


