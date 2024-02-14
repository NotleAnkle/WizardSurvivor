using _Framework.Event.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InforDisplay : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image[] icons;
    [SerializeField ] private Image expBar;

    private int hpIndex;

    private void Awake()
    {
        this.RegisterListener(EventID.OnPlayerIncreaseHp, (param) => HpUp());
        this.RegisterListener(EventID.OnPlayerHit, (param) => HpDown());
        this.RegisterListener(EventID.OnPlayerExpUp, (param) => ExpUp());
    }

    private void Start()
    {
        hpIndex = 0;
        for(int i = 0; i < player.HP; i++)
        {
            HpUp();
        }
        ExpUp();
    }

    public void HpUp()
    {
        icons[hpIndex].enabled = true;
        hpIndex++;
    }

    public void HpDown()
    {
        hpIndex--;
        icons[hpIndex].enabled = false;
    }

    public void ExpUp()
    {
        expBar.fillAmount = player.CurExp / player.NeedExp;
    }
}
