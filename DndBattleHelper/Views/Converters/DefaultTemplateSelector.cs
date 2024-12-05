using System.Windows;
using System.Windows.Controls;

namespace DndBattleHelper.Views.Converters;

public class DefaultTemplateSelector : DataTemplateSelector
{
    public DataTemplate DefaultTemplate { get; set; }

    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        if (item == null)
            return DefaultTemplate;  // Fallback for null

        // Use the default template if no specific template is found
        FrameworkElement element = container as FrameworkElement;
        var dataTemplate = element?.TryFindResource(new DataTemplateKey(item.GetType())) as DataTemplate;
        return dataTemplate ?? DefaultTemplate;
    }
}
