using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{
    //Variables for dimensionalPlatforms
    private GameObject gogglesObject;
    private DimensionShiftGoggles gogglesScript;
    private List<GameObject> platforms;

    //Variables for pauseMenu
    private GameObject pauseMenuObject;
    private PauseMenu pauseMenuScript;
    private GameObject UIObject;

    //Variables for AbilityUI
    private GameObject CanvasTestObject;
    private AbilityUIManager abilityUIManager;

    private GameObject platformGLUI;
    private GameObject gogglesUI;
    private GameObject miniManUI;



    [SetUp]
    public void Setup()
    {

        //Setup for Platform spawner tests
        gogglesObject = new GameObject("GogglesObject");
        gogglesScript = gogglesObject.AddComponent<DimensionShiftGoggles>();

        platforms = new List<GameObject>();
        for (int i = 0; i < 3; i++) 
        {
            GameObject platform = new GameObject("Platform " +  i);
            platform.SetActive(false);
            platforms.Add(platform);
        }

        gogglesScript.dimensionalPlatforms = platforms;

        //Setup for Pause and Resume feature
        pauseMenuObject = new GameObject("PauseMenuObject");
        pauseMenuScript = pauseMenuObject.AddComponent<PauseMenu>();
        UIObject = new GameObject("displayUI");

        pauseMenuScript.pauseDisplay = UIObject;

        //Setup for AbilityUI
        CanvasTestObject = new GameObject("TestUIObject");
        abilityUIManager = CanvasTestObject.AddComponent<AbilityUIManager>();

        platformGLUI = new GameObject("PlatforGLUIObject");
        gogglesUI = new GameObject("gogglesUIObject");
        miniManUI = new GameObject("mini-manUIObject");

        abilityUIManager.DimensionalUI = gogglesUI;
        abilityUIManager.launcherUI = platformGLUI;
        abilityUIManager.MiniManUI = miniManUI;





    }

    [TearDown]
    public void Teardown()
    {

        Object.Destroy(gogglesObject);
        foreach (var platform in platforms)
        {
            Object.Destroy(platform);
        }

        Object.Destroy(pauseMenuObject);

    }

    //Test that platforms properly spawn
    [UnityTest]
    public IEnumerator Goggles_ActivatePlatforms()
    {
        //ToolSelection.hasDimensionalGoggles = true;

        gogglesScript.StartCoroutine(gogglesScript.ActivateGoggles());

        yield return new WaitForSeconds(1.0f);

        foreach (var platform in gogglesScript.dimensionalPlatforms)
        {
            Assert.IsTrue(platform.activeSelf, platform.name + " should be active.");
        }
    }

    //Test that platforms properly Despawn
    [UnityTest]
    public IEnumerator Goggles_DeactivatePlatforms()
    {

        //ToolSelection.hasDimensionalGoggles = true;

        gogglesScript.StartCoroutine(gogglesScript.ActivateGoggles());

        yield return new WaitForSeconds(gogglesScript.maxDuration + 1.0f);

        foreach (var platform in gogglesScript.dimensionalPlatforms)
        {
            Assert.IsFalse(platform.activeSelf, platform.name + " should be inactive.");
        }
    }

    //Test for pausing and resuming the game
    [Test]
    public void Pause_And_Resume_Test()
    {
        pauseMenuScript.PauseGame();

        Assert.IsTrue(Time.timeScale == 0.0f, " game has been paused");

        pauseMenuScript.ResumeGame();

        Assert.IsTrue(Time.timeScale == 1.0f, " game has been resumed");
    }

    //Test for pause menu display
    [Test]
    public void UI_Displayed()
    {
        pauseMenuScript.PauseGame();

        Assert.IsTrue(UIObject.activeSelf, " Pause Menu is displayed");

        pauseMenuScript.ResumeGame();

        Assert.IsFalse(UIObject.activeSelf, " Pause Menu is hidden");
    }


    //Test for ability UI Icons
    [Test]
    public void Ability_UI_Test()
    {
        ToolSelection.hasMiniMan = false;
        ToolSelection.hasLauncher = false;
        ToolSelection.hasDimensionalGoggles = false;

        abilityUIManager.Update();

        Assert.IsFalse(miniManUI.activeSelf, " Mini-Man UI is hidden");
        Assert.IsFalse(gogglesUI.activeSelf, " Dimensional Goggles UI is hidden");
        Assert.IsFalse(platformGLUI.activeSelf, " Platform Launcher UI is hidden");


        
        ToolSelection.hasMiniMan = true;

        abilityUIManager.Update();

        Assert.IsFalse(gogglesUI.activeSelf);
        Assert.IsFalse(platformGLUI.activeSelf);
        Assert.IsTrue(miniManUI.activeSelf, " MiniMan UI is now active");


        
        ToolSelection.hasLauncher = true;
        ToolSelection.hasMiniMan = false;

        abilityUIManager.Update();

        

        Assert.IsFalse(gogglesUI.activeSelf);
        Assert.IsFalse(miniManUI.activeSelf);
        Assert.IsTrue(platformGLUI.activeSelf, " Platform Launcher is now active");

        

        ToolSelection.hasDimensionalGoggles = true;
        ToolSelection.hasLauncher = false;

        abilityUIManager.Update(); 

        Assert.IsFalse(miniManUI.activeSelf);
        Assert.IsFalse(platformGLUI.activeSelf);
        Assert.IsTrue(gogglesUI.activeSelf, " Dimensional Goggles UI is now active");
        
    }
}
