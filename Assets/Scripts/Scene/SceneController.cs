using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    /* ������� ��������� 1.0f ����� 1.0 ����. */

    [SerializeField] private GameObject[] asteroidsPrefab;


    private List<GameObject> points;

    // Start is called before the first frame update
    void Start()
    {
        AsteroidsCreate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Asteroids Operation
    /// <summary>
    /// ������ �������� � ����������. PS: ��� ������, �������� �� ���������� �������, �������� ������.
    /// </summary>
    public void AsteroidsCreate()
    {
        foreach (GameObject o in asteroidsPrefab)
        {
            StartCoroutine(AsteroidLiving(Instantiate(o)));
        }
    }

    /// <summary>
    /// ����� ��������� ��������� � ������������.
    /// </summary>
    /// <param name="asteroid"> �������������� </param>
    public void SetAsteroidInSpace(GameObject asteroid)
    {
        Transform transformAsteroid = asteroid.GetComponent<Transform>();
        //������ �������� � ��������� ����� � ������������.
        float x = Random.Range(-500.0f, 500.0f);
        float y = Random.Range(-500.0f, 500.0f);
        float z = Random.Range(-500.0f, 500.0f);
        Vector3 newPosition = new Vector3(x, y, z);
        transformAsteroid.position = newPosition;

        //������ ������ ���������
        x = Random.Range(40.0f, 60.0f);
        y = Random.Range(40.0f, 60.0f);
        z = Random.Range(40.0f, 60.0f);
        Vector3 newScale = new Vector3(x, y, z);
        transformAsteroid.localScale = newScale;
    }

    /// <summary>
    /// ��������� ����� ������������� ���������.
    /// </summary>
    /// <param name="asteroid"> �������� � ����������</param>
    /// <returns></returns>
    public IEnumerator AsteroidLiving(GameObject asteroid)
    {
        SetAsteroidInSpace(asteroid);
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(Asteroid.LifeTime);
        yield return wait;
        Destroy(asteroid);
    }
    #endregion
    
   
}
