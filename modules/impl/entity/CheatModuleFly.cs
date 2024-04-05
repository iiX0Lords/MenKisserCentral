using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelGunCheat.modules.impl.entity
{
    public class CheatModuleFly : CheatModuleEntity
    {

        private bool beenActivated = false;
        private float Speed = 1f;

        private bool ctrlwasdown = false;
        public CheatModuleFly(Key k) : base(k)
        {
        }

        public override string GetName()
        {
            return "Fly";
        }

        public override void HandleCheat(Player_move_c player)
        {
            if (!IsEnabled())
            {
                if (beenActivated)
                {
                    CharacterController cc = player.GetComponentInParent<CharacterController>();
                    if (cc == null) return;
                    beenActivated = false;
                    cc.GetComponent<Collider>().enabled = true;
                }
                return;
            }
            CharacterController characterController = player.GetComponentInParent<CharacterController>();
            if (characterController == null) return;
            beenActivated = true;
            characterController.GetComponent<Collider>().enabled = false;

            Camera main = Camera.main;


            if (Input.GetKey(KeyCode.W))
            {
                characterController.transform.position += characterController.transform.forward * Speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                characterController.transform.position += -characterController.transform.forward * Speed;
            }
            if (Input.GetKey(KeyCode.A))
            {
                characterController.transform.position += -characterController.transform.right * Speed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                characterController.transform.position += characterController.transform.right * Speed;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                characterController.transform.position += characterController.transform.up * Speed;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                characterController.transform.position += -characterController.transform.up * Speed;
            }

        }
    }
}