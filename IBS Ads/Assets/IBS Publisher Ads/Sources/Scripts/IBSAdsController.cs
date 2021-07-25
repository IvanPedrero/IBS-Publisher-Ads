using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AdPresenter))]
public class IBSAdsController : MonoBehaviour
{
    [Header("URLs used for each plataform: ")]
    public string androidURL = "https://play.google.com/store/apps/developer?id=Indie+Bonus+Stage";
    public string iosURL = "https://apps.apple.com/co/developer/marco-ricardo-sanchez-guadarrama/id865207642";
    public string defaultURL = "http://indiebonusstage.com/juegos-publicados";

    [Header("Should the ad be shown randomly without interaction when scene loads?")]
    public bool showRandomly = false;
    [Range(0.0F, 1.0F)]
    public float probabilityOfShowing = 0.3F;

    private AdPresenter adPresenter;

    void Awake()
    {
        adPresenter = GetComponent<AdPresenter>();

        if (showRandomly)
        {
            CalculateProbabilityOfShowing();
        }
    }

    private void CalculateProbabilityOfShowing()
    {
        var probability = Random.value;
        
        if (probability <= probabilityOfShowing)
        {
            ShowAd();
        }
    }

    public void ShowAd()
    {
        adPresenter.CreateAd();
    }

    public void OpenURL()
    {
#if UNITY_ANDROID
        var urlToUse = androidURL;
#elif UNITY_IOS
        var urlToUse = iosURL;
#else
        var urlToUse = defaultURL;
#endif
        Application.OpenURL(urlToUse);
    }
}
