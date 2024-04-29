using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button button;  
	public SaveController saveController;
	// Use this for initialization
	void Start()
	{
		saveController = saveController.GetComponent<SaveController>();
        button = button.GetComponent<Button>();
		CheckSaveGame();
        Debug.Log(button);
	}

	public void CheckSaveGame()
	{
        if (PlayerPrefs.HasKey("CurrentScene"))
        {
            button.interactable = true; // Nếu có dữ liệu đã được lưu, cho phép tương tác với button
            //button.gameObject.SetActive(true); // Hiển thị button
            Debug.Log("Data exists in PlayerPrefs.");
        }
        else
        {
            button.interactable = false; // Nếu có dữ liệu đã được lưu, cho phép tương tác với button
            //button.gameObject.SetActive(false); // Hiển thị button
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
    }

	public void Exit()
	{
        // Xoá tất cả dữ liệu trong PlayerPrefs
        //PlayerPrefs.DeleteAll();
        // Kiểm tra xem khóa "CurrentScene" có tồn tại trong PlayerPrefs không
        if (PlayerPrefs.HasKey("CurrentScene"))
        {
            // Khóa tồn tại, có dữ liệu được lưu trữ
            Debug.Log("Data exists in PlayerPrefs.");
        }
        else
        {
            // Khóa không tồn tại, không có dữ liệu được lưu trữ
            Debug.Log("No data found in PlayerPrefs.");
        }
    }
}

