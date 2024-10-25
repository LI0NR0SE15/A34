using UnityEngine;
using UnityEngine.UI;

public class ButtonNavigationManager : MonoBehaviour
{
    public Button playButton;
    public Button continueButton;
    public Button settingsButton;
    public Button exitButton;

    public GameObject currentPanel; // Referencia al panel actual

    private bool isContinueButtonActive;

    private void Start()
    {
        // Verificar si currentPanel est� asignado
        if (currentPanel == null)
        {
            this.enabled = false; // Desactiva el script si no se asigna el panel
            return; // Salir del m�todo
        }

        // Verificar si los botones est�n asignados
        if (playButton == null || continueButton == null || settingsButton == null || exitButton == null)
        {
            Debug.LogError("Uno de los botones no est� asignado en el inspector.");
            return; // Salimos si alg�n bot�n es null
        }

        UpdateButtonNavigation();
    }

    private void Update()
    {
        // Solo revisa si el panel actual est� activo
        if (currentPanel != null && currentPanel.activeSelf)
        {
            // Revisa continuamente si el bot�n "Continue" ha cambiado su estado de interactuable
            if (continueButton.interactable != isContinueButtonActive)
            {
                // Actualiza el estado interno del bot�n "Continue"
                isContinueButtonActive = continueButton.interactable;

                // Actualiza la navegaci�n cuando cambie el estado de interactuable
                UpdateButtonNavigation();
            }
        }
    }

    public void DisableNavigation()
    {
        // Desactiva la navegaci�n
        this.enabled = false;
    }

    public void EnableNavigation()
    {
        // Vuelve a habilitar la navegaci�n
        this.enabled = true;
        UpdateButtonNavigation(); // Actualiza la navegaci�n al reactivar
    }

    private void UpdateButtonNavigation()
    {
        if (playButton == null || continueButton == null || settingsButton == null || exitButton == null)
        {
            Debug.LogError("Uno de los botones no est� asignado en el inspector.");
            return; // Salimos si alg�n bot�n es null
        }

        // Configuraci�n del bot�n "Play"
        Navigation playNavigation = new Navigation();
        playNavigation.mode = Navigation.Mode.Explicit;
        playNavigation.selectOnUp = exitButton;  // "Arriba" -> "Exit"
        playNavigation.selectOnDown = settingsButton;  // "Abajo" -> "Settings"

        if (isContinueButtonActive)
        {
            playNavigation.selectOnLeft = continueButton;  // "Izquierda" -> "Continue"
            playNavigation.selectOnRight = continueButton;  // "Derecha" -> "Continue"
        }
        else
        {
            // Si "Continue" no est� activo, deshabilitar la navegaci�n izquierda y derecha
            playNavigation.selectOnLeft = null;
            playNavigation.selectOnRight = null;
        }

        playButton.navigation = playNavigation;

        // Configuraci�n del bot�n "Continue"
        Navigation continueNavigation = new Navigation();
        continueNavigation.mode = Navigation.Mode.Explicit;
        if (isContinueButtonActive)
        {
            continueNavigation.selectOnLeft = playButton;  // "Izquierda" -> "Play"
            continueNavigation.selectOnRight = playButton;  // "Derecha" -> "Play"
            continueNavigation.selectOnUp = null;  // Puedes ajustar si necesitas navegaci�n arriba
            continueNavigation.selectOnDown = null;  // Puedes ajustar si necesitas navegaci�n abajo
        }
        continueButton.navigation = continueNavigation;

        // Configuraci�n del bot�n "Settings"
        Navigation settingsNavigation = new Navigation();
        settingsNavigation.mode = Navigation.Mode.Explicit;
        settingsNavigation.selectOnUp = playButton;  // "Arriba" -> "Play"
        settingsNavigation.selectOnDown = exitButton;  // "Abajo" -> "Exit"
        settingsButton.navigation = settingsNavigation;

        // Configuraci�n del bot�n "Exit"
        Navigation exitNavigation = new Navigation();
        exitNavigation.mode = Navigation.Mode.Explicit;
        exitNavigation.selectOnUp = settingsButton;  // "Arriba" -> "Settings"
        exitNavigation.selectOnDown = playButton;  // "Abajo" -> "Play"
        exitButton.navigation = exitNavigation;
    }
}
