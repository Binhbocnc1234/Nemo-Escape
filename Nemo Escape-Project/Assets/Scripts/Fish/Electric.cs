using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : Fish
{
    Timer cooldownTimer; // Hồi chiêu giữa các lần giật
    Timer shockTimer;    // Khoảng thời gian giật (0.5s)
    public float radius = 1f;
    float cooldownTime = 3f;
    float shockDuration = 0.5f;
    private bool isShocking = false; // Kiểm tra xem có đang giật hay không

    public override void Start()
    {
        cooldownTimer = new Timer(cooldownTime);
        shockTimer = new Timer(shockDuration);
    }

    public override void Attack()
    {
        base.Attack();

        if (isShocking)
        {
            // Nếu vẫn đang trong quá trình giật, kiểm tra xem đã hết 0.5s chưa
            if (shockTimer.Count())
            {
                Player.Instance.speed = Player.Instance.speed_raw; // Phục hồi tốc độ
                isShocking = false; // Kết thúc quá trình giật
                cooldownTimer.Reset(); // Bắt đầu hồi chiêu
            }
            return; // Không thực hiện thêm gì khi đang giật
        }

        // Nếu cooldown đã kết thúc và người chơi ở trong phạm vi
        if (cooldownTimer.Count(false) && Vector3.Distance(Player.Instance.transform.position, this.transform.position) <= radius)
        {
            Player.Instance.speed = 0f; // Gây tê liệt người chơi
            isShocking = true; // Đánh dấu đang giật
            shockTimer.Reset(); // Bắt đầu tính thời gian giật
        }
    }
}
