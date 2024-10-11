using Karin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tkfkadlsi
{
    public class EnforceTech : MonoBehaviour
    {
        [SerializeField] private List<CharacterSO> changeSOs;

        [SerializeField] private float plusMaxHealth = 0f;
        [SerializeField] private float plusAttack = 0f;
        [SerializeField] private float plusRange = 0f;
        [SerializeField] private float plusAttackSpeed = 0f;

        //µð¹ö±ë¿ë ÄÚµå

        float maxHealth;
        float atk;
        float range;
        float atkSpeed;

        private void Awake()
        {
                if (changeSOs.Count == 0) return;
            foreach (CharacterSO so in changeSOs)
            {
                if (so == null)
                {
                    Debug.Log("¾Æ´Ï ¹Ù²Ü SO ¾È³Ö¾úÀÝ¾Æ!!!!!!!");
                    return;
                }

                maxHealth = so.maxHealth;
                atk = so.atk;
                range = so.range;
                atkSpeed = so.atkspeed;
            }
            
        }

        private void OnDestroy()
        {
                if(changeSOs.Count == 0) return;
            foreach(CharacterSO so in changeSOs)
            {
                if (so == null)
                {
                    Debug.Log("¾Æ´Ï ¹Ù²Ü SO ¾È³Ö¾úÀÝ¾Æ!!!!!!!");
                    return;
                }

                so.maxHealth = maxHealth;
                so.atk = atk;
                so.range = range;
                so.atkspeed = atkSpeed;

            }
        }

        //µð¹ö±ë¿ë ÄÚµå ³¡

        public void Activated()
        {
            if (changeSOs.Count == 0)
            {
                Debug.Log("¾Æ´Ï ¹Ù²Ü SO ¾È³Ö¾úÀÝ¾Æ!!!!!!!");
                return;
            }

            foreach (CharacterSO so in changeSOs)
            {
                if(so == null)
                {
                    Debug.Log("¾Æ´Ï ¹Ù²Ü SO ¾È³Ö¾úÀÝ¾Æ!!!!!!!");
                    return;
                }

                so.maxHealth += plusMaxHealth;
                so  .atk += plusAttack;
                so.range += plusRange;
                so.atkspeed -= plusAttackSpeed;
            }
        }
    }
}
