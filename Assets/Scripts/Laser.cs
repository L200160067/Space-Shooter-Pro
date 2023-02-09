using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // speed 8
    private float speed = 8f;
    void Update()
    {
        // gerakan laser ke atas
        //Vector3 direction = new Vector3(0, 1, 0);
        //transform.Translate(direction * speed * Time.deltaTime);

        //OR
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y >= 8f)
        {
            Destroy(this.gameObject);
        }
    }
}
