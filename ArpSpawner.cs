using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArpSpawner : MonoBehaviour
{
    // Initiate spawn position variables
    private float spawnX, spawnZ;
    private float spawnY = 10.0f;

    private int sequenceLength = 0;
    private static int beatdivision = 0;
    private int beatCount;

    private string ballName;
    private static List<string> arpList = new List<string>();

    [SerializeField] GameObject spawnee;


    void Update()
    {
        // Derives length of sequence by number of elements in list
        sequenceLength = arpList.Count;

        /*
         * For each element in list, spawns ball at appropriate beat division
         * based on arp speed determined in SpawnArpPlayerBall by raycasting "n"
         * onto arp ball cylinder platform: 1/4, 1/8, or 1/16 notes
         */
        for (int i=0; i<sequenceLength; i++)
        {
            if (beatdivision == 0)
            {
                if (BPM.beatFull)
                {
                    beatCount = (BPM.beatCountFull % sequenceLength);
                    if (beatCount == i)
                    {
                        ballName = arpList[i];
                        spawnArpBall();
                    }
                }
            }
            else if (beatdivision == 1)
            {
                if(BPM.eighthBeatFull)
                {
                    beatCount = (BPM.eighthCountFull % sequenceLength);
                    if (beatCount == i)
                    {
                        ballName = arpList[i];
                        spawnArpBall();
                    }
                }
            }
            else if (beatdivision == 2)
            {
                if (BPM.sixteenthBeatFull)
                {
                    beatCount = (BPM.sixteenthCountFull % sequenceLength);
                    if (beatCount == i)
                    {
                        ballName = arpList[i];
                        spawnArpBall();
                    }
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

    /*
     * Called from PianoKeyCollisionNote to insert next note onto end of arp
     */
    public void addToArp(string nextNote)
    {
        arpList.Add(nextNote);
    }

    /*
     * Called from PianoKeyCollisionNote to remove all instances of a note
     * from the arp sequence
     */
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

    /*
     * Called from SpawnArpPlayerBall to update arp speed
     */
    public void beatDivisionChooser(int noteDiv)
    {
        beatdivision = noteDiv;
    }


}
