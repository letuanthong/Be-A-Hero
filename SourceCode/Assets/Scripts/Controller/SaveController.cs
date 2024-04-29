using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveController : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    public PlayerStats Stats => stats;
    public Button button;

    private void Awake()
    {
        button = button.GetComponent<Button>();
        HasSavedData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveGameState();
            Debug.Log("SaveDone");
        }
    }

    public void HasSavedData()
    {
        if (PlayerPrefs.HasKey("CurrentScene"))
        {
            button.interactable = true; // Nếu có dữ liệu đã được lưu, cho phép tương tác với button
            button.gameObject.SetActive(true); // Hiển thị button
            Debug.Log("Data exists in PlayerPrefs.");
        }
        else
        {
            button.interactable = false; // Nếu có dữ liệu đã được lưu, cho phép tương tác với button
            button.gameObject.SetActive(false); // Hiển thị button
        }
    }

    private void OnApplicationQuit()
    {
        SaveGameState(); // Lưu trạng thái khi game thoát
    }

    public void SaveGameState()
    {
        // Lưu scene hiện tại
        PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save(); // Lưu trạng thái
    }

    public void LoadGameState()
    {
        // Kiểm tra xem có dữ liệu lưu trạng thái không
        if (PlayerPrefs.HasKey("CurrentScene"))
        {
            // Tải scene hiện tại
            string currentScene = PlayerPrefs.GetString("CurrentScene");
            SceneManager.LoadScene(currentScene);
            Debug.Log("LoadGame");

        }
        else
        {
            SceneManager.LoadScene("OpeningScene");
            Debug.Log("NewGame");
        }   
    }

    public void NewGame()
    {
        stats.ResetPlayer();
        SceneManager.LoadScene("OpeningScene");
    }

    public void ExitGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
