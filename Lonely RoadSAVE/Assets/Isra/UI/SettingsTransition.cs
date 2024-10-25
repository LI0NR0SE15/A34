using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuTransition : MonoBehaviour
{
    public Button settingsButton;         // Bot�n que va a abrir el men� de configuraciones
    public Button backButton;             // Bot�n que va a volver al men� principal
    public GameObject mainMenu;           // Panel del men� principal
    public GameObject settingsMenu;       // Panel del men� de configuraciones
    public Slider defaultSlider;          // Slider que se seleccionar� al abrir el nuevo panel
    public float fadeDuration = 1f;       // Duraci�n de la transici�n

    private void Start()
    {
        // Al inicio, aseg�rate de que el men� de configuraciones est� invisible y desactivado
        SetPanelAlpha(settingsMenu, 0f);
        settingsMenu.SetActive(false);

        // A�ade listeners para activar las transiciones
        settingsButton.onClick.AddListener(() => StartCoroutine(SwitchPanels(mainMenu, settingsMenu, defaultSlider)));
        backButton.onClick.AddListener(() => StartCoroutine(SwitchPanels(settingsMenu, mainMenu, settingsButton)));
    }

    private IEnumerator SwitchPanels(GameObject fromPanel, GameObject toPanel, Selectable selectableToFocus)
    {
        // Verifica si el panel de origen est� activo
        if (!fromPanel.activeSelf)
        {
            yield break; // Si no est� activo, salimos del m�todo
        }

        // Desvanecer el panel actual
        yield return StartCoroutine(FadeOut(fromPanel));

        // Desactivar el panel actual y activar el nuevo
        fromPanel.SetActive(false);
        toPanel.SetActive(true);

        // Mostrar el nuevo panel
        yield return StartCoroutine(FadeIn(toPanel));

        // Seleccionar el slider predeterminado
        EventSystem.current.SetSelectedGameObject(selectableToFocus.gameObject);
        selectableToFocus.Select(); // Selecciona el slider
    }

    private IEnumerator FadeOut(GameObject panel)
    {
        float alpha = 1f;  // Partimos del alfa completo (visible)

        // Gradualmente disminuimos el alfa
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime / fadeDuration;
            SetPanelAlpha(panel, alpha);
            yield return null;
        }

        // Asegurarse de que sea completamente invisible
        SetPanelAlpha(panel, 0f);
    }

    private IEnumerator FadeIn(GameObject panel)
    {
        float alpha = 0f;  // Partimos de alfa 0 (invisible)

        // Gradualmente aumentamos el alfa
        while (alpha < 1f)
        {
            alpha += Time.deltaTime / fadeDuration;
            SetPanelAlpha(panel, alpha);
            yield return null;
        }

        // Asegurarse de que sea completamente visible
        SetPanelAlpha(panel, 1f);
    }

    // M�todo para establecer la transparencia de todos los elementos en un panel
    private void SetPanelAlpha(GameObject panel, float alpha)
    {
        // Cambiar el alfa de todos los componentes Image
        Image[] images = panel.GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }

        // Cambiar el alfa de todos los componentes Text
        Text[] texts = panel.GetComponentsInChildren<Text>();
        foreach (Text text in texts)
        {
            Color color = text.color;
            color.a = alpha;
            text.color = color;
        }
    }
}
