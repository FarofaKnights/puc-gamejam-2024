using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public enum HaikouType { One, Two }

    public static UIController instance;

    public GameObject haikou1El, haikou2El, haikouPanel;
    public Text haikouText;


    public TextScriptable firstTexts, lastTexts;
    TextScriptable currentTexts;
    int currentTextIndex = 0;

    float allowHaikouSkipTimer = 0.5f;
    float allowHaikouSkipTimerCurrent = 0.0f;


    void Awake() {
        instance = this;
    }

    void FixedUpdate() {
        if (currentTexts == null) return;

        allowHaikouSkipTimerCurrent -= Time.fixedDeltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space)) {
            NextHaikou();
        }


    }


    public void ShowHaikou(string text, HaikouType type) {
        Debug.Log("ShowHaikou");
        // Time.timeScale = 0;
        haikouPanel.SetActive(true);

        GameObject haikouEl = type == HaikouType.One ? haikou1El : haikou2El;
        haikouEl.SetActive(true);
        // StartCoroutine(HideHaikou(haikouEl)); NOT HIDE MAYBE SHOW NEXT ARROW

        currentTexts = type == HaikouType.One ? firstTexts : lastTexts;
        currentTextIndex = 0;

        haikouText.text = currentTexts.texts[currentTextIndex].text;
    }

    public void NextHaikou() {
        if (currentTexts == null) return;
        if (allowHaikouSkipTimerCurrent > 0.0f) return;
        allowHaikouSkipTimerCurrent = allowHaikouSkipTimer;
        Debug.Log("NextHaikou");
        currentTextIndex++;
        if (currentTextIndex >= currentTexts.texts.Count) {
            haikouPanel.SetActive(false);
            currentTexts = null;
            return;
        }

        haikouText.text = currentTexts.texts[currentTextIndex].text;
    }
}
