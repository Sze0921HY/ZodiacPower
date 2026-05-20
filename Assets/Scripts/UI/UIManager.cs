using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    public GameObject LevelUpPanel;
    public List<Button> buttonList;
    public List<TextMeshProUGUI> buffnameList;
    public List<TextMeshProUGUI> descriptionsList;
    

    //References
    [SerializeField]
    private BuffManager buffManager;




    public int currentDescriptionIndex = 0;

    private void Awake()
    {
        buffManager = GetComponent<BuffManager>();
        updatePointUI(0);
    }

    void Start()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            int index = i;
            buttonList[i].onClick.AddListener(() => buttonClick(index));
        }
    }

    public void showLevelUpPanel()
    {
        //before showing the canvas thing, this checks to see if we have any buffs or not
        bool hasBuff = buffManager.levelUp();
        if (!hasBuff)
        {
            Debug.Log("No more buffs to offer");
            return;
        }
        LevelUpPanel.SetActive(true);
        Time.timeScale = 0f;
        buffManager.levelUp();
        
    }

    public void updatePointUI(float point)
    {
        pointText.text = point.ToString();
    }

    public void buttonClick(int currentButton)
    {
        Debug.Log("Current Button:" + currentButton);

        bool success = buffManager.pickBuff(currentButton);

        if (success)
        {
            closeLevelUpPanel();
        }
    }

    public void closeLevelUpPanel()
    {
        LevelUpPanel.SetActive(false);
    }

    //assigns the text and image of the button based on the buff that is being offered, using the index to determine which button to change <-- copilot made this comment for me
    public void AssignText(int index, Buff buff)
    {
        buffnameList[index].text = buff.CurrentBuff.ToString();

        descriptionsList[index].text = buff.buffDescription;

        iconList[index] = buff.sprite; 

    }
    //changes the UI back to default state, making all buttons active and resetting the description index because it wasn't accurate after how i changed it
    public void ResetUI()
    {
        currentDescriptionIndex = 0;

        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].gameObject.SetActive(true);
        }
    }

    public void HideUnusedButtons(int activeCount)
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].gameObject.SetActive(i < activeCount);
        }
    }
}