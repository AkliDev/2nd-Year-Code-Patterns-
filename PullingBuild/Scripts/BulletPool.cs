using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private GameObject _Bullet;
    [SerializeField]
    public Queue<GameObject> _Bullets;
    [SerializeField]
    private float _Amount;

    
    void Start()
    {
        _Bullets = new Queue<GameObject>();
        for (int i = 0; i < _Amount; i++)
        {
            GameObject bullet = Instantiate(_Bullet, new Vector3(), Quaternion.identity);
            bullet.SetActive(false);
            _Bullets.Enqueue(bullet);
            
        }
        
    }

    public void AddToPool(GameObject bullet)
    {
         bullet.SetActive(false);
        _Bullets.Enqueue(bullet);
    }



    public GameObject GetBullet()
    {
        if (_Bullets.Count > 0)
        {
            return _Bullets.Dequeue();

        }
        else return null;
    }
}
