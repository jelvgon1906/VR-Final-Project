using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float range;
    RaycastHit hit;
    public LayerMask layerGround;
    public LineRenderer line;
    public Transform player;
    public GameObject plainTeleport;
    private bool cooldown = true;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        /*player = transform.parent.parent.parent.parent.parent;*/
        line.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, range, layerGround))
            {
                //Tomamos el componente LineRenderer 
                line.enabled = true;
                //Posición inicial del LineRender
                line.SetPosition(0, transform.position);
                //Posición final del LineRender
                line.SetPosition(1, hit.point);
                // Activamos la base del teleport
                plainTeleport.SetActive(true);

                plainTeleport.transform.position = hit.point;
                plainTeleport.transform.GetChild(0).position = hit.point;




                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                   // Debug.Log(player);

                    player.GetComponent<CharacterController>().enabled = false;
                    player.GetComponent<OVRPlayerController>().enabled = false;

                    if (hit.transform.tag.Equals("TeleportArea"))
                    {
                        //Creamos un objeto vacio en el rectángulo y lo posicionamos arriba, esta será la posición de desplazamiento.
                        player.transform.position = hit.transform.GetChild(0).position;
                    }
                    else if(cooldown)
                    {
                        player.transform.position = hit.point + new Vector3(0, 1f, 0);
                        cooldown = false;
                        Invoke("Cooldown", 0.2f);
                    }  

                   player.GetComponent<CharacterController>().enabled = true;
                   player.GetComponent<OVRPlayerController>().enabled = true;
                }
            }
            else
            {
                line.enabled = false;
                plainTeleport.SetActive(false);

            }
        }
        else
        {
            line.enabled = false;
            plainTeleport.SetActive(false);

        }
    }

    void Cooldown()
    {
        cooldown = true;
    }
}
