using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBall : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition;
    float distanceToPlayer;
    public float activationDistance;
    GameObject Camera;
    public GameObject lookingAt;
    public GameObject interactText;
    GameObject ball;
    
    public Transform inView;
    public bool isHolding;
    public GameObject holding;
    public GameObject newText;
    
    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
        Camera = GameObject.Find("MainCamera");
        ball = GameObject.FindWithTag("Balls");
        
    }

    // Update is called once per frame
    void Update()
    {
         playerPosition = player.transform.position;
        distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        lookingAt = Camera.GetComponent<PlayerInteraction>().lookingAt;
         if (distanceToPlayer < activationDistance && lookingAt == transform.gameObject)          
        {
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {   
                if (!isHolding)
                {
                
                holding = Instantiate(ball);
                holding.GetComponent<Ball>().interactText = Instantiate(newText, GameObject.Find("Canvas").transform);
                holding.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                holding.transform.position = inView.position;
                holding.GetComponent<Rigidbody>().useGravity = false;
                holding.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                holding.GetComponent<Collider>().enabled= false;
                holding.transform.parent = inView;
                isHolding = true;
                }
                

            }
        }
         else
        {
            interactText.SetActive(false);
        }

    }
}
