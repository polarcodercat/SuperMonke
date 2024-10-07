using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.XR;

using GorillaLocomotion;
using Steamworks;

using Photon.Pun;

namespace SuperMonke.Behaviours
{
    class SuperMonke : MonoBehaviour
    {
        Player player = Player.Instance;
        private Rigidbody rb;
        private float speed = 1;

        private void Awake()
        {
            Console.WriteLine("super monke has awoken!! watch out!! (it's very scary)");
            rb = player.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Contains("MODDED"))
            {
                bool isLeft = ControllerInputPoller.instance.leftControllerIndexFloat > 0.1f && ControllerInputPoller.instance.leftGrab && ControllerInputPoller.instance.leftControllerPrimaryButton;
                bool isRight = ControllerInputPoller.instance.rightControllerIndexFloat > 0.1f && ControllerInputPoller.instance.rightGrab && ControllerInputPoller.instance.rightControllerPrimaryButton;
                Vector3 bodyToLeft = player.leftControllerTransform.position - player.bodyCollider.transform.position;
                Vector3 bodyToRight = player.rightControllerTransform.position - player.bodyCollider.transform.position;

                if (isLeft && isRight)
                {
                    if (speed < 32)
                        speed = (speed * 2) / 1.5f;
                    rb.useGravity = false;
                    rb.velocity = ((bodyToLeft + bodyToRight) / 2) * speed;
                }
                else
                {
                    rb.useGravity = true;
                    if (rb.velocity.magnitude > 2)
                        speed = rb.velocity.magnitude;
                }
            }
            else
                rb.useGravity = true;
        }
    }
}
