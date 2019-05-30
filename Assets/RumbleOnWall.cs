using UnityEngine;
using VRTK;

public class RumbleOnWall : MonoBehaviour {
    VRTK_HeadsetCollision headset;
    VRTK_ControllerReference left;
    VRTK_ControllerReference right;

    protected virtual void Awake()
    {
        headset = GetComponent<VRTK_HeadsetCollision>();
        VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);
    }

    protected virtual void OnEnable()
    {
        headset.HeadsetCollisionDetect += Headset_HeadsetCollisionDetect;
        headset.HeadsetCollisionEnded += Headset_HeadsetCollisionEnded;
    }

    void OnDisable()
    {
        headset.HeadsetCollisionDetect -= Headset_HeadsetCollisionDetect;
        headset.HeadsetCollisionEnded -= Headset_HeadsetCollisionEnded;
    }

    private void Headset_HeadsetCollisionEnded(object sender, HeadsetCollisionEventArgs e)
    {
        GetControllers();
        VRTK_ControllerHaptics.CancelHapticPulse(left);
        VRTK_ControllerHaptics.CancelHapticPulse(right);
    }

    private void Headset_HeadsetCollisionDetect(object sender, HeadsetCollisionEventArgs e)
    {
        GetControllers();
        VRTK_ControllerHaptics.TriggerHapticPulse(left, 1, 60f, 0.1f);
        VRTK_ControllerHaptics.TriggerHapticPulse(right, 1, 60f, 0.1f);
    }

    void GetControllers()
    {
        left = VRTK_DeviceFinder.GetControllerReferenceLeftHand();
        right = VRTK_DeviceFinder.GetControllerReferenceRightHand();
    }

    protected virtual void OnDestroy()
    {
        VRTK_SDKManager.instance.RemoveBehaviourToToggleOnLoadedSetupChange(this);
    }


}
