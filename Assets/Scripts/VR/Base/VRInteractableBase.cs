using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VR.ObjectDefinitions;

namespace VR.Base
{
    public class VRInteractableBase : MonoBehaviour
    {
        [SerializeField] float hoverWeight = 1;
        [SerializeField] protected InteractableJointOvverideValSO jointOvveride;
        [SerializeField] bool multipleGrab = true;
        [SerializeField] List<Collider> hoverColliders = new List<Collider>();

        protected bool hoverable = true;




        #region Accesors
        public bool MultipleGrab { get { return multipleGrab; } set { multipleGrab = value; } } 
        public float HoverWeight { get { return hoverWeight; } }
        public bool Hoverable { get { return hoverable; } set { hoverable = value; } }
        public bool Grabbed { get; set; }
        public VRHandInteractor VRHandInteractor { get; set; }
        public InteractableJointOvverideValSO JointOvveride { get { return jointOvveride; } }

        public virtual float PositionSpringOverride { get { return jointOvveride.PositionSpring; } }
        public virtual float PositionDumperOverride { get { return jointOvveride.PositionDumper; } }
        public virtual float MaximumForceOverride { get { return jointOvveride.MaximumForce; } }
        public virtual float AngularSpringOverride { get { return jointOvveride.AngularSpring; } }
        public virtual float AngularDumperOverride { get { return jointOvveride.AngularDumper; } }
        public virtual float AngularMaximumForceOverride { get { return jointOvveride.AngularMaximumForce; } }

        public VRManager VRManager { get; set; }
        #endregion

        #region UnityEvents
        public UnityEvent<VRInteractableBase> onAttachBegin;
        public UnityEvent onAttachEnd;
        public UnityEvent onDetach;
        public UnityEvent onHoverEnter;
        public UnityEvent onHoverExit;
        public UnityEvent onTriggerTrue;
        public UnityEvent onTriggerFalse;
        #endregion

        public virtual void OnHoverEnter(VRHandInteractor handInteractor)
        {
            //GetAttachTransform(handInteractor);
            onHoverEnter?.Invoke();
        }
        public virtual void OnHoverExit(VRHandInteractor handInteractor)
        {
            onHoverExit?.Invoke();
        }
        public virtual void OnAttachBegin(VRHandInteractor handInteractor)
        {
            onAttachBegin?.Invoke(this);
        }
        public virtual void OnAttachEnd(VRHandInteractor handInteractor)
        {
            onAttachEnd?.Invoke();
            VRManager = handInteractor.VRManager;
        }
        public virtual void OnDetach(VRHandInteractor handInteractor)
        {
            onDetach?.Invoke();
        }

        public virtual void OnTriggerTrue()
        {
            onTriggerTrue?.Invoke();
        }
        public virtual void OnTriggerFalse()
        {
            onTriggerFalse?.Invoke();
        }

        public virtual void EnableAllHovers(bool _state)
        {
            foreach (Collider _collider in hoverColliders)
            {
                _collider.enabled = _state;
            }
        }
        public void RemoveVRManager()
        {
            VRManager = null;
        }
    }
}
