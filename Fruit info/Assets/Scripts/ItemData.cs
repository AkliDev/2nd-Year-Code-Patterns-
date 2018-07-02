using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "RPG/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    string _Name;
    public string Name
    {
        get { return _Name; }
    }
    [SerializeField]
    string _Definition;
    public string Definition
    {
        get { return _Definition; }
    }
    [SerializeField]
    int _Price;
    public int Price
    {
        get { return _Price; }
    }
    [SerializeField]
    private Sprite _Sprite;
    public Sprite Sprite
    {
        get { return _Sprite; }
    }


}
