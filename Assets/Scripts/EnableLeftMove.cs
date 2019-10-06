using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLeftMove : MonoBehaviour
{
    public bool enableJump = false;
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<PlayerPlatformerController>().canMoveLeft = true;
            if (enableJump)
            {
                collision.gameObject.GetComponent<PlayerPlatformerController>().canJump = true;
            }
            this.gameObject.SetActive(false);
        }
    }
}
