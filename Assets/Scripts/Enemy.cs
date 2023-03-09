using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -5f)
        {
            transform.position = new Vector3(Random.Range(-8.0f, 8.0f), 7f, 0);
            //Destroy(this.gameObject);
            //atau 
            //float randomX = Random.Range(-8.0f, 8.0f);
            //transform.position = new Vector3(randomX, 7f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if other adalah player
        // damage the player
        //destroy us
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

        //if other is laser
        //laser
        //destroy us
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
