using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DivePlannerMk3.Views.UserControls.DivePlan
{
    public class DiveModelSelectorView : UserControl
    {
        public DiveModelSelectorView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}