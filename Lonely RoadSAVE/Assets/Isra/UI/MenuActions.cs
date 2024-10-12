using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class MenuActions : MonoBehaviour
{
    public ImageGallery _ImageGallery;
    public TransitionScene _TransitionScene;

    private bool isTransitioning = false;

    public void Play()
    {
        if (isTransitioning) return;

        isTransitioning = true;
        _TransitionScene.StartTransition();
        StartCoroutine(WaitAndStartGallery());
    }

    IEnumerator WaitAndStartGallery()
    {
        yield return new WaitForSeconds(1f);
        _ImageGallery.PlayGallery();
        isTransitioning = false;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        _TransitionScene.StartTransition();
        SceneManager.LoadScene("ConfigScene");
        isTransitioning = false;
    }

    public void BackToMenu()
    {
        _TransitionScene.StartTransition();
        SceneManager.LoadScene("MainMenu");
        isTransitioning = false;
    }
}
