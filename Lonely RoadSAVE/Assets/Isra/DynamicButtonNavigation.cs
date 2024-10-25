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
        // Verificar si currentPanel está asignado
        if (currentPanel == null)
        {
            this.enabled = false; // Desactiva el script si no se asigna el panel
            return; // Salir del método
        }

        // Verificar si los botones están asignados
        if (playButton == null || continueButton == null || settingsButton == null || exitButton == null)
        {
            Debug.LogError("Uno de los botones no está asignado en el inspector.");
            return; // Salimos si algún botón es null
        }

        UpdateButtonNavigation();
    }

    private void Update()
    {
        // Solo revisa si el panel actual está activo
        if (currentPanel != null && currentPanel.activeSelf)
        {
            // Revisa continuamente si el botón "Continue" ha cambiado su estado de interactuable
            if (continueButton.interactable != isContinueButtonActive)
            {
                // Actualiza el estado interno del botón "Continue"
                isContinueButtonActive = continueButton.interactable;

                // Actualiza la navegación cuando cambie el estado de interactuable
                UpdateButtonNavigation();
            }
        }
    }

    public void DisableNavigation()
    {
        // Desactiva la navegación
        this.enabled = false;
    }

    public void EnableNavigation()
    {
        // Vuelve a habilitar la navegación
        this.enabled = true;
        UpdateButtonNavigation(); // Actualiza la navegación al reactivar
    }

    private void UpdateButtonNavigation()
    {
        if (playButton == null || continueButton == null || settingsButton == null || exitButton == null)
        {
            Debug.LogError("Uno de los botones no está asignado en el inspector.");
            return; // Salimos si algún botón es null
        }

        // Configuración del botón "Play"
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
            // Si "Continue" no está activo, deshabilitar la navegación izquierda y derecha
            playNavigation.selectOnLeft = null;
            playNavigation.selectOnRight = null;
        }

        playButton.navigation = playNavigation;

        // Configuración del botón "Continue"
        Navigation continueNavigation = new Navigation();
        continueNavigation.mode = Navigation.Mode.Explicit;
        if (isContinueButtonActive)
        {
            continueNavigation.selectOnLeft = playButton;  // "Izquierda" -> "Play"
            continueNavigation.selectOnRight = playButton;  // "Derecha" -> "Play"
            continueNavigation.selectOnUp = null;  // Puedes ajustar si necesitas navegación arriba
            continueNavigation.selectOnDown = null;  // Puedes ajustar si necesitas navegación abajo
        }
        continueButton.navigation = continueNavigation;

        // Configuración del botón "Settings"
        Navigation settingsNavigation = new Navigation();
        settingsNavigation.mode = Navigation.Mode.Explicit;
        settingsNavigation.selectOnUp = playButton;  // "Arriba" -> "Play"
        settingsNavigation.selectOnDown = exitButton;  // "Abajo" -> "Exit"
        settingsButton.navigation = settingsNavigation;

        // Configuración del botón "Exit"
        Navigation exitNavigation = new Navigation();
        exitNavigation.mode = Navigation.Mode.Explicit;
        exitNavigation.selectOnUp = settingsButton;  // "Arriba" -> "Settings"
        exitNavigation.selectOnDown = playButton;  // "Abajo" -> "Play"
        exitButton.navigation = exitNavigation;
    }
}
