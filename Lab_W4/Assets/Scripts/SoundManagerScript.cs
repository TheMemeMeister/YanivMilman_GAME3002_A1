using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip ShootBallSound, GoalSound;
    static AudioSource audioSrc;
    //public Sounds[] sounds;
    //public enum sound
    //{
    //    Shoot, 
    //    Goal
    //}
    void Start()
    {
        //GameObject soundGameObject = new GameObject("Sound");
        ShootBallSound = Resources.Load<AudioClip>("ShootSound");
        GoalSound = Resources.Load<AudioClip>("GoalSound");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "ShootBall":
                audioSrc.PlayOneShot(ShootBallSound);
                break;
            case "Goal":
                audioSrc.PlayOneShot(GoalSound);
                break;

        }
    }
}
