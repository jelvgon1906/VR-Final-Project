using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    


    //hud
    int health = 10;
    [SerializeField]Slider sliderHealth;

    private void Awake()
    {
        sliderHealth.value = health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            health--;
            sliderHealth.value = health;
            if (health <= 0)
            {
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<SphereCollider>().enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
                /*animator.Play("Death");*/

                this.enabled = false;
            }
        }
    }
}
