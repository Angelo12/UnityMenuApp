using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuTab : MonoBehaviour
{
    public Image bg;

    public bool TabActive = false;
    private Vector3 startingRightPosition;
    private Vector3 activePosition;
    public int tabNumber;
    public RectTransform rectTransform;
    
    private void Awake()
    {
        startingRightPosition = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        TabActive = false;
    }
    
    // Menu will call ActiveTab() when this tab or others above it are pressed
    // If this tab was already active do nothing
    // If activating for the first time move the tab to the left
    public void ActiveTab()
    {
        if (TabActive)
        {
            //DeactiveTab();
            return;
        }
        
        TabActive = true;
        // Move the tab to the left. The left position is equal to half the tab width + the width times the tab number
        var newX = (-612.5f) + (MenuManager.Instance
            .TAB_WIDTH * tabNumber);
        
        transform.DOLocalMoveX(newX, 0.5f);
    }
    
    //Deactivate the tab
    // Return the tab to its starting position
    public void DeactiveTab()
    {
        if(!TabActive) return;
        
        TabActive = false;
        var newX = (282.5f + (MenuManager.Instance
            .TAB_WIDTH * tabNumber));
        transform.DOLocalMoveX(newX, 0.5f);
    }

    public void TabPressed()
    {
        MenuManager.Instance.OnTabPressed(tabNumber);
    }
}
