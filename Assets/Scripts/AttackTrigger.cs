using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AttackTrigger : MonoBehaviour
{
    Animator anim;

void Start()
{
    anim = gameObject.GetComponent<Animator>();
}
/*void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        anim.SetTrigger("Active");
    }
}*/
}
