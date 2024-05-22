using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class tower_inst
{


    public position_script position;
    private BuildManager buildmanager;
    private LevelManager lvlmanager;
    
    private SpriteRenderer testSpriteRenderer;
    
    private Color hovcol;
    private Color original;

    [UnityTest]
    public IEnumerator tower_not_null()
    {
        yield return SceneManager.LoadSceneAsync("TestSceneZ");

        GameObject positionobj = GameObject.Find("position");

        position_script position = positionobj.GetComponent<position_script>();

        BuildManager.main.selectedTower = 1;



        //bmanager.selectedTower = 1;

        GameObject manager = new GameObject();
        lvlmanager = manager.AddComponent<LevelManager>();

        lvlmanager.currency = 200;

        Debug.Log("Runs2");

        position.OnMouseDown();


        Debug.Log("Runs3");
        //yield return new WaitForSeconds(1f);

        Assert.IsNotNull(position.tower);

        //yield return null;
    }
}

