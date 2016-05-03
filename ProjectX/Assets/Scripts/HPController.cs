using UnityEngine;
using UnityEngine.UI;

// TODO - this and EnemyUIController is almost the same

public class HPController : MonoBehaviour
{


    [SerializeField]
    protected BaseCharacter character;

	public GameObject healthBar;

    // Update is called once per frame
    void Update()
    {
        string currentHP = character.getCurrentHealthPoints().ToString();
        string maxHP = character.getMaxHealthPoints().ToString();

		float cur_HP= float.Parse(currentHP); 
		float max_HP = float.Parse(maxHP); 

		float calc_health =  cur_HP/ max_HP;
		SetHealthBar (calc_health);

      
    }

	public void SetHealthBar(float myHealth){
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
		
}
