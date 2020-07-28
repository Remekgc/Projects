using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    [SerializeField] bool updateUI = true;
    [SerializeField] TextMeshProUGUI playerHealthUI;
    [SerializeField] public TextMeshProUGUI gunNameUI;
    [SerializeField] List<GameObject> enableOnDeath = new List<GameObject>();
    [SerializeField] List<GameObject> disableOnDeath = new List<GameObject>();
    [SerializeField] List<GameObject> onPause = new List<GameObject>();
    [SerializeField] List<GameObject> onWin = new List<GameObject>();

    bool isPaused = false;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Start()
    {
        GameManager.Instance.UI_controller = this;
    }

    void Update()
    {
        UpdateUI();
        ManageKeyInput();
    }

    private void ManageKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && updateUI)
        {
            PauseGame();
        }
    }

    private void UpdateUI()
    {
        if (updateUI)
        {
            playerHealthUI.text = playerStats.hitPoints.ToString();
        }
    }

    public void SetGameObjectListState(bool state, List<GameObject> gameObjects)
    {
        foreach (var item in gameObjects)
        {
            item.SetActive(state);
        }
    }

    public void EndGame(bool win)
    {
        if (win)
        {
            SetGameObjectListState(true, onWin);
            SetGameObjectListState(false, disableOnDeath);
        }
        else
        {
            SetGameObjectListState(true, enableOnDeath);
            SetGameObjectListState(false, disableOnDeath);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        updateUI = false;
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        SetGameObjectListState(isPaused, onPause);
        Cursor.visible = isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }

    public void UpdateGun(RaycastWeapon raycastWeapon)
    {
        gunNameUI.text = raycastWeapon.name;
    }

}
