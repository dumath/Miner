using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Pimp : MonoBehaviour
{
    private Color currentColor;
    private Vector3 centerPoint;
    private float radius;
    private float distance;
    private float _speed;
    public static float sensativityX; //DEBUG
    public static float sensativityY; //DEBUG
    

    // Start is called before the first frame update
    void Start()
    {
        centerPoint = transform.position;
        _speed = Vector3.Distance(centerPoint, transform.position);
        radius = GetComponent<CircleCollider2D>().radius * 1.4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    #region Mouse Events
    public void OnMouseEnter()
    {
        currentColor = GetComponent<Image>().color;
        GetComponent<Image>().color = Color.cyan;
    }

    public void OnMouseExit()
    {
        GetComponent<Image>().color = currentColor;
    }

    public void OnMouseDrag()
    {
        Vector3 newPosition = Input.mousePosition;
        newPosition = Vector3.MoveTowards(centerPoint, newPosition, radius);
        transform.position = newPosition;
        sensativityX = transform.position.x - centerPoint.x;
        sensativityY = transform.position.y - centerPoint.y;
    }

    public void OnMouseUp()
    {
        transform.position = centerPoint;
        sensativityX = 0;
        sensativityY = 0;
    }  
    #endregion

}
