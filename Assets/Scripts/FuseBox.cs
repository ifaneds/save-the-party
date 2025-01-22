using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition;
    float distanceToPlayer;
    public float activationDistance;
    GameObject Camera;
    GameObject lookingAt;
    public GameObject interactText;
     bool powerIsOn;
    GameObject[] lights;
    GameObject[] tubes;
    public List<Material> materialComponents = new List<Material>();
    

    // Start is called before the first frame update
    void Start()
    {
        powerIsOn = false;
         interactText.SetActive(false);
        Camera = GameObject.Find("MainCamera");
        lights = GameObject.FindGameObjectsWithTag("Lights");
        tubes = GameObject.FindGameObjectsWithTag("Tubes");
        

        foreach (GameObject tube in tubes)
        {
            materialComponents.Add(tube.GetComponent<Renderer>().material);
        }
       
    }
    

    // Update is called once per frame
    void Update()
    {
         playerPosition = player.transform.position;
        distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        lookingAt = Camera.GetComponent<PlayerInteraction>().lookingAt;
        if (distanceToPlayer < activationDistance && lookingAt == transform.gameObject && !powerIsOn)          
        {
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                powerIsOn = true;
            }
        }
        else
        {
            interactText.SetActive(false);
        }
        if (!powerIsOn)
        {
            foreach (GameObject light in lights)
            {
                light.SetActive(false);

            }
            foreach (Material Material in materialComponents)
                    {
                        
                        Material.color = Color.black;
                    }
        } else
        {
            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
            foreach (Material Material in materialComponents)
                    {
                        
                        Material.color = Color.white;
                    }
        }
    }
    public bool isPowerOn()
    {
        return powerIsOn;
    }
}
