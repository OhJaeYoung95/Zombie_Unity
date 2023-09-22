using UnityEngine;

// 게임 ?�수�?증�??�키???�이??
public class Coin : MonoBehaviour, IItem {
    public int score = 200; // 증�????�수

    public void Use(GameObject target) {
        // 게임 매니?��??�근???�수 추�?
        GameManager.instance.AddScore(score);
        // ?�용?�었?��?�? ?�신???�괴
        Destroy(gameObject);
    }
}