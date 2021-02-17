using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoalScript : MonoBehaviour
{
    public Rigidbody m_ball;
    public ProjectileController BallCtrl;
    public Text Goals;
    public int GoalNum = 0;
    public AudioSource GOAL;
    // Start is called before the first frame update
    void Start()
    {
        Goals = FindObjectOfType<Text>();
        GOAL = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Goals.text = "Goals: " + GoalNum;
    }

    private void OnCollisionEnter(Collision other)
    {
        SoundManagerScript.PlaySound("GoalSound");
        m_ball = other.gameObject.GetComponent<Rigidbody>();
        BallCtrl = other.gameObject.GetComponent<ProjectileController>();
        BallCtrl.ResetProjectile();
        GOAL.Play();
        GoalNum++;
        
    }
}
