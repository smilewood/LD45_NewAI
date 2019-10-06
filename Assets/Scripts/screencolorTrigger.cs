using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class screencolorTrigger : MonoBehaviour
{
    public Image screenImage;
    public Color colortofadeto;
    public float timeToFade;

    public bool onlyTriggerOnce = true;

    private void OnCollisionEnter2D( Collision2D collision )
    {
        if (collision.gameObject.tag != "Player")
            return;
        PlayerPlatformerController.stopMovment = true;
        StartCoroutine(fadeScreen( timeToFade ));
    }
    IEnumerator fadeScreen(float seconds)
    {
        float val = 0f;
        Color startColor = screenImage.color;
        while (val < seconds)
        {
            val += Time.deltaTime;
            screenImage.color = Color.Lerp(startColor, colortofadeto, val/seconds);
            yield return new WaitForEndOfFrame();
        }
        PlayerPlatformerController.stopMovment = false;
        if (onlyTriggerOnce)
            this.gameObject.SetActive(false);
        yield return null;
    }

}
