using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public AudioSource AudioSource;
    public Health Health;
    public GameObject Player;

    public UnityEvent EnemyDeathEvent;
    public bool IsDying;
    public AudioClip ScreamClip;
    public AudioClip SquishClip;

    
    // Start is called before the first frame update
    public void Start()
    {
        Health = GetComponent<Health>();
        AudioSource = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");
        EnemyDeathEvent.AddListener(Player.GetComponent<PlayerController>().Kill);
        AudioSource.clip = ScreamClip;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckDeath()
    {
        if (!AudioSource.isPlaying && IsDying)
        {
            Die();
        }
    }

    public virtual void BeginDeath()
    {
        IsDying = true;

        AudioSource.Stop();

        Squish();
        Scream();
    }

    public void Die()
    {
        EnemyDeathEvent.Invoke();
        gameObject.SetActive(false);
    }

    public void Squish()
    {
        AudioSource.PlayClipAtPoint(SquishClip, transform.position);
    }

    public void Scream()
    {
        AudioSource.PlayClipAtPoint(ScreamClip, transform.position);
    }
}
