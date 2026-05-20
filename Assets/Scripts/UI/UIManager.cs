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

        buffManager.pickBuff(currentButton);

        closeLevelUpPanel();
    }

    public void closeLevelUpPanel()
    {
        LevelUpPanel.SetActive(false);
    }


    public void AssignText(Buff buff)
    {
        buffnameList[currentDescriptionIndex].text = buff.CurrentBuff.ToString();
        descriptionsList[currentDescriptionIndex].text = buff.buffDescription;
        
        currentDescriptionIndex++;
    }

    public void ResetUI()
    {
        currentDescriptionIndex = 0;
    }
}