using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("Scripts/Asteroid")]
public class Asteroid : MonoBehaviour
{
    #region Fields
    private const float LIFE_TIME = 7200.0f; // Время существования астеройда.
    
    #endregion

    private void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    #region Propertyes
    public static float LifeTime { get => LIFE_TIME; }
    #endregion

}
