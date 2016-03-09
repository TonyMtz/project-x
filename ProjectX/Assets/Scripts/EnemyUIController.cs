using UnityEngine;

public class EnemyUIController : MonoBehaviour
{
    [SerializeField]
    private TextMesh EnemyHP;

    private Character Enemy;

    // Use this for initialization
    void Start()
    {
        Enemy = transform.GetComponentInParent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        string enemyCurrentHP = Enemy.getCurrentHealthPoints().ToString();
        string enemyMaxHP = Enemy.getMaxHealthPoints().ToString();
        EnemyHP.text = "HP: " + enemyCurrentHP + "/" + enemyMaxHP;
    }
}
