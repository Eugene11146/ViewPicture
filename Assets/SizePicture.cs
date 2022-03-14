using UnityEngine;
using UnityEngine.UI;

public class SizePicture : MonoBehaviour
{
    
    public void Sized()
    {
        Position.panelActivating = true;
        Position.bigViewStaticSprite = gameObject.GetComponent<Image>().sprite;
    }
}
