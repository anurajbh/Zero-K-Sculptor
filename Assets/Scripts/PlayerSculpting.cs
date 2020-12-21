using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSculpting : MonoBehaviour
{
    public Camera cam;
    public PlayerTool playerTool;//artist tool for sculpting
    private float cooldownTimer = 0f;
    void Start()
    {
        cam = Camera.main;
        playerTool = GetComponentInChildren<PlayerTool>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (Input.GetAxisRaw("Fire1")!=0 && cooldownTimer >= playerTool.cooldown)
        //if (Input.GetAxisRaw("Fire1") != 0)
        {
            cooldownTimer = 0f;
            UseTool();
        }
    }

    private void UseTool()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, playerTool.range))
        {
            if(hit.collider.tag == "Sculptable")//call whatever we want sculptable blocks to do
            {
                GameObject hitObject = hit.collider.gameObject;

                SculptBlock sculptBlock = hitObject.transform.parent.GetComponent<SculptBlock>();

                if (sculptBlock.isNextInPattern(hitObject))
                {
                    sculptBlock.Sculpt(hitObject);
                } else
                {
                    // show ice shards effect
                }
            }
        }
    }
}
