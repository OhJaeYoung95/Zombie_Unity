using UnityEngine;

// κ²μ ?μλ₯?μ¦κ??ν€???μ΄??
public class Coin : MonoBehaviour, IItem {
    public int score = 200; // μ¦κ????μ

    public void Use(GameObject target) {
        // κ²μ λ§€λ?λ‘??κ·Ό???μ μΆκ?
        GameManager.instance.AddScore(score);
        // ?¬μ©?μ?Όλ?λ‘? ?μ ???κ΄΄
        Destroy(gameObject);
    }
}