using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPLayer : MonoBehaviour
{
    public Transform player;
    private void FixedUpdate()
    {
        if (this.gameObject.CompareTag("DirectionTracking"))
        {
            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+1, player.transform.position.z);
        }
        else
        {
            this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        }
    }
}
