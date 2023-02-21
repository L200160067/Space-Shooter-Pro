//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpawnManager : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject _enemyPrefab;
//    [SerializeField]
//    private GameObject _enemyContainer;
//    [SerializeField]
//    private bool _stopSpawning = false;
//    // Start is called before the first frame update
//    void Start()
//    {
//        StartCoroutine(SpawnRoutine());
//    }

//    // spawn enemy every 5 seconds
//    //create a coroutine of type IEnumerator -- Yield Event
//    //while loop

//    IEnumerator SpawnRoutine()
//    {
//        while (_stopSpawning == false)
//        {
//            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
//            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
//            newEnemy.transform.parent = _enemyContainer.transform;
//            yield return new WaitForSeconds(5.0f);
//        }
//        //while loop (infinite loop)
//        // instantiate enemy prefab
//        //yield wait for 5 second

//        //
//    }

//    public void OnPlayerDeath()
//    {
//        _stopSpawning = true;
//        if (_stopSpawning == true)
//        {
//            Destroy(_enemyPrefab.gameObject);
//        }

//    }
//}//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SpawnManager : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject _enemyPrefab;
//    [SerializeField]
//    private GameObject _enemyContainer;
//    [SerializeField]
//    private bool _stopSpawning = false;
//    // Start is called before the first frame update
//    void Start()
//    {
//        StartCoroutine(SpawnRoutine());
//    }

//    // spawn enemy every 5 seconds
//    //create a coroutine of type IEnumerator -- Yield Event
//    //while loop

//    IEnumerator SpawnRoutine()
//    {
//        while (_stopSpawning == false)
//        {
//            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
//            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
//            newEnemy.transform.parent = _enemyContainer.transform;
//            yield return new WaitForSeconds(5.0f);
//        }
//        //while loop (infinite loop)
//        // instantiate enemy prefab
//        //yield wait for 5 second

//        //
//    }

//    public void OnPlayerDeath()
//    {
//        _stopSpawning = true;
//        if (_stopSpawning == true)
//        {
//            Destroy(_enemyPrefab.gameObject);
//        }

//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private bool _stopSpawning = false;

    private const float SpawnTime = 5.0f;

    // Cache the transform of the enemy container for faster access
    private Transform _enemyContainerTransform;

    void Start()
    {
        _enemyContainerTransform = _enemyContainer.transform;
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity, _enemyContainerTransform);
            yield return new WaitForSeconds(SpawnTime);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
        // Check if there are any enemies left in the container and destroy them
        foreach (Transform child in _enemyContainerTransform)
        {
            Destroy(child.gameObject);
        }
    }
}
