using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPS1 : MonoBehaviour
{
    private GameObject player, player2;
    [SerializeField] GameObject particles;
    [SerializeField] GameObject particles2;
    [SerializeField] GameObject particles3;
    [SerializeField] GameObject particles4;
    [SerializeField] GameObject particles5;
    [SerializeField] GameObject particles6;
    [SerializeField] GameObject partciles7;
    [SerializeField] GameObject particles8;

    // Position variables
    private float posX, posY, posZ, rotX, rotY, tester;
    private float currentTime = 0.0f;
    private float barTime = 0.0f;
    private float quarterNote = 0.46875f;
    private int beatCounter = 0;
    private int barCounter = 0;

    // Meter Value Variables
    /*
    private float elapsedTime = 0.0f;
    private float marker2 = 45.0f;
    [SerializeField] GameObject obj;
    uint playingID = (uint)AkQueryRTPCValue.RTPCValue_PlayingID;
    public static float lowMeter, lowMidMeter, hiMidMeter, hiMeter;

    MapValues mapValues = new MapValues();
    */

    private float elapsedTime = 0.0f;
    private float marker2 = 45.0f;
    private float marker3 = 90.0f;

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

            // Time controllers
            currentTime += Time.deltaTime;
            barTime += Time.deltaTime;
            elapsedTime += Time.deltaTime;

            // Every quarter note
            if (currentTime > quarterNote)
            {
                float xRand = Random.Range(-30.0f, 30.0f);
                float yRand = Random.Range(100.0f, 1000.0f);
                float zRand = Random.Range(-30.0f, 10.0f);

                Instantiate(particles, new Vector3(posX + xRand, posY - yRand, posZ + zRand), Quaternion.identity);

                if (beatCounter == 0)
                {
                    float xRand2 = Random.Range(-100.0f, 100.0f);
                    float yRand2 = Random.Range(50.0f, 1500.0f);
                    float zRand2 = Random.Range(-200.0f, 200.0f);

                    Instantiate(particles2, new Vector3(posX + xRand2, posY - yRand2, posZ + zRand2), Quaternion.identity);

                    if (elapsedTime > marker3)
                    {
                        Instantiate(particles6, new Vector3(posX - xRand2, posY - (yRand2 + xRand2), posZ - zRand2), Quaternion.identity);
                    }
                }

                if (beatCounter % 2 == 0)
                {
                    float xRand3 = Random.Range(-200.0f, 250.0f);
                    float yRand3 = Random.Range(200.0f, 2000.0f);
                    float zRand3 = Random.Range(-250.0f, 200.0f);

                    Instantiate(particles3, new Vector3(posX + xRand3, posY - yRand3, posZ + zRand3), Quaternion.identity);

                    if (elapsedTime > marker2)
                    {
                        Instantiate(particles5, new Vector3(posX - xRand3, posY - (yRand3 + xRand3), posZ - zRand3), Quaternion.identity);
                    }
                }

                // Increment and wrap beatCounter and currentTime
                beatCounter++;
                beatCounter %= 4;
                currentTime -= quarterNote;
            }

            // Tracks full bars
            if (barTime > quarterNote * 4.0f)
            {
                if (barCounter == 0)
                {
                    float xRand4 = Random.Range(-300.0f, 300.0f);
                    float yRand4 = Random.Range(500.0f, 3000.0f);
                    float zRand4 = Random.Range(-300.0f, 300.0f);

                    Instantiate(particles4, new Vector3(posX + xRand4, posY - yRand4, posZ + zRand4), Quaternion.identity);
                }

                if ( (barCounter * 3) % 4 == 0 )
                {
                    if (elapsedTime > 165.0f)
                    {
                        float xRand8 = Random.Range(-500.0f, 500.0f);
                        float yRand8 = Random.Range(750.0f, 2500.0f);
                        float zRand8 = Random.Range(-400.0f, 400.0f);

                        Instantiate(particles8, new Vector3(posX + xRand8, posY - yRand8, posZ + zRand8), Quaternion.identity);
                    }
                }

                // Increment and wrap barCounter and barTime
                barCounter++;
                barCounter %= 4;
                barTime -= (quarterNote * 4.0f);
            }


        }
        
    }


}
