using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{
    public GameObject Torch;
    // Start is called before the first frame update
    void Start()
    {
        
        Torch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            {
                if (!Torch.activeInHierarchy){
                    Torch.SetActive(true);
                } else {
                    Torch.SetActive(false);
                }
            
                
            }
    }
}
