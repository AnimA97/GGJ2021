using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HUDController : MonoBehaviour
{
    public HUDHealthController healthController;    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLife()
    {
        healthController.RemoveLife();
    }

    public void RestoreLives()
    {
        healthController.RestoreLives();
    }

    public int GetHeartCount()
    {
        return healthController.GetHeartCount();
    }

    
}
