using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool onlyTriggerOnce = true;

    [TextArea(4, 20)]
    public string[] text = default;

    public float scrollSpeed = 30f;
    private void OnTriggerEnter2D( Collider2D collision )
    {
        PlayerPlatformerController.stopMovment = true;
        TextBoxController.DisplayText.Invoke(text, scrollSpeed, OnComplete);

    }
    private void OnComplete()
    {
        PlayerPlatformerController.stopMovment = false;

        if (onlyTriggerOnce)
            this.gameObject.SetActive(false);
    }
}
