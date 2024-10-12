using UnityEngine;
using UnityEngine.VFX;

public class VFXController : MonoBehaviour
{
    public VisualEffect VFXRenderer;
    public Transform Player;

    void Update()
    {
        if (Player != null && VFXRenderer != null)
        {
            VFXRenderer.SetVector3("ColliderPos", Player.position);
        }
    }
}