using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public GameObject stone;
    public Transform shootPoint;
    public float shootForce;
    bool playerDetected;
    public float cadency;
    public Animator animator;
    private Vector3 targetPosition;
    GameObject player;
    

    //hud
    int health = 10;
    public Slider sliderHealth;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");
        sliderHealth.value = health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon"))
        {
            health--;
            sliderHealth.value = health;
            if(health <= 0)
            {
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<SphereCollider>().enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
                animator.Play("Death");

                this.enabled = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            StartCoroutine("Attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            StopCoroutine("Attack");
        }
    }

    public IEnumerator Attack()
    {
        while (true)
        {
            targetPosition = new Vector3(player.transform.position.x, 
            this.transform.position.y, player.transform.position.z);

            transform.LookAt(targetPosition);
            yield return new WaitForSeconds(0.2f);
            animator.Play("Attack");
            yield return new WaitForSeconds(cadency);
            
        }
    }

    public void Shoot()
    {
        Instantiate(stone, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
        //Destroy maybe in bullet script

    }
}
/*GameObject.FindGameObjectWithTag("player").transform*/