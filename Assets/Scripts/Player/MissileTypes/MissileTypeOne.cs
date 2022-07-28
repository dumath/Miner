using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTypeOne : MonoBehaviour
{
    /*DEBUG все внутренности будут заменены. */
    [SerializeField] private ParticleSystem engine;
    private bool start = false;
    public float Speed = 0.1f;
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
            if (Speed < 400.0f)
            {
                Speed += 0.2f;
            }
                
        }
    }

    public void Launch(float shipSpeed)
    {
        start = !start;
        Speed += shipSpeed;
    }

}
