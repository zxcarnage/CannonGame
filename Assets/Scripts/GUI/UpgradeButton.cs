using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private CannonStats _stats;
    [SerializeField] private int _killRequirenment;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _reqText;
    [Space(10)] [Header("Additional stats to cannon")]
    [SerializeField] private float _bulletSpeedAdd;
    [SerializeField] private float _bulletDamageAdd;
    [SerializeField] private float _delayDecrease;
    
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(TryUpgradeCannon);
        ChangeCounter();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TryUpgradeCannon);
    }

    private void ChangeCounter()
    {
        _reqText.text = Convert.ToString(_killRequirenment);
    }

    private void TryUpgradeCannon()
    {
        if(_player.Score >= _killRequirenment)
            UpgradeCannon();
    }

    private void UpgradeCannon()
    {
        _stats.BulletDamage += _bulletDamageAdd;
        _stats.BulletSpeed += _bulletSpeedAdd;
        _stats.ShootDelay -= _delayDecrease > 0.1 ? _delayDecrease : 0;
        _killRequirenment += _killRequirenment / 2;
        ChangeCounter();
    }
}