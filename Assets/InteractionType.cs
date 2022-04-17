
namespace MyFramework { 
    public enum InteractionType
    {
        Activate,
        Pick,
        Rewind,
        Enable,
        Disable
    }

    public class InteractionData
    {
        public InteractionType type;
        public object data;

        public InteractionData(InteractionType _type)
        {
            type = _type;
        }

        public InteractionData(InteractionType _type, object _data)
        {
            type = _type;
            data = _data;
        }
    }
}
