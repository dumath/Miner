using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    private float sensativity = 10.0f; //TODO: Заменить на значение стика.
    private float minVer = -45.0f;
    private float maxVer = 45.0f;
    private float rotationX = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnMouseDrag(float speed)
    {
        rotationX -= Input.GetAxis("Mouse Y") * sensativity;
        rotationX = Mathf.Clamp(rotationX, minVer, maxVer);
        float delta = Input.GetAxis("Mouse X") * sensativity;
        float rotationY = transform.localEulerAngles.y + delta;
        Vector3 newRotation = new Vector3(rotationX, rotationY, 0);
        transform.localEulerAngles = newRotation;
    }
}
