using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scaner : MonoBehaviour
{
    private float radiusScanning = 500.0f;
    private Collider[] targets = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targets = Physics.OverlapSphere(transform.position, radiusScanning);
        
    }


}
