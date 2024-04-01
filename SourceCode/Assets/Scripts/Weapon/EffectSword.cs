using System.Collections;
using UnityEngine;

public class EffectSword : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;

    public Vector3 Direction { get; set; }
    public float Damage { get; set; }

    private void Start()
    {
        // Bắt đầu coroutine để hủy đối tượng sau khoảng thời gian lifetime
        StartCoroutine(DestroyAfterLifetime());
    }

    private IEnumerator DestroyAfterLifetime()
    {
        // Đợi cho khoảng thời gian lifetime
        yield return new WaitForSeconds(lifetime);

        // Hủy đối tượng sau khi đã chờ đủ thời gian
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Direction * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast")) return;
        other.GetComponent<IDamageable>()?.TakeDamage(Damage);
        Destroy(gameObject);
    }
}
