using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthKits : MonoBehaviour
{
    public Slider healthBar;
    public int healthValue = 20;



    public void GiveHealth(int healthvalue2)
    {
        healthBar.value += healthvalue2;
    }

  

   
    


}
