using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPS1 : MonoBehaviour
{
    private GameObject player, player2;
    [SerializeField] GameObject particles;
    private float posX, posY, posZ, rotX, rotY, tester;

    void Start()
    {
        // Gets FPSController GameObject
        player = GameObject.Find("FPSController");
        player2 = GameObject.Find("FPSController/FirstPersonCharacter");
    }

    void Update()
    {
        if (Singleton.Instance.isFalling == true)
        {
            // Gets position values from Player
            posX = player.transform.position.x;
            posY = player.transform.position.y;
            posZ = player.transform.position.z;

            // Gets rotation value from Player
            rotX = player2.transform.localEulerAngles.x;
            rotY = player.transform.localEulerAngles.y;

            float currentTime = Time.time;
            currentTime += Time.deltaTime;
            if (currentTime > 0.46875f)
            {
                float xRand = Random.Range(-30.0f, 30.0f);
                float yRand = Random.Range(100.0f, 1000.0f);
                float zRand = Random.Range(-30.0f, 10.0f);

                Instantiate(particles, new Vector3(posX + xRand, posY - yRand, posZ + zRand), Quaternion.identity);
            }

            

            //Debug.Log(rotX);
        }
        
    }
}
