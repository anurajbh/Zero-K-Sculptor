using UnityEngine;
using System.Collections;
usingUnityEngine.SceneManagement;

public class AttackTrigger :
    MonoBehavior
{
    Animator anim;

void Start()
{
    anim = gameObject.GetComponent<Animator>();
}
void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        anim.SetTrigger("Active");
    }
}
    void OnMouseDown()
    {

    }
}
