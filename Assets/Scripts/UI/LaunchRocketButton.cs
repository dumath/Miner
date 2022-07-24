using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaunchRocketButton : MonoBehaviour , IPointerClickHandler
{
    public int clip = 3;
    private const float PALITRA = 1.0f;
    public float ReloadTime = 5.0f;
    private Image clipSkin;
    public Color emptyClip;
    public Color fullClip;
    public RocketLauncherEvent RCE;

    // Start is called before the first frame update
    void Start()
    {
        clipSkin = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(clip == 0)
        {
            clipSkin.color = fullClip;
            clip = 3;
            StartCoroutine(reloading(ReloadTime));
        }
        else
        {
            float offset = PALITRA / clip;
            clip--;
            RCE.Invoke(1.0f);
            clipSkin.color = Color.Lerp(fullClip, emptyClip, offset);
        }
    }

    private IEnumerator reloading(float time)
    {
        yield return new WaitForSeconds(time);
    }

    //TODO:Вернуть к полю.
    [System.Serializable]
    public class RocketLauncherEvent : UnityEngine.Events.UnityEvent<float>
    {

    }
}


