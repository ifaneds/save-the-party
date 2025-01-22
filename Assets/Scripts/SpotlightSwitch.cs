using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightSwitch : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition;
    float distanceToPlayer;
    public float activationDistance;
    GameObject Camera;
    GameObject lookingAt;
    public GameObject interactText;
    GameObject[] spotlights;
    List<Light> lightComponents = new List<Light>();
    public Color[] colors;
    public int colorIndex = 0;
    bool randomize = false;
    float time = 0.0f;
    float interpolationPeriod = 0.5f;
     GameObject fuseBox;
     bool powered;
    // Start is called before the first frame update
    void Start()
    {
        interactText.SetActive(false);
        Camera = GameObject.Find("MainCamera");
        
        spotlights = GameObject.FindGameObjectsWithTag("Spotlight");
        
        foreach (GameObject light in spotlights)
        {
            lightComponents.Add(light.GetComponent<Light>());
        }
                fuseBox = GameObject.FindWithTag("Fuse Box");

                

                

    }

    // Update is called once per frame
    void Update()
    {
        powered = fuseBox.GetComponent<FuseBox>().isPowerOn();
        time += Time.deltaTime;
        playerPosition = player.transform.position;
        distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        lookingAt = Camera.GetComponent<PlayerInteraction>().lookingAt;
        if (distanceToPlayer < activationDistance && lookingAt == transform.gameObject)          
        {
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (powered){
                colorIndex = colorIndex+1;
                if (colorIndex>5)
                {
                    colorIndex = 0;
                }
                if (colorIndex == 5)
                {
                    randomize = true;
                }
                else{
                    foreach (Light Light in lightComponents)
                    {
                        randomize = false;
                        Light.color = colors[colorIndex];
                    }
                }
                }
                
            }
        } else
        {
            interactText.SetActive(false);
        }
        if(randomize)
        {
            if (time >= interpolationPeriod) {
            time = time - interpolationPeriod;
        foreach(Light Light in lightComponents)
                    {
                        Light.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                    }
            }
        }           
    }
    
}
