using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseElevator: MonoBehaviour
{
    public GameObject interactText;
    public float distanceToPlayer;
    public float activationDistance;
    public GameObject player;

    public GameObject leftDoor;
    public GameObject rightDoor;

    Animator leftAnim;
    Animator rightAnim;

    GameObject Camera;
    public GameObject lookingAt;
    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);

        Camera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        lookingAt = Camera.GetComponent<PlayerInteraction>().lookingAt;

         Vector3 playerPosition = player.transform.position;
         if (leftDoor != null && rightDoor != null)
         {
         leftAnim = leftDoor.GetComponent<Animator>();
         rightAnim = rightDoor.GetComponent<Animator>();
        }
        distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        if (distanceToPlayer < activationDistance && lookingAt == transform.gameObject)
        {
            
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)){
                if (leftAnim.GetBool("Open") == false)
                {
                    leftAnim.SetBool("Open",true);
                    rightAnim.SetBool("Open",true);
                }else{
                    leftAnim.SetBool("Open",false);
                    rightAnim.SetBool("Open",false);
                }
            
            }
        }
        else
        {
            interactText.SetActive(false);
        }
 
     }
 
}
