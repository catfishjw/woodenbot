using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    
    //The offset to the first beat of the song in seconds
    public float firstBeatOffset;

    int nextIndex = 0;


    private float[] notes = new float[] {1,2,3,4,5,6,7,8,9,10};

    public int beatsShownInAdvance;

    public int points;

    public GameObject notePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);
        Debug.Log(points);
        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;
        
        if (nextIndex < notes.Length && notes[nextIndex] < songPositionInBeats + beatsShownInAdvance)
        {
            Instantiate(notePrefab);

            //initialize the fields of the music note

            nextIndex++;
        }
        
    }
}
