using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winTHeGameTrigger : MonoBehaviour
{
    public Image screenImage;
    public GameObject winGameScreen;
    private void OnTriggerEnter2D( Collider2D collision )
    {
        PlayerPlatformerController.stopMovment = true;
        StartCoroutine(fadeScreen(3f));
    }
    IEnumerator fadeScreen( float seconds )
    {
        float val = 0f;
        Color startColor = screenImage.color;
        while (val < seconds)
        {
            val += Time.deltaTime;
            screenImage.color = Color.Lerp(startColor, Color.black, val / seconds);
            yield return new WaitForEndOfFrame();
        }
        winGameScreen.SetActive(true);
        yield return null;
    }
}

