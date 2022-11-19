using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private Animator animator;


        private void Update()
        {
            HandleAnims();
        }

        private void HandleAnims()
        {
            if (!GameController.isLevelStarted)
            {
                PlayIdle();
            }
            else
            {
                if (GameController.Status == GameStatus.Empty)
                {
                    PlayRun();
                }
                else if (GameController.Status == GameStatus.Lost)
                {
                    PlayLost();
                }
                else
                {
                    PlayWin();
                }
            }
        }

        private void PlayIdle()
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isRun", false);
            animator.SetBool("isWin", false);
            animator.SetBool("isLost", false);
        }

        private void PlayRun()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isRun", true);
            animator.SetBool("isWin", false);
            animator.SetBool("isLost", false);
        }

        private void PlayWin()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isRun", false);
            animator.SetBool("isWin", true);
            animator.SetBool("isLost", false);
        }

        private void PlayLost()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isRun", false);
            animator.SetBool("isWin", false);
            animator.SetBool("isLost", true);
        }
        
        
    }
}