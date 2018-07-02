using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScreen : MonoBehaviour
{
    private BulletPool _Pool;


    // Use this for initialization
    void Start()
    {
        _Pool = GameObject.Find("Pool").GetComponent<BulletPool>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            _Pool.AddToPool(other.gameObject);
        }
    }
}
