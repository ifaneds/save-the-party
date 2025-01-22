using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPanelsSwitch : MonoBehaviour
{
    public GameObject player;
    Vector3 playerPosition;
    float distanceToPlayer;
    public float activationDistance;
    GameObject Camera;
    GameObject lookingAt;
    public GameObject interactText;
    public GameObject[] panels;
    public List<Material> materialComponents = new List<Material>();
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
        
        panels = GameObject.FindGameObjectsWithTag("Floor Panels");
        
        foreach (GameObject panel in panels)
        {
            materialComponents.Add(panel.GetComponent<Renderer>().material);
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
                if (powered)
                {
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
                    foreach (Material Material in materialComponents)
                    {
                        randomize = false;
                        Material.color = colors[colorIndex];
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
        foreach(Material Material in materialComponents)
                    {
                        Material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                    }
            }
        }
           
    }
}
