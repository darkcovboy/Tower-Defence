using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForUpgradePhoto : MonoBehaviour
{
    [SerializeField] private GameObject[] _towers;
    [SerializeField] private ParticleSystem _smoke;
    [SerializeField] private float _seconds;


    private void Start()
    {
        StartCoroutine(Upgrade());
    }

    private IEnumerator Upgrade()
    {
        for (int i = 0; i < _towers.Length; i++)
        {
            foreach (var item in _towers)
            {
                item.Deactivate();
            }

            _smoke.Play();
            _towers[i].Activate();
            yield return new WaitForSeconds(_seconds);
        }
    }
}
