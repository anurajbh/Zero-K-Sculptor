using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSculpting : MonoBehaviour
{
    public Camera cam;
    public PlayerTool playerTool;//artist tool for sculpting
    private float cooldownTimer = 0f;
    private Animator anim;
    void Start()
    {
        cam = Camera.main;
        playerTool = GetComponentInChildren<PlayerTool>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (Input.GetAxisRaw("Fire1")!=0 && cooldownTimer >= playerTool.cooldown)
        {
            UseTool();
            cooldownTimer = 0f;
        }
        /*else
        {
            anim.SetBool("Stab", false);
        }*/
    }

    private void UseTool()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        anim.SetTrigger("active");
        anim.SetFloat("stabTime", playerTool.usageTime);
        if (Physics.Raycast(ray, out hit, playerTool.range))
        {
            if(hit.collider.tag == "Sculptable")//call whatever we want sculptable blocks to do
            {
                GameObject hitObject = hit.collider.gameObject;

                SculptBlock sculptBlock = hitObject.transform.parent.GetComponent<SculptBlock>();

                if (sculptBlock.IsNextInPattern(hitObject))
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
