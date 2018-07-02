using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{

    
    public GameObject[] _Colliders;
    public GameObject[] _Triggers;


    void Start()
    {
        
        CreateColliders();
        CreateTriggers();
    }

    
    void Update()
    {
       
    }

    private void CreateTriggers()
    {
        _Triggers = new GameObject[4];

        for (int i = 0; i < _Colliders.Length; i++)

        {
            _Triggers[i] = new GameObject();
            _Triggers[i].AddComponent<BoxCollider2D>();
            _Triggers[i].transform.parent = transform;
            _Triggers[i].AddComponent<OutOfScreen>();
            _Triggers[i].GetComponent<BoxCollider2D>().isTrigger = true;
           




        }
        _Triggers[0].name = "Top Collider";
        _Triggers[1].name = "Right Collider";
        _Triggers[2].name = "Bottem Collider";
        _Triggers[3].name = "Left Collider";

        PositionColliders(_Triggers);
    }


    private void CreateColliders()
    {
        _Colliders = new GameObject[4];

        for (int i = 0; i < _Colliders.Length; i++)

        {
            _Colliders[i] = new GameObject();
            _Colliders[i].AddComponent<BoxCollider2D>();
            _Colliders[i].transform.parent = transform;
            





        }
        _Colliders[0].name = "Top Collider";
        _Colliders[1].name = "Right Collider";
        _Colliders[2].name = "Bottem Collider";
        _Colliders[3].name = "Left Collider";

        PositionColliders(_Colliders);
    }

    private void PositionColliders(GameObject[] bounds)
    {
       Vector3 pos = transform.position;
        Vector2 screenSize = new Vector2();
        float colDepth = 4f;
        float zDepth = 0;

        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)));
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)));

        bounds[0].transform.localScale = new Vector3(screenSize.x, colDepth, colDepth);
        bounds[0].transform.position = new Vector3(transform.position.x, transform.position.y + (screenSize.y * 0.5f) + (bounds[0].transform.localScale.y * 0.5f), zDepth);

        bounds[1].transform.localScale = new Vector3(colDepth, screenSize.y, colDepth);
        bounds[1].transform.position = new Vector3(transform.position.x + (screenSize.x * 0.5f) + (bounds[1].transform.localScale.x * 0.5f), transform.position.y, zDepth);

        bounds[2].transform.localScale = new Vector3(screenSize.x, colDepth, colDepth);
        bounds[2].transform.position = new Vector3(transform.position.x, transform.position.y - (screenSize.y * 0.5f) - (bounds[2].transform.localScale.y * 0.5f), zDepth);

        bounds[3].transform.localScale = new Vector3(colDepth, screenSize.y, colDepth);
        bounds[3].transform.position = new Vector3(transform.position.x - (screenSize.x * 0.5f) - (bounds[3].transform.localScale.x * 0.5f), transform.position.y, zDepth);

    }
}
