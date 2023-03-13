using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject itemInSlot;
    public Image slotImage;
    Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;
    }

    private void OnTriggerStay(Collider other)
    {
        if(itemInSlot != null)
            return;

        GameObject obj = other.gameObject;

        if (obj.GetComponent<Items>() == null)
            return;

        bool InSlot = obj.GetComponent<Items>().inSlot;
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) && !(InSlot))
            //if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
            InsertItem(obj);
    }

    void InsertItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        //obj.GetComponent<Rigidbody>().useGravity = false;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localEulerAngles = obj.GetComponent<Items>().slotRotation;
        obj.GetComponent<Items>().inSlot = true;
        obj.GetComponent<Items>().currentSlot = this;
        itemInSlot = obj;
        slotImage.color = Color.red;
    }

    public void ResetColor()
    {
        slotImage.color = originalColor;
    }
}
