using UnityEngine;

public class Entity : MonoBehaviour
{
    public int max_health = 100;
    public int health{get; private set;}

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
    }
    public void GetHealth(int ammount){
        health += ammount;
        health = Mathf.Min(health, max_health);
    }
    public float GetPercent(){return health/(float)max_health;}
    void DestroyEntity()
    {
        // Hiệu ứng hủy (nếu cần)
        Destroy(gameObject);
    }
    public void SetMaxHealth(int max_health){
        this.max_health = max_health;
        health = max_health;
    }
}
