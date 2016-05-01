using UnityEngine;

// TODO - this and HPController is almost the same

public class EnemyHPController : MonoBehaviour
{
    private BaseCharacter enemy;

    private TextMesh hpText;

    private bool isFacingLeft = true;

	public GameObject healthBar;

    // Use this for initialization
    void Start()
    {
        enemy = transform.GetComponentInParent<BaseCharacter>();
        hpText = transform.GetComponentInParent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        string currentHP = enemy.getCurrentHealthPoints().ToString();
        string maxHP = enemy.getMaxHealthPoints().ToString();

		float cur_HP= float.Parse(currentHP); 
		float max_HP = float.Parse(maxHP); 

		float calc_health =  cur_HP/ max_HP;
		SetHealthBar (calc_health);

        //hpText.text = string.Format("HP: {0}/{1}", currentHP, maxHP);

        if (enemy.IsFacingLeft() != isFacingLeft)
        {
            isFacingLeft = enemy.IsFacingLeft();
            Flip();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }

	public void SetHealthBar(float myHealth){
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
