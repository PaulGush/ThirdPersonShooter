using System;
using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Animation
{
    public class AnimRigController : MonoBehaviour
    {
        [SerializeField] private MultiAimConstraint m_bodyAimConstraint;
        [SerializeField] private MultiAimConstraint m_headAimConstraint;
        [SerializeField] private MultiAimConstraint m_aimConstraint;
        
        [SerializeField] private PlayerInput m_playerInput;
        
        private float m_bodyAimTargetWeight;
        private float m_headAimTargetWeight;
        private float m_aimTargetWeight;
        
        private void OnEnable()
        {
            m_playerInput.actions["Secondary"].performed += OnAim;
            m_playerInput.actions["Secondary"].canceled += OnStopAim;
        }
        
        private void OnDisable()
        {
            m_playerInput.actions["Secondary"].performed -= OnAim;
            m_playerInput.actions["Secondary"].canceled -= OnStopAim;
        }
        
        private void OnAim(InputAction.CallbackContext context)
        {
            m_bodyAimTargetWeight = 0.7f;
            m_headAimTargetWeight = 1f;
            m_aimTargetWeight = 1f;
        }

        private void OnStopAim(InputAction.CallbackContext context)
        {
            m_bodyAimTargetWeight = 0f;
            m_headAimTargetWeight = 0f;
            m_aimTargetWeight = 0f;
        }
        
        private void SetMultiAimConstraintTargetWeight(float target, MultiAimConstraint constraint)
        { 
            constraint.weight = Mathf.Lerp(constraint.weight, target, 10f * Time.deltaTime);
        }

        private void Update()
        {
            SetMultiAimConstraintTargetWeight(m_bodyAimTargetWeight, m_bodyAimConstraint);
            SetMultiAimConstraintTargetWeight(m_headAimTargetWeight, m_headAimConstraint);
            SetMultiAimConstraintTargetWeight(m_aimTargetWeight, m_aimConstraint);
        }
    }
}
