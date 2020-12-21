using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
    public int id;

    private Color startcolor;
    void OnMouseEnter()
    {
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = new Color(240/255, 230/255, 140/255);
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }
}
