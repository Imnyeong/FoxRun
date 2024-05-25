using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void OnClickJump()
    {
        Character.instance.inputJump = true;
    }
    public void PointerDownCrouch()
    {
        Character.instance.inputCrouch = true;
    }
    public void PointerUpCrouch()
    {
        Character.instance.inputCrouch = false;
    }
}
