using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;

public class RocketStageTwo : Towers
{
    [SerializeField] protected float range;
    [SerializeField] protected AudioSource GunShot;
    [SerializeField] protected float bulletspeed;
    [SerializeField] protected float bps;
    [SerializeField] public GameObject[] bulletspawn;
    [SerializeField] public GameObject bullet;
    public GameObject target;
    public bool Responsive;

    public override IEnumerator Fire()
    {
        Vector2 direction = (Target.transform.position - transform.position).normalized;
        GameObject Firebullet = Instantiate(bullet, bulletspawn[0].transform.position, Quaternion.identity);
        GameObject Firebullet2 = null;
        Firebullet.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;
        BulletAngle(Firebullet);
        GunShot.Play();
        yield return new WaitForSeconds(0.75f);
        if (Target != null)
        {
            direction = (Target.transform.position - transform.position).normalized;
            Firebullet2 = Instantiate(bullet, bulletspawn[1].transform.position, Quaternion.identity);
            BulletAngle(Firebullet2);
            Firebullet2.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;
            GunShot.Play();
        }
        yield return new WaitForSeconds(2f);
        Responsive = true;
        Destroy(Firebullet);
        Destroy(Firebullet2);
    }

    private void Awake()
    {
        Range = range;
        Bulletspeed = bulletspeed;
        Bps = bps;
        Target = target;
    }


    //NO codecoverage
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