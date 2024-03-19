using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuManager : MonoBehaviour
{
    public MenuTab[] tabs;
    public MenuCategory[] categories;
    public MenuCategory portraitCategory;
    public int currentlySelectedTab = 0;
    
    public int TAB_WIDTH = 55;
    public int SCREEN_WIDTH = 1280;
    
    // Singleton
    public static MenuManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;

        Application.targetFrameRate = 30;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Deactivate all tabs and assign the tabNumber
        int i = 0;
        foreach (var tab in tabs)
        {
            tab.tabNumber = i;
            tab.DeactiveTab();
            i++;
        }

        foreach (var category in categories)
        { 
            category.gameObject.SetActive(false);
        }
        
        // Active the portrait category if all tabs are deactivated
        portraitCategory.gameObject.SetActive(true);
    }
    
    // If a tab is activated activate the category attached to it
    public void ActivateCategory(int tabNumber)
    {
        
        portraitCategory.gameObject.SetActive(false);
        currentlySelectedTab = tabNumber;
        // Activate the category related the tab and deactivate all others
        for (int i = 0; i < categories.Length; i++)
        {
            categories[i].gameObject.SetActive(i == tabNumber);
        }
    }

    public void OnTabPressed(int tabNumber)
    {
        // Activate all tabs bellow the pressed tab
        if (tabs[tabNumber].TabActive)
        {
            if (currentlySelectedTab != tabNumber)
            {
                for(int i = tabNumber+1; i < tabs.Length; i++)
                {
                    tabs[i].DeactiveTab();
                }
            }
            else
            {
                if (tabNumber == 0)
                {
                    tabs[0].DeactiveTab();
                    categories[0].gameObject.SetActive(false);
                    portraitCategory.gameObject.SetActive(true);
                    return;
                }
            }
        }
        else
        {
            for (int i = 0; i <= tabNumber; i++)
            {
                tabs[i].ActiveTab();
            }
        }
        
        ActivateCategory(tabNumber);
    }
    
    // Function to move to the next tab
    public void MoveToNextTab()
    {
        if (currentlySelectedTab < tabs.Length - 1)
        {
            if(currentlySelectedTab == 0 && !tabs[0].TabActive)
                OnTabPressed(currentlySelectedTab);
            else
                OnTabPressed(currentlySelectedTab + 1);
        }
    }


    private void LateUpdate()
    {
        //Reload scene if pressing F5
        if (Input.GetKeyDown(KeyCode.F5))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    public void MoveToPreviousTab()
    {
        if (currentlySelectedTab > 0)
        {
            OnTabPressed(currentlySelectedTab - 1);
        }
        else
        {
            tabs[0].DeactiveTab();
            categories[0].gameObject.SetActive(false);
            portraitCategory.gameObject.SetActive(true);
        }
    }
}
