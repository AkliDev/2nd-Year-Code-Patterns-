using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    right,
    leftl

};



public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _Speed;
    private Direction _Direction;
    private Transform _Transform;
    private MeshRenderer _Renderer;
    


    void Start()
    {
        _Transform = GetComponent<Transform>();
        _Renderer = GetComponent<MeshRenderer>();
       

}
    private void FixedUpdate()
    {
        _Transform.Translate(_Speed, 0, 0);
    }

    void Update()
    {
        
    }


    public void SetBulletDirection(float direction)
    {
        if (direction > 0)
        {
            _Speed = 0.2f;
        }
        if (direction < 0)
        {
            _Speed = -0.2f;
        }
        //print(direction);
    }
}
