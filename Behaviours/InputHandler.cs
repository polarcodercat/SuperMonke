using UnityEngine.XR;

namespace SuperMonke.Behaviours
{
    class InputHandler
    {
        static XRNode leftHandNode = XRNode.LeftHand;
        static XRNode rightHandNode = XRNode.RightHand;

        public static bool GetInput(bool isLeftHand, InputType inputType)
        {
            bool output = false;
            XRNode node;

            node = isLeftHand ? leftHandNode : rightHandNode;

            //super shitty - i'll make a better 
            switch (inputType)
            {
                case InputType.triggerButton:
                    InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.triggerButton, out output);
                    break;
                case InputType.gripButton:
                    InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.gripButton, out output);
                    break;
                case InputType.primaryButton:
                    InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.primaryButton, out output);
                    break;
                default:
                    //this shouldn't happen
                    break;
            }
            return output;
        }

        public enum InputType
        {
            triggerButton,
            gripButton,
            primaryButton
        }
    }
}
