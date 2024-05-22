using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class OneBarrel : Towers
{
    [SerializeField] private float range = 5f;
    [SerializeField] private float bulletspeed = 20f;
    [SerializeField] private float bps = 1f;
    private GameObject target;
    [SerializeField] private GameObject bulletspawn;
    [SerializeField] public GameObject bullet;
    [SerializeField] protected AudioSource GunShot;
    public bool Responsive = false;

    private void Awake()
    {
        Range = range;
        Bulletspeed = bulletspeed;
        Bps = bps;
        Target = target;
    }


    public override IEnumerator Fire()
    {
        // Set the flag to indicate that Fire method has been called
        

        GameObject firebullet = Instantiate(bullet, bulletspawn.transform.position, Quaternion.identity);
        Vector2 direction = (Target.transform.position - transform.position).normalized;
        firebullet.GetComponent<Rigidbody2D>().velocity = Bulletspeed * direction;
        BulletAngle(firebullet);
        GunShot.Play();


        yield return new WaitForSeconds(1f);
        Responsive = true;
        Destroy(firebullet);
        

        // Reset the flag after the bullet is destroyed
    }

    [ExcludeFromCodeCoverage]
    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, range);
    }
    #endif


    protected override void Update()
    {
       GunUpdate();
    }

    

}
