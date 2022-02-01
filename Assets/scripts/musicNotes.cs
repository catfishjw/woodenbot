using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicNotes : MonoBehaviour
{
    private GameObject SpawnPos;
    private GameObject RemovePos;

    public GameObject[] startList;
    public GameObject[] endList;

    public musicController music;

    float BeatsShownInAdvance;
    float beatOfThisNote;

    // Start is called before the first frame update
    void Start()
    {
        startList[0] = GameObject.Find("LeftSpawn");
        startList[1] = GameObject.Find("RightSpawn");
        startList[2] = GameObject.Find("UpSpawn");
        startList[3] = GameObject.Find("DownSpawn");

        endList[0] = GameObject.Find("Left Key");
        endList[1] = GameObject.Find("Right Key");
        endList[2] = GameObject.Find("Up Key");
        endList[3] = GameObject.Find("Down Key");

        music = GameObject.Find("rhythmController").GetComponent<musicController>();

        BeatsShownInAdvance = music.beatsShownInAdvance;
        beatOfThisNote = music.songPositionInBeats + BeatsShownInAdvance;

        int randindex = Random.Range(0, 3);
        SpawnPos = startList[randindex];
        RemovePos = endList[randindex];
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
    void OnCollisionEnter(Collision other)
    {
        music.points += 100;
        Debug.Log(music.points);
        Destroy(gameObject);
    }
    }
