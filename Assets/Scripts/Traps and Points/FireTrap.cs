using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    private bool triggered;
    private bool active;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            if(!triggered)
            {
                StartCoroutine(ActiveFireTrap());
            }

            if(active)
            {
                gameObject.tag = "Trap";
            }
            else
            {
                gameObject.tag = "Untagged";
            }
        }
    }

    private IEnumerator ActiveFireTrap()
    {
        triggered = true;
        spriteRenderer.color = Color.red;


        yield return new WaitForSeconds(activationDelay);
        active = true;
        spriteRenderer.color = Color.white;
        animator.SetBool("activated", true);


        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        animator.SetBool("activated", false);
    }
}
