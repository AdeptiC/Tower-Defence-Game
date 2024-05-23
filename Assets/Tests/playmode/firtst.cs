using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class firtst
{
    private LevelManager manager;


    // A Test behaves as an ordinary method
    [UnityTest]
    public IEnumerator ReduceHealth_test()
    {
        yield return SceneManager.LoadSceneAsync("TestSceneZ");
        // Use the Assert class to test conditions
        GameObject gameObject = GameObject.Find("LevelManager");
        manager = gameObject.GetComponent<LevelManager>();

        int index = 3;

        manager.ReduceHealth();

        Assert.AreEqual(index, manager.heartIndex);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.


    /*[UnityTest]
    public IEnumerator firtstWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }*/
}
