using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     public GameObject player;
    Vector3 playerPosition;
    float distanceToPlayer;
    public float activationDistance;
    GameObject Camera;
    public GameObject lookingAt;
    public GameObject interactText;
    public Transform inView;
    public bool isHolding;
    public GameObject holding;
    public GrabBall ballScript;

    public float throwSpeed;
    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
        Camera = GameObject.Find("MainCamera");
        
        

        ballScript = GameObject.Find("Ball Holder").GetComponent<GrabBall>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ballScript = GameObject.Find("Ball Holder").GetComponent<GrabBall>();
        holding = ballScript.holding;
        isHolding = ballScript.isHolding;
            
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
                holding = lookingAt;
                holding.transform.position = inView.position;
                holding.GetComponent<Rigidbody>().useGravity = false;
                holding.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                holding.GetComponent<Collider>().enabled= false;
                holding.transform.parent = inView;
                isHolding = true;
                holding = holding;
                }         

            }
            
        } else if (lookingAt != ballScript.holding&& lookingAt != GameObject.Find("Ball Holder"))
        {
            interactText.SetActive(false);
            
            if (Input.GetKeyDown(KeyCode.E))
            {  
        if (isHolding)
                {
                    
                    holding.GetComponent<Rigidbody>().useGravity = true;
                    holding.GetComponent<Collider>().enabled= true;
                    holding.transform.parent = null;
                    holding.GetComponent<Rigidbody>().velocity = Camera.GetComponent<PlayerInteraction>().forwardDirection * throwSpeed;

                    isHolding = false;
                    holding = null;
                    
                }    
            }  
        }
        ballScript.holding = holding;
        ballScript.isHolding = isHolding;
        

    }
}
