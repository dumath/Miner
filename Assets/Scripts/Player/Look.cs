using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    private float minVer = -45.0f;
    private float maxVer = 45.0f;
    private float rotationX = 0;
    private float sensativityX = 0;
    private float sensativityY = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        rotationX -= sensativityY/100;
        rotationX = Mathf.Clamp(rotationX, minVer, maxVer);
        float delta = sensativityX/100;
        float rotationY = transform.localEulerAngles.y + delta;
        Vector3 newRotation = new Vector3(rotationX, rotationY, 0);
        transform.localEulerAngles = newRotation;
    }

    public void LookSensativityX(float x)
    {
        this.sensativityX = x;
    }

    public void LookSensativityY(float y)
    {
        this.sensativityY = y;
    }
}
