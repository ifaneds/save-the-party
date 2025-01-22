using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RideElevator: MonoBehaviour
{
    public GameObject interactText;
    public float distanceToPlayer;
    public float activationDistance;
    public GameObject player;

    public GameObject leftDoor;
    
    GameObject blackScreen;

    Animator leftAnim;

    GameObject Camera;
    public GameObject lookingAt;
    Vector3 playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
        blackScreen = GameObject.FindWithTag("BlackOut");
        Camera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void FixedUpdate() {   

        lookingAt = Camera.GetComponent<PlayerInteraction>().lookingAt;


         playerPosition = player.transform.position;
         if (leftDoor != null)
         {
         leftAnim = leftDoor.GetComponent<Animator>();
         
        }
        distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        if (distanceToPlayer < activationDistance && lookingAt == transform.gameObject)          
        {
            
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
            if (leftAnim.GetBool("Open") == false)
                {
            if (playerPosition.y < 1 && playerPosition.y >0)
            {
                
                player.transform.position = new Vector3(playerPosition.x, playerPosition.y-30, playerPosition.z);
                } else 
                {
                     player.transform.position = new Vector3(playerPosition.x, playerPosition.y+30, playerPosition.z);
                }
            }

            }
        } else
        {
            interactText.SetActive(false);
        }
    
    }
     public IEnumerator FadeToBlack(bool fade, int fadeSpeed)
     {
        Color objectColor = blackScreen.GetComponent<Image>().color;
        float fadeAmount;
        

        if (fade)
        {
            while (blackScreen.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackScreen.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        } else 
        {
            while (blackScreen.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackScreen.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
     }
   
     
}
 

