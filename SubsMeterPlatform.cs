using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubsMeterPlatform : MonoBehaviour
{
    public GameObject player;
    SubsHeightAdjust cylHeight = new SubsHeightAdjust();


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            float playerX = player.transform.position.x;
            float cylinderY = transform.localScale.y;
            float playerZ = player.transform.position.z;

            // player.transform.position = new Vector3(player.transform.position.x, transform.localScale.y + 0.8f, player.transform.position.z);
            // player.transform.position = new Vector3(playerX, cylinderY, playerZ);
            player.transform.position = new Vector3(playerX, cylHeight.cylinderHeight + 1.0f, playerZ);
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        float playerX = player.transform.position.x;
        float cylinderY = transform.localScale.y;
        float playerZ = player.transform.position.z;

        // player.transform.position = new Vector3(player.transform.position.x, transform.localScale.y + 0.8f, player.transform.position.z);
        // player.transform.position = new Vector3(playerX, cylinderY, playerZ);
        player.transform.position = new Vector3(playerX, cylHeight.cylinderHeight, playerZ);
    }

    private void OnTriggerExit(Collider other)
    {
        player.transform.position = player.transform.position;
    }
    */
}
