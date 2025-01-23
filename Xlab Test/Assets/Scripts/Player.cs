using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Player : MonoBehaviour
    {
        public Transform stick;

        private bool m_isDown = false;

        public float range = 40f;
        public float speed = 500f;

        private void Update()
        {
            m_isDown = Input.GetMouseButtonUp(0);

            Quaternion rot = stick.localRotation;

            Quaternion toRot = Quaternion.Euler(m_isDown ? range : -range, 0, 0);

            rot = Quaternion.RotateTowards(rot, toRot, speed = Time.deltaTime);

            stick.localRotation = rot;
        }
        public void OnCollisionStick(Collider collider)
        {
            Debug.Log(collider, this);
        }
    }
}