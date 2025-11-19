using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System;

namespace Custom
{
    class CustomAttributes : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<CustomAttributes, UxmlTraits> { }

        // Add the two custom UXML attributes.
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            UxmlStringAttributeDescription m_String = new() { name = "my-string", defaultValue = "default_value" };
            UxmlIntAttributeDescription m_Int = new() { name = "my-int", defaultValue = 2 };
            UxmlFloatAttributeDescription m_Float = new() { name = "my-float", defaultValue = 3.14f };
            UxmlLongAttributeDescription m_Long = new() { name = "my-long", defaultValue = 1234567890L };
            UxmlBoolAttributeDescription m_Bool = new() { name = "my-bool", defaultValue = false };
            UxmlColorAttributeDescription m_Color = new() { name = "my-color", defaultValue = Color.white };
            UxmlEnumAttributeDescription<MyEnum> m_Enum = new() { name = "my-enum", defaultValue = MyEnum.First };
            UxmlTypeAttributeDescription<Type> myType = new() { name = "my-type", defaultValue = null };

            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get
                {
                    yield return new UxmlChildElementDescription(typeof(VisualElement));
                }
            }


            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var ate = ve as CustomAttributes;

                ate.myString = m_String.GetValueFromBag(bag, cc);
                ate.myInt = m_Int.GetValueFromBag(bag, cc);
                ate.myFloat = m_Float.GetValueFromBag(bag, cc);
                ate.myLong = m_Long.GetValueFromBag(bag, cc);
                ate.myBool = m_Bool.GetValueFromBag(bag, cc);
                ate.myColor = m_Color.GetValueFromBag(bag, cc);
                ate.myEnum = m_Enum.GetValueFromBag(bag, cc);
                ate.myType = myType.GetValueFromBag(bag, cc);

            }
        }

        // Must expose your element class to a { get; set; } property that has the same name 
        // as the name you set in your UXML attribute description with the camel case format
        public string myString { get; set; }
        public int myInt { get; set; }
        public float myFloat { get; set; }
        public long myLong { get; set; }
        public bool myBool { get; set; }
        public Color myColor { get; set; }
        public MyEnum myEnum { get; set; }
        public Type myType { get; set; }
    }

    public enum MyEnum
    {
        First,
        Second,
        Third
    }

}
