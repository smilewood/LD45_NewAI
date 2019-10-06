using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void EventCompleteCallback();
public class colliderdialogueTrigger : MonoBehaviour
{
    public bool onlyTriggerOnce = true;

    [TextArea(4, 20)]
    public string[] text = default;

    public float scrollSpeed = 30f;
    private void OnCollisionEnter2D( Collision2D collision )
    {
        if (collision.gameObject.tag != "Player")
            return;
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
