using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Animator animatorUI;

    [SerializeField] bool updateUI = true;
    [SerializeField] protected TextMeshProUGUI playerHealthUI;
    public TextMeshProUGUI gunNameUI;
    public TextMeshProUGUI ammoUI;
    public TextMeshProUGUI killsUI;
    public TextMeshProUGUI warningUI;
    [SerializeField] List<GameObject> enableOnDeath = new List<GameObject>();
    [SerializeField] List<GameObject> disableOnDeath = new List<GameObject>();
    [SerializeField] List<GameObject> onPause = new List<GameObject>();
    [SerializeField] List<GameObject> onWin = new List<GameObject>();

    bool isPaused = false;

    void Awake()
    {
        if (!animatorUI) animatorUI = GetComponent<Animator>();
    }

    void Start()
    {
        if (!playerStats) playerStats = FindObjectOfType<PlayerStats>();
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
        if (updateUI && playerStats)
        {
            playerHealthUI.text = playerStats.hitPoints.ToString();
            UpdateAmmo();
        }
        else if (!playerStats)
        {
            playerStats = GameManager.Instance.player.GetComponent<PlayerStats>();
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

    public void UpdateAmmo()
    {
        ammoUI.text = playerStats.inventory.ammo.GetCurrentAmmo(playerStats.inventory.activeWeapon.getAmmoType()).ToString();
    }

    public void UpdateKills()
    {
        killsUI.text = (int.Parse(killsUI.text) + 1).ToString();
    }

    public void PlayDamagedAnimation()
    {
        animatorUI.SetTrigger("damaged");
    }

    public void ToggleWarning(bool enabled)
    {
        warningUI.gameObject.SetActive(enabled);
    }

}
