using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicNotes : MonoBehaviour
{
    public GameObject SpawnPos;
    public GameObject RemovePos;

    public musicController music;

    float BeatsShownInAdvance;
    float beatOfThisNote;

    // Start is called before the first frame update
    void Start()
    {
        float BeatsShownInAdvance = music.beatsShownInAdvance;
        float beatOfThisNote = music.songPositionInBeats + BeatsShownInAdvance;
    }

    // Update is called once per frame
    void Update()
    {
        float songPosInBeats = music.songPositionInBeats;
        transform.position = Vector3.Lerp(SpawnPos.transform.position, RemovePos.transform.position, (BeatsShownInAdvance - (beatOfThisNote - songPosInBeats)) / BeatsShownInAdvance);
        if (transform.position == RemovePos.transform.position)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        music.points = music.points + 100;
        Destroy(gameObject);
    }
    }
