using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScript : MonoBehaviour
{
    public GameObject player;
    public float distanceToPlayer;
    private AudioSource speechClip;
    public GameObject interactText;
    public float activationDistance;
    public Animator animator;
    GameObject Camera;
    public GameObject lookingAt;

   
    // Start is called before the first frame update
    void Start()
    {
        speechClip = GetComponent<AudioSource>();
        speechClip.Stop();
        
        interactText.SetActive(false);

        Camera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        lookingAt = Camera.GetComponent<PlayerInteraction>().lookingAt;
        Vector3 playerPosition = player.transform.position;
        distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        if (distanceToPlayer < activationDistance && lookingAt == transform.gameObject)
        {
            
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)){
            animator.SetTrigger("Interact");
            speechClip.Play();

            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}
