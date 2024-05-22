using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;

public class RocketStage3 : Towers
{
    [SerializeField] protected float range;
    [SerializeField] protected AudioSource GunShot;
    [SerializeField] protected float bulletspeed;
    [SerializeField] protected float bps;
    [SerializeField] protected GameObject[] bulletspawn;
    [SerializeField] public GameObject bullet;
    protected GameObject target;
    public bool Responsive;

    public override IEnumerator Fire()
    {
        Vector2 direction = (Target.transform.position - transform.position).normalized;
        List<GameObject> firedBullets = new List<GameObject>();


        for (int i = 0; i < bulletspawn.Length; i++)
        {
            

            if (Target != null)
            {
                GameObject fireBullet = Instantiate(bullet, bulletspawn[i].transform.position, Quaternion.identity);
                BulletAngle(fireBullet);
                fireBullet.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;
                GunShot.Play();
                firedBullets.Add(fireBullet);

            }

            // Wait for 0.1 seconds between each shot, except after the last one
            if (i < bulletspawn.Length - 1)
            {
                yield return new WaitForSeconds(0.75f);
            }
        }

        // Wait 2 seconds after the last bullet before starting to destroy them
        Responsive = true;
        yield return new WaitForSeconds(2f);

        // Destroy all bullets that were fired
        foreach (var bullet in firedBullets)
        {
            Destroy(bullet);
            
        }
        
    }


    private void Awake()
    {
        Range = range;
        Bulletspeed = bulletspeed;
        Bps = bps;
        Target = target;
    }


    [ExcludeFromCodeCoverage]
#if UNITY_EDITOR
    public void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, range);
    }
#endif


    // Update is called once per frame
    protected override void Update()
    {
        GunUpdate();

    }

}