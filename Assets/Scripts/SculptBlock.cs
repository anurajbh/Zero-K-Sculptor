using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SculptBlock : MonoBehaviour
{
    // Denotes the current index in the pattern.
    // The value will be incremented when the player successfully clicks
    // on the shard mesh in the pattern.
    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.tag = "Sculptable";
            child.AddComponent<MeshCollider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isNextInPattern(GameObject hitObject)
    {
        Shard shard = hitObject.GetComponent<Shard>();
        Debug.Log(shard.id + " " + currentIndex);
        return shard.id == currentIndex;
    }

    public void Sculpt(GameObject hitObject)
    {
        Destroy(hitObject);
        currentIndex++;
    }
}
