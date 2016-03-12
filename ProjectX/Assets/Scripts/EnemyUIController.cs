using UnityEngine;

public class EnemyUIController : MonoBehaviour
{
    [SerializeField]
    private TextMesh EnemyHP;

    private BaseCharacter Enemy;

    // Use this for initialization
    void Start()
    {
        Enemy = transform.GetComponentInParent<BaseCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        string enemyCurrentHP = Enemy.getCurrentHealthPoints().ToString();
        string enemyMaxHP = Enemy.getMaxHealthPoints().ToString();
        EnemyHP.text = "HP: " + enemyCurrentHP + "/" + enemyMaxHP;
    }
}
