using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    /*DEBUG все внутренности будут заменены. */
    private bool start = false;
    public float Speed = 0.1f;
    [SerializeField] private ParticleSystem engine;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Убрать Debug, магические числа.
        if (start)
        {
            transform.Translate(0.0f, Speed * Time.deltaTime, 0.0f, Space.Self);
            if (Speed < 200.0f)
                Speed += 0.2f;
        }
    }

    public void Launch(float shipSpeed)
    {
        start = !start;
        Speed += shipSpeed;
    }

}
