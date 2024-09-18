using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWave : MonoBehaviour
{
    private AudioSource myAudioSource;
    
    public float timeBetweenWaves = 1f;
    public float aliveTime;
    public float projSpeed;
    
    public GameObject projectile;

    float nextWave;

    // Awake is used for initialization
    void Awake()
    {
        nextWave = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController myPlayer = transform.root.GetComponent<PlayerController>();

        if(Input.GetMouseButton(0) && nextWave < Time.time)
        {
            Vector3 rot;

            nextWave = Time.time + timeBetweenWaves;

            Debug.Log(myPlayer.facingRight);
            
            if(myPlayer.GetFacing() == -1f)
            {
                rot = new Vector3(0, 180, 0);
            }
            else
            {
                rot = new Vector3(0, -180, 0);
            }

            myAudioSource.Play();

            var waveProj = Instantiate(projectile, transform.position, Quaternion.Euler(rot));
            Destroy(waveProj, aliveTime);
        }
    }
}
