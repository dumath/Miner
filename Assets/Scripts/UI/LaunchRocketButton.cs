using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaunchRocketButton : MonoBehaviour, IPointerClickHandler
{
    //DEBUG
    public int fullClip = 4; // Полная обойма.
    public int currentRocketsInClip; // Сколько осталось в обойме.
    public float reloadTime = 10.0f; // Время перезарядки.
    public float preparationTime = 5.0f; // Время подготовки ракеты после выпуска.
    private Image clipSkin; //Изображение обоймы в UI.
    public Color emptyClipColor; // Цвет пустой обоймы.
    public Color fullClipColor; // Цвет полной обоймы.
    [SerializeField] private UnityEngine.Events.UnityEvent LaunchEvent; // Связанное событие с Click.

    // Start is called before the first frame update
    void Start()
    {
        currentRocketsInClip = fullClip;
        clipSkin = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentRocketsInClip != 0)
        {
            LaunchEvent.Invoke();
            clipSkin.color = Color.Lerp(fullClipColor, emptyClipColor, 1.0f / currentRocketsInClip);
            StartCoroutine(Launch(preparationTime));
            currentRocketsInClip--;
        }
        else
        {
            clipSkin.color = fullClipColor;
            StartCoroutine(Launch(reloadTime));
            currentRocketsInClip = fullClip;
        }
    }


    private IEnumerator Launch(float operationTime)
    {
        GetComponent<LaunchRocketAnimation>().ReloadingOperation(operationTime);
        enabled = !enabled;
        yield return new WaitForSeconds(operationTime);
        enabled = !enabled;
        GetComponent<LaunchRocketAnimation>().ReloadingOperation(operationTime);
    }
}


