using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSubsPlatform : MonoBehaviour
{
    public GameObject player;

    private float playerX;
    //private float playerY;
    private float playerZ;
    private float scaleVal = 20.0f;

    // Instance of MapValues script
    MapValues mapValues = new MapValues();
    /*
    private void Update()
    {
        playerX = player.transform.position.x;
        //playerY = player.transform.position.y;
        playerZ = player.transform.position.z;

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            //player.transform.parent.position = transform.position;
            float meterVal = ElevatorSubsRTPC.meterValue;
            if (meterVal <= -80.0f)
                meterVal = -80.0f;

            float scaleMeterVal = mapValues.remapValues(meterVal, -80.0f, 10.0f, 0.12f, scaleVal);
            player.transform.position = new Vector3(playerX, scaleMeterVal, playerZ);
        }
    }
    */
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
    
}
