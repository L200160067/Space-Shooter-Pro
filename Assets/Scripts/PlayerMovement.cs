using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 3.5f;

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _triplelaserPrefab;
    
    [SerializeField]
    private float _fireRate = 0.15f;
    [SerializeField]
    private float _canFire = -1f;

    [SerializeField]
    private float _lives = 3;
    private SpawnManager _spawnManager;

    [SerializeField]
    private GameObject _laserContainer;

    [SerializeField]
    private bool _isTripleShotActive = false;

    

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is Null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        //spawn laser
            _canFire = Time.time + _fireRate;

        if ( _isTripleShotActive == true )
        {
            GameObject newLaser = Instantiate(_triplelaserPrefab, transform.position, Quaternion.identity);
            newLaser.transform.parent = _laserContainer.transform;
        }
        else 
        {
            GameObject newLaser = Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
            newLaser.transform.parent = _laserContainer.transform;
        }
           
    }

    public void Damage()
    {
        _lives--;

        //komunikasikan dengan spawn manager
        //jika player mati spawn berhenti
        if (_lives < 1)
        {
           _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
}
