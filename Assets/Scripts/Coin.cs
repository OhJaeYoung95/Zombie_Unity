using UnityEngine;

// ê²Œì„ ?ìˆ˜ë¥?ì¦ê??œí‚¤???„ì´??
public class Coin : MonoBehaviour, IItem {
    public int score = 200; // ì¦ê????ìˆ˜

    public void Use(GameObject target) {
        // ê²Œì„ ë§¤ë‹ˆ?€ë¡??‘ê·¼???ìˆ˜ ì¶”ê?
        GameManager.instance.AddScore(score);
        // ?¬ìš©?˜ì—ˆ?¼ë?ë¡? ?ì‹ ???Œê´´
        Destroy(gameObject);
    }
}