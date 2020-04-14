using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArpSpawner : MonoBehaviour
{
    // Initiate spawn position variables
    private float spawnX, spawnZ;
    private float spawnY = 10.0f;
    private int sequenceLength = 0;
    private int beatdivision = 1;
    private string ballName;


    [SerializeField] GameObject spawnee;

    private static List<string> arpList = new List<string>();


    void Update()
    {
        sequenceLength = arpList.Count;

        for (int i=0; i<sequenceLength; i++)
        {
            if (BPM.sixteenthBeatFull)
            {
                //Debug.Log( (BPM.sixteenthCountFull / beatdivision) % sequenceLength );
                //int beatCount = (BPM.sixteenthCountFull % sequenceLength); // / beatdivision;
                int beatCount = ((BPM.sixteenthCountFull / beatdivision) % sequenceLength);
                //Debug.Log(beatCount);

                if(beatCount == i)
                {
                    ballName = arpList[i];

                    spawnArpBall();
                }
            }
        }
    }

    private void spawnArpBall()
    {
        spawnX = Random.Range(95.5f, 104.5f);
        spawnZ = Random.Range(45.5f, 54.5f);
        spawnee.name = ballName;

        Instantiate(spawnee, new Vector3(spawnX, spawnY, spawnZ), Quaternion.identity);
    }

    public void addToArp(string nextNote)
    {
        arpList.Add(nextNote);
    }

    public void removeFromArp(string noteKill)
    {
        for (int i=0; i<arpList.Count; i++)
        {
            if (arpList[i] == noteKill)
            {
                arpList.RemoveAt(i);
            }
        }
    }

    public void beatDivisionChoser(int noteDiv)
    {
        beatdivision = noteDiv + 1;
    }

}
