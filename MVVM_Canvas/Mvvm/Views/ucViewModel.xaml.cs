using Mdev.Mvvm.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mdev.Mvvm.Views
{
    /// <summary>
    /// View.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucViewModel : UserControl
    {
        public ucViewModel()
        {
            InitializeComponent();
        }
        private void UserControlLoaded(object sender, RoutedEventArgs e)
        {
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (designTime)
            {
            }
            else
            {
                foreach (CommandBinding cmd in ViewModelLogics.Command)
                {
                    this.CommandBindings.Add(cmd);
                }
            }

        }
    }
}
