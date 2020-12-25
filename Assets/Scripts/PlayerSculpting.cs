using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerSculpting : MonoBehaviour
{
    public Camera cam;
    public PlayerTool playerTool;//artist tool for sculpting
    private float cooldownTimer = 0f;
    private Animator anim;
    public Door door;
    public TimeProgression time;
    public AudioClip fail;
    public AudioClip success;
    public GameObject finalText;
    void Awake()
    {
        cam = Camera.main;
        playerTool = GetComponentInChildren<PlayerTool>();
        anim = GetComponent<Animator>();
        time = GameObject.Find("Time").GetComponent<TimeProgression>();
        InvokeRepeating("SlowAnimator", 1f, 1f);
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
                    GetComponent<AudioSource>().PlayOneShot(success);
                    sculptBlock.Sculpt(hitObject);
                }
                else if(sculptBlock.IsLastInPattern(hitObject))
                {
                    //victory
                    sculptBlock.Sculpt(hitObject);
                    finalText.SetActive(true);
                    door.victoryCondition = true;
                }
                else
                {
                    GetComponent<AudioSource>().PlayOneShot(fail);
                }
            }
        }
    }
    void SlowAnimator()
    {
        anim.speed = time.SlowDownGame(anim.speed, 1f);
    }
}
