using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
  
    void Update()
    {      
            transform.position = GetMousePosToWorld();
    }

    public void SetData(string name,string description, int price)
    {
        transform.Find("Name").GetComponent<Text>().text = name;
       transform.Find("Description").GetComponent<Text>().text = description;
   transform.Find("Price").GetComponent<Text>().text = price.ToString();
    }
    public void OnGUI()
    {

        Vector3 pos = Input.mousePosition;
        pos.z = 0;
        pos = Camera.main.ScreenToWorldPoint(pos);
        Ray ray = new Ray(pos, Vector3.down);

    }

    public Vector3 GetMousePosToWorld()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 0;
        pos = Camera.main.ScreenToWorldPoint(pos);
        Ray ray = new Ray(pos, Vector3.down);

        pos = new Vector3(pos.x, pos.y, 0);

        return pos;

    }
}
