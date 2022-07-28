using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clip : MonoBehaviour
{
    //DEBUG
    [SerializeField] private GameObject firstRocket;
    [SerializeField] private GameObject secondRocket;
    [SerializeField] private GameObject thirdRocket;
    [SerializeField] private GameObject fourthRocket;
    private Vector3[] rocketsClip; //Будет ли грейдиться ?
    private int currentIndex;
    private UnityEngine.Events.UnityEvent<float> LaunchEvent;
    private float shipSpeed = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        LaunchEvent = new UnityEngine.Events.UnityEvent<float>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launching()
    {
        GameObject newR = Instantiate(firstRocket, firstRocket.transform.position, firstRocket.transform.rotation);
        LaunchEvent.AddListener(newR.GetComponent<Rocket>().Launch);
        LaunchEvent.Invoke(shipSpeed);
        StartCoroutine(DestoyMissile(newR));
    }

    private IEnumerator DestoyMissile(GameObject missile)
    {
        yield return new WaitForSeconds(10.0f);
        LaunchEvent.RemoveAllListeners();
        Destroy(missile);
    }

    public void ShipSpeed(float speed)
    {
        shipSpeed = speed;
    }    
}
