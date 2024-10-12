using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ImageGallery : MonoBehaviour
{
    public float TransitionTime = 1f;

    public Sprite[] Images;
    public Image DisplayImage;
    public Button[] SceneButtons;
    public GameObject GalleryPanel;

    private AsyncOperation asyncLoad;

    void Start()
    {
        GalleryPanel.SetActive(false);
    }

    public void PlayGallery()
    {
        GalleryPanel.SetActive(true);
        SetButtonsInteractable(false);
        StartCoroutine(LoadSceneAndShowGallery());
    }

    private IEnumerator LoadSceneAndShowGallery()
    {
        asyncLoad = SceneManager.LoadSceneAsync(1);
        asyncLoad.allowSceneActivation = false;

        int CurrentIndex = 0;
        bool SceneLoaded = false;

        while (CurrentIndex < Images.Length)
        {
            DisplayImage.sprite = Images[CurrentIndex];
            yield return StartCoroutine(FadeIn());
            yield return new WaitForSeconds(TransitionTime);
            yield return StartCoroutine(FadeOut());

            CurrentIndex++;

            if (asyncLoad.isDone)
            {
                SceneLoaded = true;
                break;
            }

            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
                yield break;
            }
        }

        if (!SceneLoaded)
        {
            asyncLoad.allowSceneActivation = true;
        }

        SetButtonsInteractable(true);
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = DisplayImage.color;

        while (elapsedTime < TransitionTime)
        {
            color.a = Mathf.Lerp(1, 0, elapsedTime / TransitionTime);
            DisplayImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = 0;
        DisplayImage.color = color;
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = DisplayImage.color;

        while (elapsedTime < TransitionTime)
        {
            color.a = Mathf.Lerp(0, 1, elapsedTime / TransitionTime);
            DisplayImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        color.a = 1;
        DisplayImage.color = color;
    }

    private void SetButtonsInteractable(bool isInteractable)
    {
        foreach (Button button in SceneButtons)
        {
            button.interactable = isInteractable;
        }
    }
}