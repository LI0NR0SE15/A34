using System.Collections;
using UnityEngine;

public class TransitionScene : MonoBehaviour
{
    private Animator _Animator;
    public GameObject TransitionPanel;
    [SerializeField] private AnimationClip _FinalTransition;

    void Start()
    {
        _Animator = GetComponent<Animator>();
    }

    public void StartTransition()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        _Animator.SetTrigger("Open");
        yield return new WaitForSeconds(_FinalTransition.length);
        TransitionPanel.SetActive(false);
    }
}