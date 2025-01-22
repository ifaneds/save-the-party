using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
     public GameObject player;
    Vector3 playerPosition;
    float distanceToPlayer;
    public float activationDistance;
    GameObject Camera;
    GameObject lookingAt;
    public GameObject interactText;
    public bool open;
    GameObject door;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
        Camera = GameObject.Find("MainCamera");
        open = false;
        door = transform.gameObject;
        anim = door.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {   
        anim.SetBool("Open",open);
        
        playerPosition = player.transform.position;
        distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        lookingAt = Camera.GetComponent<PlayerInteraction>().lookingAt;

        if (distanceToPlayer < activationDistance && lookingAt == transform.gameObject)          
        {
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                 open = !open;
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}
