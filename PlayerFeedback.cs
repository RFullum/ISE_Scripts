﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeedback : MonoBehaviour
{
    [SerializeField] string bButtonFeedback;
    [SerializeField] string hButtonFeedback;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            AkSoundEngine.PostEvent(bButtonFeedback, gameObject);
        if (Input.GetKeyDown(KeyCode.H))
            AkSoundEngine.PostEvent(hButtonFeedback, gameObject);
    }
}
