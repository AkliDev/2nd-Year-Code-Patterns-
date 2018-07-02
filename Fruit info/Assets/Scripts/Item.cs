using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    [SerializeField]
    GameObject _ToolTip;
    
    string _Name;
    int _Price;
    string _Discription;
    Sprite _Sprite;

    
    private void Start()
    {
        
        _ToolTip = GameObject.Find("ToolTip");
    }
    public void SetItemDefinition(ItemData data)
    {
        _Name = data.Name;
        _Price = data.Price;
        _Discription = data.Definition;
        _Sprite = data.Sprite;
    }

    public void SetImage()
    {
        GetComponent<Image>().sprite = _Sprite;
    }

    public void MouseEnter(BaseEventData data)
    {
        print("in");
        _ToolTip.GetComponent<Tooltip>().SetData(_Name, _Discription, _Price);
        _ToolTip.SetActive(true);
    }

    public void MouseExit(BaseEventData data)
    {
        print("out");
        _ToolTip.SetActive(false);
           
    }
}
