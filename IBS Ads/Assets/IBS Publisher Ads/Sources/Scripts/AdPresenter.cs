using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IBSAdController))]
public class AdPresenter : MonoBehaviour
{
    public GameObject adContentPrefab;

    private AdAnimator adAnimator;

    public void CreateAd()
    {
        if(adAnimator) { return; }

        var adContent = Instantiate(adContentPrefab, Vector3.zero, Quaternion.identity);

        adAnimator = adContent.GetComponent<AdAnimator>();
        adAnimator.adPresenter = this;
        adAnimator.ShowAd();
    }

    public void RemoveAd()
    {
        if(!adAnimator) { return; }

        Destroy(adAnimator.gameObject);
    }
}
