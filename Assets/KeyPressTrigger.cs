using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPressTrigger : MonoBehaviour
{
    public bool onlyTriggerOnce = true;
    public bool enableRightMove = false;
    [TextArea(4, 20)]
    public string[] text = default;

    public float scrollSpeed = 30f;
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            PlayerPlatformerController.stopMovment = true;
            TextBoxController.DisplayText.Invoke(text, scrollSpeed, OnComplete);
            if (onlyTriggerOnce)
                this.gameObject.SetActive(false);
        }
    }
    private void OnComplete()
    {
        PlayerPlatformerController.stopMovment = false;
        if (enableRightMove)
        {
            GameObject.Find("Player").GetComponent<PlayerPlatformerController>().canMoveRight = true;
        }
        
    }
}
