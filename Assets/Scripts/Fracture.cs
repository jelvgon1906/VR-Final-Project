using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fracture : MonoBehaviour
{
    [Tooltip("\"Fractured\" is the object that this will break into")]
    public GameObject fractured;
    [SerializeField] AudioClip _audio;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int Points, TotalPoints = 3;

    private void Start()
    {
        text.text = (Points + "/" + TotalPoints);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            HIT();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            HIT();
        }
    }

    void HIT()
    {
        
        Points++;
        text.text = (Points + "/" + TotalPoints);
        FractureObject();
    }
    public void FractureObject()
    {
        AudioSource.PlayClipAtPoint(_audio, transform.position);
        Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version
        Destroy(gameObject); //Destroy the object to stop it getting in the way
    }
}
