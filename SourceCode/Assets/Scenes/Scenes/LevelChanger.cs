using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private LevelConnection _connection;

    [SerializeField]
    private string _targetScenceName;

    [SerializeField]
    private Transform _spawnPoint;

    [SerializeField]
    private SaveController saveController;

    private void Awake()
    {
        saveController.GetComponent<SaveController>();
    }

    private void Start()
    {
        try
        {
            if (_connection == LevelConnection.ActiveConnection)
            {
                FindObjectOfType<Player>().transform.position = _spawnPoint.position;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("An error occurred while setting player position: " + e.Message);
            // Xử lý lỗi tại đây, ví dụ: 
            // - Hiển thị thông báo lỗi cho người chơi
            // - Khởi tạo vị trí mặc định cho người chơi
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();
        if (player != null)
        {
            
            if(Transition.Instance != null)
            {
                Transition.Instance.LoadNextLevel();
            }
            Invoke("LoadLevel", 1f);
        }
    }
    public void LoadLevel()
    {
        LevelConnection.ActiveConnection = _connection;
        saveController.SaveGameState();
        SceneManager.LoadScene(_targetScenceName);
    }
}
