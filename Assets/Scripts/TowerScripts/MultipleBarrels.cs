using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MultipleBarrels : Towers
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
        Responsive = true;
        Vector2 direction = (Target.transform.position - transform.position).normalized;
        GameObject Firebullet = Instantiate(bullet, bulletspawn[0].transform.position, Quaternion.identity);
        BulletAngle(Firebullet);
        GunShot.Play();

        GameObject Firebullet2 = Instantiate(bullet, bulletspawn[1].transform.position, Quaternion.identity);
        BulletAngle(Firebullet2);
        GunShot.Play();
        
        
        Firebullet.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;
        Firebullet2.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;
        
        yield return new WaitForSeconds(2f);
        
        Destroy(Firebullet);
        Destroy(Firebullet2);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        Range = range;
        Bulletspeed = bulletspeed;
        Bps = bps;
        Target = target;
        Responsive = false;
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
