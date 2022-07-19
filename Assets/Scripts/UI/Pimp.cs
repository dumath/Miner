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

    

    [Range(0f, 40f)]
    public float sensativity = 0;

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
        sensativity = Vector3.Distance(centerPoint, newPosition);
    }

    public void OnMouseUp()
    {
        transform.position = centerPoint;
        sensativity = Vector3.Distance(centerPoint, transform.position);
    }
    #endregion

}
