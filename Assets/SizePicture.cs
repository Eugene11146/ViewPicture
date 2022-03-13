using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizePicture : MonoBehaviour
{
    
    public void Sized()
    {
        Position.panelActivating = true;
        Position.spit = gameObject.GetComponent<Image>().sprite;
    }
   
}
