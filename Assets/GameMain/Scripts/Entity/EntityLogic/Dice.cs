using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;

namespace IsletGame
{
	public class Dice : EntityLogic
    {
        public int value = 0;

        protected Vector3 localHitNormalized;
        protected float validMargin = 0.45F;
        private Vector3 testHitVector;

        public bool rolling
        {
            get
            {
                return !(GetComponent<Rigidbody>().velocity.sqrMagnitude < .1F && GetComponent<Rigidbody>().angularVelocity.sqrMagnitude < .1F);
            }
        }
        protected bool localHit
        {
            get
            {
                Ray ray = new Ray(transform.position + (new Vector3(0, 2, 0) * transform.localScale.magnitude), Vector3.up * -1);
                RaycastHit hit = new RaycastHit();
                if (GetComponent<Collider>().Raycast(ray, out hit, 3 * transform.localScale.magnitude))
                {
                    localHitNormalized = transform.InverseTransformPoint(hit.point.x, hit.point.y, hit.point.z).normalized;
                    return true;
                }
                return false;
            }
        }

        void GetValue()
        {
            value = 0;
            float delta = 1;

            int side = 1;

            do
            {
                testHitVector = HitVector(side);
                if (testHitVector != Vector3.zero)
                {
                    if (Valid(localHitNormalized.x, testHitVector.x) &&
                        Valid(localHitNormalized.y, testHitVector.y) &&
                        Valid(localHitNormalized.z, testHitVector.z))
                    {
                        float nDelta = Mathf.Abs(localHitNormalized.x - testHitVector.x) + Mathf.Abs(localHitNormalized.y - testHitVector.y) + Mathf.Abs(localHitNormalized.z - testHitVector.z);
                        if (nDelta < delta)
                        {
                            value = side;
                            delta = nDelta;
                        }
                    }
                }
                side++;
            } while (testHitVector != Vector3.zero);
        }
        protected bool Valid(float t, float v)
        {
            if (t > (v - validMargin) && t < (v + validMargin))
                return true;
            else
                return false;
        }

        protected virtual Vector3 HitVector(int side)
        {
            return Vector3.zero;
        }


        void Update()
        {
            if (!rolling && localHit)
            {
                GetValue();           
            }
        }


        protected virtual void ValueToString()
        {

        }
    }
}
