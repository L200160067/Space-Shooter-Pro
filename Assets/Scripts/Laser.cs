using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // speed 8
    [SerializeField]
    private float speed = 8f;
    void Update()
    {
        // gerakan laser ke atas
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Hancurkan Laser
        if (transform.position.y >= 8f)
        {
            Destroy(this.gameObject);
        }
    }
}
