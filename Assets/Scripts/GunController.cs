using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    
    
    bool cooldown = true;
    public GameObject bullet;
    public float shootForce;
    public Transform outPosition;
    OVRGrabbable Grabbable;
    [SerializeField] AudioClip _audioShot;

    bool startGrab = true;

    private void Start()
    {
        Grabbable = GetComponent<OVRGrabbable>();
    }
    private void Update()
    {
        if (Grabbable.isGrabbed)
        {
            if ((OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) && cooldown)
            {
                cooldown = false;
                Instantiate(bullet, outPosition.position, outPosition.rotation).GetComponent<Rigidbody>().AddForce(outPosition.forward * shootForce);
                AudioSource.PlayClipAtPoint(_audioShot, transform.position);
                Invoke("Cooldown", 1f);
            }
        }
        else startGrab = true;

        if (Grabbable.isGrabbed && startGrab)
        {
            if (Grabbable.grabbedBy.name.Contains("Right"))
            {
                transform.Rotate(0, 0, 90);
            }
            else transform.Rotate(0, 0, -90);


            transform.Rotate(0, 0, 0);
            startGrab = false;
        }
    }
    

    void Cooldown()
    {
        cooldown = true;
    }
}
