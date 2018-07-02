using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _Transform;
    private Rigidbody _Rigidbody;
    [SerializeField]
    float _HorizontalAxis;
    [SerializeField]
    private float _HSpeed;
    public float _Force;
    [SerializeField]
    private bool _Jump;
    [SerializeField]
    private bool _Grounded;
    private CapsuleCollider2D _PlayerCollider;
    private float _Direction;


    [SerializeField]
    private BulletPool _BulletPool;

    [SerializeField]
    private GameObject _Spawn;


    // Use this for initialization
    void Start()
    {
        _PlayerCollider = gameObject.GetComponent<CapsuleCollider2D>();
        _Transform = gameObject.GetComponent<Transform>();
        _Rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        if (_Transform.rotation.y == 0)
            _Transform.Translate(_HorizontalAxis * _HSpeed * Time.deltaTime, 0, 0);
        if (_Transform.rotation.y > 0)
            _Transform.Translate(_HorizontalAxis * -_HSpeed * Time.deltaTime, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.rotation.y);

        _HorizontalAxis = Input.GetAxisRaw("Horizontal");

        if (_HorizontalAxis > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _Direction = 1;
        }
        else if (_HorizontalAxis < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _Direction = -1;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }



        if (Input.GetAxisRaw("Jump") != 0)
        {
            if (_Jump == false)
            {
                // Call your event function here.
                _Jump = true;
            }
        }
        if (Input.GetAxisRaw("Jump") == 0)
        {
            _Jump = false;
        }

        if (Physics2D.Raycast(transform.position - new Vector3(_PlayerCollider.bounds.extents.x, _PlayerCollider.bounds.extents.y - 0.01f, 0), -Vector3.up, 0.1f) || Physics2D.Raycast(transform.position + new Vector3(_PlayerCollider.bounds.extents.x, -_PlayerCollider.bounds.extents.y + 0.01f, 0), -Vector3.up, 0.1f))
        {
            //Debug.Log("Hit");
            if (_Jump == true)
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.up * _Force;
            }
            _Grounded = true;
        }
        else
        {
            _Grounded = false;
        }

        Vector3 forward = transform.TransformDirection(-Vector3.up) * (0.1f);
        Debug.DrawRay(transform.position - new Vector3(_PlayerCollider.bounds.extents.x, _PlayerCollider.bounds.extents.y - 0.01f, 0), forward, Color.red);
        Debug.DrawRay(transform.position + new Vector3(_PlayerCollider.bounds.extents.x, -_PlayerCollider.bounds.extents.y + 0.01f, 0), forward, Color.red);
    }

    private void Shoot()
    {
        GameObject bullet = _BulletPool.GetBullet();
        if (bullet != null)
        {                 
            bullet.SetActive(true);
            bullet.transform.position = _Spawn.transform.position;
            bullet.GetComponent<Bullet>().SetBulletDirection(_Direction);           
        }
    }

}
