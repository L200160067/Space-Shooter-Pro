using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //damage player
            PlayerMovement player = other.transform.GetComponent<PlayerMovement>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }
    }

}