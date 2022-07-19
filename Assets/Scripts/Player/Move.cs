using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0,0, -speed);
        movement = transform.TransformDirection(movement);
        movement *= Time.deltaTime;
        GetComponent<CharacterController>().Move(movement);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
