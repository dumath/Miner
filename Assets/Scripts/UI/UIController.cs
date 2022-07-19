using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject playerShip;
    [SerializeField] private Text spaceCoord;
    // Start is called before the first frame update
    void Start()
    {
        spaceCoord.text = playerShip.transform.position.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        spaceCoord.text = playerShip.transform.position.ToString();
    }
}
