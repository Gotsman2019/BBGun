﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;
/*
 * This script takes damage from various body parts, multiplies it, and passes it onto the Health Script.
 * 
 * */

namespace TacticalAI
{
    public class HitBox : MonoBehaviour
    {
        public float damageMultiplyer = 1;
        private Vector3 addForceVector;

        private Rigidbody myRigidBody;
        public TacticalAI.HealthScript myScript;
        public bool canDoSingleHealthBoxDamage = true;

        [HideInInspector]
        public float damageTakenThisFrame = 0;
        //public bool storeDamage = false;

        void Awake()
        {
            myRigidBody = gameObject.GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            //UFPS 2 support.  Only need for UFPS 2.
#if FIRST_PERSON_CONTROLLER && ULTIMATE_CHARACTER_CONTROLLER_SHOOTER
            Opsive.UltimateCharacterController.Events.EventHandler.RegisterEvent<float, Vector3, Vector3, GameObject, Collider>(gameObject, "OnObjectImpact", OnImpact);
#endif
        }

        //UFPS 2 SUPPORT
        void OnDisable()
        {
#if FIRST_PERSON_CONTROLLER && ULTIMATE_CHARACTER_CONTROLLER_SHOOTER
            Opsive.UltimateCharacterController.Events.EventHandler.UnregisterEvent<float, Vector3, Vector3, GameObject, Collider>(gameObject, "OnObjectImpact", OnImpact);
#endif
        }

        void OnImpact(float amount, Vector3 position, Vector3 direction, GameObject attacker, Collider hitCollider)
        {
            ApplyDamage(amount);
            StartCoroutine(AddForceVector(direction));
        }

        //END UFPS 2 SUPPORT

        public void ApplyDamage(float damage)
        {
            Damage(damage);
        }

        public void ApplyDamage(float damage, float force, Vector3 dir)
        {
            Damage(damage, force, dir);
        }


        public void Damage(float damage)
        {
            if (myScript)
            {
                //Use the multiplier to take differing amounts of damage depending on where the AI is hit
                damage = damage * damageMultiplyer;

                //Store the amount of damage taken for the dismemberment sript
                StartCoroutine("StoreDamageTakenRecently", damage);

                if (myScript)
                    myScript.Damage(damage);
            }
        }

        public void Damage(float damage, float force, Vector3 dir)
        {
            if (myScript)
            {
                //Use the multiplier to take differing amounts of damage depending on where the AI is hit
                damage = damage * damageMultiplyer;

                StartCoroutine(AddForceVector(force * dir));

                //Store the amount of damage taken for the dismemberment sript
                StartCoroutine("StoreDamageTakenRecently", damage);

                if (myScript)
                    myScript.Damage(damage);
            }
        }

        //Use for explosives
        public void SingleHitBoxDamage(float damage)
        {
            //We don't do the damage multiplier here because this is used for explosions, and we  don't want to leave it up to RNG which hitbox is used first
            if (myScript)
            {
                //StartCoroutine("StoreDamageTakenRecently", damage);

                if (canDoSingleHealthBoxDamage)
                    StartCoroutine(myScript.SingleHitBoxDamage(damage));
                else
                    myScript.Damage(damage);
            }
        }

        public IEnumerator StoreDamageTakenRecently(float d)
        {
            //Only store the damage this frame.  That way only a single strong damage source will trigger the dismemberment script.
            damageTakenThisFrame += d;
            yield return 0;
            damageTakenThisFrame -= d;
        }

        //Do I even need this?
        public IEnumerator AddForceVector(Vector3 fv)
        {
            yield return null;
            if (myRigidBody)
            {
                myRigidBody.AddForce(fv, ForceMode.Impulse);
            }
        }
    }
}
