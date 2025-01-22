using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition;
    float distanceToPlayer;
    public float activationDistance;
    GameObject Camera;
    GameObject lookingAt;
    public GameObject interactText;
    GameObject bulb;
    public Light[] light;
    bool powered;
    GameObject fuseBox;
    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
        Camera = GameObject.Find("MainCamera");
        light = transform.gameObject.GetComponentsInChildren<Light>();

        fuseBox = GameObject.FindWithTag("Fuse Box");
    }

    // Update is called once per frame
    void Update()
    {
        powered = fuseBox.GetComponent<FuseBox>().isPowerOn();
        playerPosition = player.transform.position;
        distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        lookingAt = Camera.GetComponent<PlayerInteraction>().lookingAt;

          if (distanceToPlayer < activationDistance && lookingAt == transform.gameObject)          
        {
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (powered){
                if (light[0].intensity != 0)
                {
                light[0].intensity = 0;
                }
                else{
                    light[0].intensity = 200;
                }
                }
            }
    }
    else
        {
            interactText.SetActive(false);
        }

    }
}
