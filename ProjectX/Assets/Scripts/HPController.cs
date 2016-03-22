using UnityEngine;
using UnityEngine.UI;

// TODO - this and EnemyUIController is almost the same

public class HPController : MonoBehaviour
{
    [SerializeField]
    private Text hpText = null;

    [SerializeField]
    protected BaseCharacter character;

    // Update is called once per frame
    void Update()
    {
        string currentHP = character.getCurrentHealthPoints().ToString();
        string maxHP = character.getMaxHealthPoints().ToString();

        hpText.text = string.Format("HP: {0}/{1}", currentHP, maxHP);
    }
}
