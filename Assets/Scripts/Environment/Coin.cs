using UnityEngine;

public class Coin : MonoBehaviour
{
    public int count = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            GameManager.Instance.AddCoinCount(count);
        }
    }
}
