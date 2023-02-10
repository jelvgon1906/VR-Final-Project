using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject ItemInSlot;
    public Image slotImage;
    Color originalColor;
    void Start()
    {
        slotImage = GetComponentInChildren<Image>();
        originalColor = slotImage.color;
    }
    private void OnTriggerStay(Collider other)
    {
        if (ItemInSlot != null) return;
        GameObject obj = other.gameObject;
        if (obj.GetComponent<Items>() == null) return;
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            InsertItem(obj);
        }
    }
    void InsertItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = new Vector3(-0.2f, -0.1f, 0);
        obj.transform.localEulerAngles = obj.GetComponent<Items>().slotRotation;
        obj.GetComponent<Items>().inSlot = true;
        obj.GetComponent<Items>().currentSlot = this;
        ItemInSlot = obj;
        slotImage.color = Color.gray;
    }
    public void ResetColor()
    {
        slotImage.color = originalColor;
    }
}
