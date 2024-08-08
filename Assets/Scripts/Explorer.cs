using UnityEngine.SceneManagement;
using UnityEngine;

public class Explorer : MonoBehaviour
{
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Goto(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Goto(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }

    public void SLAsyncNext()
    {
    }

    public void SLAsyncBack()
    {
    }

    public void SLAsyncReload()
    {
    }

    public void SLAsyncGoto(string scene)
    {
    }

    public void SLAsyncGoto(int sceneIndex)
    {
    }

    public void AsyncNext()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
    }

    public void AsyncGoTo(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    }

    public void AsyncClose()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void AsyncOpenScene(int index)
    {
        SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    }


    public void AsyncCloseScene(int sceneIndex)
    {
    }

    public void AsyncCloseScene(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }
}