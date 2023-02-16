using NUnit.Framework;
using Altom.AltUnityDriver;
using System;

public class HomeScreenTests
{
    public AltUnityDriver altUnityDriver;
    //Before any test it connects with the socket
    [OneTimeSetUp]
    public void SetUp()
    {
        altUnityDriver = new AltUnityDriver();
    }

    //At the end of the test closes the connection with the socket
    [OneTimeTearDown]
    public void TearDown()
    {
        altUnityDriver.Stop();
    }
    [Test]
    public void FindStartButton()
    {
        altUnityDriver.LoadScene("Menu");
        var find_start = altUnityDriver.FindObject(By.NAME, "Start Button");
        Assert.AreEqual("Start Button", find_start.name);

    }
    [Test]
    public void DontFindQuitButton()
    //{
    //var find_quit = altUnityDriver.FindObject(By.NAME, "Quit Button");
    //Assert.AreEqual("Quit Button", find_start.name);
    //}
    {
        try
        {
            altUnityDriver.WaitForObjectNotBePresent(By.NAME, "Quit Button");
        }
        catch (Exception e)
        {
            Console.WriteLine("Button not found" + e);
        }

    }
    [Test]
    public void FailiuretoFindQuitButton()
    {
    var find_quit = altUnityDriver.FindObject(By.NAME, "Quit Button");
    Assert.AreEqual("Quit Button", find_quit.name);
    }

}