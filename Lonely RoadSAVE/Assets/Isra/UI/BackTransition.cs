using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Aseg�rate de incluir este namespace

public class BackTransition : MonoBehaviour
{
    public Button settingsButton;  // Bot�n que desencadena la transici�n
    public GameObject currentPanel;  // Panel actual que se va a desvanecer
    public GameObject newPanel;  // Panel nuevo que va a aparecer
    public Button defaultButton; // Bot�n que se seleccionar� al abrir el nuevo panel
    public float fadeDuration = 1f;  // Duraci�n de la transici�n

    private void Start()
    {
        // Al inicio, aseg�rate de que el nuevo panel est� invisible y desactivado
        SetPanelAlpha(newPanel, 0f);
        newPanel.SetActive(false);

        // A�ade el listener para activar la transici�n al hacer clic en el bot�n
        settingsButton.onClick.AddListener(() => StartCoroutine(SwitchPanels()));
    }

    private IEnumerator SwitchPanels()
    {
        // Verifica si el panel actual est� activo
        if (!currentPanel.activeSelf)
        {
            yield break; // Si no est� activo, salimos del m�todo
        }

        // Desvanecer el panel actual
        yield return StartCoroutine(FadeOut(currentPanel));

        // Desactivar el panel actual y activar el nuevo
        currentPanel.SetActive(false);
        newPanel.SetActive(true);

        // Mostrar el nuevo panel
        yield return StartCoroutine(FadeIn(newPanel));

        // Seleccionar el bot�n predeterminado
        EventSystem.current.SetSelectedGameObject(defaultButton.gameObject);
        defaultButton.Select(); // Selecciona el bot�n
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
