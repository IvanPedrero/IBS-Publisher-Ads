using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdAnimator : MonoBehaviour
{
    public GameObject content;

    [HideInInspector] public AdPresenter adPresenter;
    private Animator animator;
    private bool canAnimate = true;

    private const string SHOW_TRIGGER = "show";
    private const string HIDE_TRIGGER = "hide";

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowAd()
    {
        if (!canAnimate) { return; }

        animator.SetTrigger(SHOW_TRIGGER);
    }

    public void HideAd()
    {
        if (!canAnimate) { return; }

        animator.SetTrigger(HIDE_TRIGGER);
    }

    public void RedirectToURL() {
        GameObject.FindObjectOfType<IBSAdController>().OpenURL();
    }

    public void DisableAnimatorTriggers()
    {
        canAnimate = false;
    }

    public void EnableAnimatorTriggers()
    {
        canAnimate = true;
    }

    public void FinishShowingAd() {
        EnableAnimatorTriggers();
        adPresenter.RemoveAd();
    }
}
