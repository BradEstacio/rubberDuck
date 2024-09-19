using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWave : MonoBehaviour
{
    public GameObject QuackWaveform;

    public float damage = 1f;
    public float range = 5f;

    bool facingRight;

    Ray shootWave;
    RaycastHit waveHit;
    int shootableMask;
    LineRenderer waveform;

    // Awake is used for initialization
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        shootWave.origin = transform.position;
        shootWave.direction = transform.forward;

        if(Physics.Raycast(shootWave, out waveHit, range, shootableMask))
        {
            Debug.Log("Hit!");
            if(waveHit.collider.tag == "Enemy"){
                PlatformBug theEnemyHealth = waveHit.collider.GetComponent<PlatformBug>();
                theEnemyHealth.addDamage(damage);
            }
            // "Enemy" hit
            waveform.SetPosition(1, waveHit.point);
        }
        else
        {
            waveform.SetPosition(1, shootWave.origin + shootWave.direction * range);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        shootWave.origin = transform.position;
        shootWave.direction = transform.forward;

        if(Physics.Raycast(shootWave, out waveHit, range, shootableMask))
        {
            Debug.Log("Hit!");
            if(waveHit.collider.tag == "Enemy"){
                PlatformBug theEnemyHealth = waveHit.collider.GetComponent<PlatformBug>();
                theEnemyHealth.addDamage(damage);
            }
            // "Enemy" hit
            waveform.SetPosition(1, waveHit.point);
        }
        else
        {
            waveform.SetPosition(1, shootWave.origin + shootWave.direction * range);
        }
    }
}
