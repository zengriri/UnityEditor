using UnityEngine;
using UnityEngine.UIElements;

public class CardElement : VisualElement
{
    // 暴露给UXML和UI Builder
    public new class UxmlFactory : UxmlFactory<CardElement> { }

    private VisualElement portraitImage => this.Q("image");
    private Label attackBadge => this.Q<Label>("attack-badge");
    private Label healthBadge => this.Q<Label>("health-badge");

    // 使用Init()方法而不是构造函数，因为此时还没有子元素
    public void Init(Texture2D image, int health, int attack)
    {
        portraitImage.style.backgroundImage = image;
        attackBadge.text = attack.ToString();
        healthBadge.text = health.ToString();
    }

    // 自定义控件需要默认构造函数
    public CardElement()
    {
        Resources.Load<VisualTreeAsset>("CardElement").CloneTree(this);
    }
}