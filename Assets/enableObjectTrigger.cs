using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableObjectTrigger : MonoBehaviour
{
    public bool enableObject = true;
    public GameObject target;
    private void OnCollisionEnter2D( Collision2D collision )
    {
        if (collision.gameObject.tag != "Player")
            return;
        target.SetActive(enableObject);
    }
}
