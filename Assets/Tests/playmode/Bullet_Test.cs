using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Bullet_Test
{

    [UnityTest]
    public IEnumerator Rocket_InstatiateTest()
    {
        yield return SceneManager.LoadSceneAsync("TestSceneJ");
        GameObject rocket1Obj = GameObject.Find("Rocketlvl3");
        GameObject rocket2Obj = GameObject.Find("Rocketlvl2");
        RocketStage3 rocketscript = rocket1Obj.GetComponent<RocketStage3>();
        RocketStageTwo rocketscript2 = rocket2Obj.GetComponent<RocketStageTwo>();

        rocket1Obj.transform.position = new Vector3(-5f, -1.24f, 0);
        yield return new WaitForSeconds(3f);
        yield return rocketscript.Fire();
        Assert.IsTrue(rocketscript.Responsive);
        rocket1Obj.transform.position = new Vector3(100f, -1.24f, 0);
        rocket2Obj.transform.position = new Vector3(-5f, -1.24f, 0);
        yield return new WaitForSeconds(3f);
        yield return rocketscript2.Fire();
        Assert.IsTrue(rocketscript2.Responsive);
        rocket2Obj.transform.position = new Vector3(100f, -1.24f, 0);
    }

    [UnityTest]
    public IEnumerator Bullet_InstatiateTest()
    {
        yield return SceneManager.LoadSceneAsync("TestSceneJ");
        GameObject Gun1Obj = GameObject.Find("Tower (8)");
        GameObject Gun2Obj = GameObject.Find("Tower (2)");
        OneBarrel Gunscript = Gun1Obj.GetComponent<OneBarrel>();
        MultipleBarrels Gunscript2 = Gun2Obj.GetComponent<MultipleBarrels>();

        Gun1Obj.transform.position = new Vector3(-5f, -1.24f, 0);
        yield return new WaitForSeconds(6f);
        
        Assert.IsTrue(Gunscript.Responsive);
        Gun1Obj.transform.position = new Vector3(-100f, -1.24f, 0);

        Gun2Obj.transform.position = new Vector3(-5f, -1.24f, 0);
        yield return new WaitForSeconds(6f);
        
        Assert.IsTrue(Gunscript2.Responsive);
        Gun2Obj.transform.position = new Vector3(-100f, -1.24f, 0);
    }
}
