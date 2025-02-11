using UnityEngine;

public class Entity : MonoBehaviour
{
    public int max_health = 100;
    public int health{get; private set;}
    [HideInInspector] public float percent = 1;

    void Start()
    {
        health = max_health; // Khởi tạo máu đầy khi bắt đầu
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            DestroyEntity();
        }
        percent = health/max_health;
    }

    void DestroyEntity()
    {
        // Hiệu ứng hủy (nếu cần)
        Destroy(gameObject);
    }
}
