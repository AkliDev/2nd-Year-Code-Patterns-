using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    GameObject _Item;
    [SerializeField]
    Transform _Canvas;

    [SerializeField]
    ItemData[] _ItemData;
    
    // Use this for initialization
    void Start()
    {
        
        
        for (int i = 0; i < _ItemData.Length; i++)
        {
            

           

           
            GameObject clone = Instantiate(_Item) as GameObject;
            clone.GetComponent<Item>().SetItemDefinition(_ItemData[i]);
            clone.GetComponent<Item>().SetImage();
            clone.transform.parent = transform;
        }
        
    }

}
