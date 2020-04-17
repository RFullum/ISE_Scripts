using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganCubeFlier : MonoBehaviour
{
    // 1.34 sec

    private bool activated, isMoving;
    private Vector3 startPos, targetPos;
    private float speed;
    private int beatPos;

    ArpSpawner arpSpawner = new ArpSpawner();
    List<string> arpNotes;

    private string chordNote1, chordNote2, chordNote3;
    private string[] organNoteStates = new string[25] {"C2", "Csh2", "D2", "Dsh2", "E2", "F2", "Fsh2", "G2",
        "Gsh2", "A2", "Ash2", "B2", "C3", "Csh3", "D3", "Dsh3", "E3", "F3", "Fsh3", "G3",
        "Gsh3", "A3", "Ash3", "B3", "C4"};
    [SerializeField] string wwiseEvent;

    /*
     * Initializes gravity on, activated and isMoving to false,
     * and startPos to current position
     */
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = true;
        activated = isMoving = false;
        startPos = gameObject.transform.position;

        var renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.25f, 1.0f)));
    }



    void Update()
    {
        setSpeed();
        float step = speed * Time.deltaTime;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        /*
         * When raycast over cube, and B is pressed, turn off gravity and
         * set activated to true, retrieves List of current arpeggiator notes from
         * ArpSpawner, sets beatDivision to play on (16th note divisions)
         */
        if (Physics.Raycast(ray, out var hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Destroy(gameObject);
                }

                if (Input.GetKeyDown(KeyCode.B))
                {
                    GetComponent<Rigidbody>().useGravity = false;
                    activated = true;
                    arpNotes = arpSpawner.getArpList();
                    beatPos = BPM.sixteenthCountFull % 16;
                }
            }
        }

        /*
         * If the cube is activated, move it to targetPos, stop at targetPos,
         * get new targetPos, and on the appropriate beat division, play chord
         */
        if (activated == true)
        {
            if(isMoving == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            }

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                isMoving = false;
            }

            if (isMoving == false)
            {
                setSpeed();
                moveToTarget();
            }

            if (BPM.sixteenthBeatFull)
            {
                int beatCount = BPM.sixteenthCountFull % 16;
                {
                    if (beatCount == beatPos)
                    {
                        chordBuilder();
                        AkSoundEngine.PostEvent(wwiseEvent, gameObject);
                    }
                }
            }


        }

    }

    /**
     * Randomly sets X and Z values for new position movement
     * Sets isMoving to true
     */
    private void moveToTarget()
    {
        float xTarget = Random.Range(-30.0f, 150.0f);          // IF YOU CHANGE THIS, CHANGE OrganADSR SCRIPT TOO!!!
        float yTarget = Random.Range(2.0f, 50.0f);
        float zTarget = Random.Range(-30.0f, 150.0f);


        targetPos = new Vector3(xTarget, yTarget, zTarget);
        isMoving = true;
    }

    private void setSpeed()
    {
        speed = Random.Range(5.0f, 100.0f);
    }


    /*
     * Grabs chord notes from the notes being played in the arpeggiator
     * Initializes all Blend RTPC to 0 (silent)
     * Turns up the Blend RTPC values to 100 (full volume) for the
     * selected chord notes
     */
    private void chordBuilder()
    {
        int notesLength = arpNotes.Count;
        chordNote1 = "Organ_" + arpNotes[Random.Range(0, notesLength - 1)];
        chordNote2 = "Organ_" + arpNotes[Random.Range(0, notesLength - 1)];
        chordNote3 = "Organ_" + arpNotes[Random.Range(0, notesLength - 1)];
        for (int i=0; i<organNoteStates.Length; i++)
        {
            string rtpcName = "Organ_" + organNoteStates[i];
            AkSoundEngine.SetRTPCValue(rtpcName, 0.0f);
            AkSoundEngine.SetRTPCValue(chordNote1, 100.0f);
            AkSoundEngine.SetRTPCValue(chordNote2, 100.0f);
            AkSoundEngine.SetRTPCValue(chordNote2, 100.0f);
        }
    }

}
