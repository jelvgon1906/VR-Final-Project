using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject anchor;
    bool UIActive;
    private void Start()
    {
        inventory.SetActive(false);
        UIActive = false;
    }
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            UIActive = !UIActive;
            inventory.SetActive(UIActive);
        }
        if (UIActive)
        {
            inventory.transform.position = anchor.transform.position;
            inventory.transform.eulerAngles = new Vector3(anchor.transform.eulerAngles.x + 15, anchor.transform.eulerAngles.y, 0);
        }
    }
}
