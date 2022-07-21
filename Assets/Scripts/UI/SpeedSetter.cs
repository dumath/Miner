using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpeedSetter : MonoBehaviour, IDragHandler
{
    private RectTransform slider;
    private Image sliderColor;
    public Slider.SliderEvent OnValueChange;
    private float bottomEdge;
    private float minHeightDrag;
    private float maxHeightDrag;
    

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<RectTransform>();
        sliderColor = GetComponent<Image>();
        bottomEdge = slider.position.y + slider.rect.yMin;
        minHeightDrag = bottomEdge * 2;
        maxHeightDrag = slider.rect.height;
        Debug.Log(minHeightDrag);
        Debug.Log(maxHeightDrag);
        slider.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, bottomEdge, minHeightDrag);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   

    private Color changeColor(Color currentColor, float offSet)
    {
        currentColor.g = -offSet;
        currentColor.r = offSet*2;
        return currentColor;
    }

    public void OnDrag(PointerEventData eventData)
    {
        float posYPalitra = (transform.InverseTransformDirection(Input.mousePosition).y - 200)/100;
        sliderColor.color = changeColor(sliderColor.color, posYPalitra);
        float h = Input.mousePosition.y;
        if (h > minHeightDrag && h < maxHeightDrag)
            slider.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, bottomEdge, h);
        OnValueChange.Invoke(h - 60); ;
    }
}
