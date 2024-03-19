using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class MenuCategory : MonoBehaviour
{
    public Image[] pages;

    private int currentlySelectedPage = 0;
    
    public GameObject scrollViewObject;
    public GameObject scrollViewContent;

    public Image scrollBarBG;
    public Image scrollBarHandle;
    
    public float fadeTime = 0.5f;
    public Ease easeType = Ease.Linear;

    private void OnEnable()
    {
        scrollViewObject.gameObject.SetActive(true);
        currentlySelectedPage = 0;
        //Scroll the view to the top
        scrollViewContent.transform.localPosition = new Vector3(0, 0, 0);
        //Set the alpha of all pages to 0
        foreach (var page in pages)
        {
            page.DOFade(0, 0);
        }
        //Set the alpha of the scroll bar to 0
        scrollBarBG.DOFade(0, 0);
        scrollBarHandle.DOFade(0, 0);
        
        //Animate the alpha of all the pages to 1
        foreach (var page in pages)
        {
            page.DOFade(1, fadeTime).SetEase(easeType);
        }
        
        // Animate the alpha of the scroll bar and the handle to 1 after the pages have finished animating
        scrollBarBG.DOFade(1, 0.5f).SetEase(Ease.OutCubic).SetDelay(fadeTime*0.5f);
        scrollBarHandle.DOFade(1, 0.5f).SetEase(Ease.OutCubic).SetDelay(fadeTime*0.5f);
        
    }

    private void OnDisable()
    {
        //Kill tweens
        foreach (var page in pages)
        {
            page.DOKill();
        }
    }
}
