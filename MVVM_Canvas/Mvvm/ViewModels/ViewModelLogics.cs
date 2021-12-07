using Mdev.Common;
using Mdev.Mvvm.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Mdev.Mvvm.ViewModels
{
    public partial class ViewModelLogics : ModelBase
    {
        // 2021-08-06
        [XmlIgnore]
        public static CommandBindingCollection Command = new CommandBindingCollection();
        // 2021-08-06
        public static RoutedCommand ModelCommand = new RoutedCommand("ModelCommand", typeof(ApplicationCommands));
        public static RoutedCommand AddModelCommand = new RoutedCommand("AddModelCommand", typeof(ApplicationCommands));
        public static RoutedCommand ModelCloseCommand = new RoutedCommand("ModelCloseCommand", typeof(ApplicationCommands));
        public static RoutedCommand DelModelCommand = new RoutedCommand("DelModelCommand", typeof(ApplicationCommands));

        public ObservableCollection<Model> MODELS { get; set; }
RoutedCommand
        public ViewModelLogics()
        {
            // 2021-09-15
            bool designTime = System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject());
            if (designTime)
            {
                this.MODELS = new ObservableCollection<Model>
                {
                    new Model { NAME = "커피", X = 25, Y = 100, COLOR = new SolidColorBrush(Colors.Magenta) },
                    new Model { NAME = "아이스크림", X = 10, COLOR = new SolidColorBrush(Colors.YellowGreen) },
                    new Model { NAME = "김치김밥", X = 20, COLOR = new SolidColorBrush(Colors.Aqua) },
                    new Model { NAME = "초콜렛", X = 20, COLOR = new SolidColorBrush(Colors.White) },
                    new Model { NAME = "과자", X = 800, COLOR = new SolidColorBrush(Colors.Green) },
                    new Model { NAME = "코카콜라", X = 130, COLOR = new SolidColorBrush(Colors.Yellow) },
                    new Model { NAME = "피자", X = 150, COLOR = new SolidColorBrush(Colors.Green) },
                    new Model { NAME = "생수", X = 80, COLOR = new SolidColorBrush(Colors.Yellow) },
                    new Model { NAME = "라면", X = 80, COLOR = new SolidColorBrush(Colors.Green) },
                    new Model { NAME = "햇반", X = 150, COLOR = new SolidColorBrush(Colors.Green) },
                    new Model { NAME = "우유", X = 250, COLOR = new SolidColorBrush(Colors.Magenta) },
                    new Model { NAME = "스팸", X = 250, COLOR = new SolidColorBrush(Colors.Green) },
                    new Model { NAME = "짜파게티", X = 80, COLOR = new SolidColorBrush(Colors.Green) },
                    new Model { NAME = "서울우유", X = 250, COLOR = new SolidColorBrush(Colors.Magenta) },
                    new Model { NAME = "하겐다즈", X = 400, COLOR = new SolidColorBrush(Colors.YellowGreen) },
                    new Model { NAME = "쿠게더", X = 180, COLOR = new SolidColorBrush(Colors.YellowGreen) },
                    new Model { NAME = "가나초콜렛", X = 200, COLOR = new SolidColorBrush(Colors.White) },
                    new Model { NAME = "허쉬초콜렛", X = 200, COLOR = new SolidColorBrush(Colors.White) },
                    new Model { NAME = "삼각김밥", X = 200, COLOR = new SolidColorBrush(Colors.Aqua) },
                    new Model { NAME = "사과", X = 100, COLOR = new SolidColorBrush(Colors.LimeGreen) },
                    new Model { NAME = "칫솔", X = 80, COLOR = new SolidColorBrush(Colors.Violet) },
                    new Model { NAME = "도시락", X = 200, COLOR = new SolidColorBrush(Colors.Aqua) },
                    new Model { NAME = "매일우유", X = 250, COLOR = new SolidColorBrush(Colors.Magenta) }
                };
                //clsUtil.SaveData("TEST.xml", this.MODELS);
            }
            else
            {
                this.MODELS = Util.ReadData<ObservableCollection<Model>>("TEST.xml");
            }
            // 2021-08-06                        
            ViewModelLogics.Command.Add(new CommandBinding(ViewModelLogics.ModelCommand, Executed, CanExecuted));
            ViewModelLogics.Command.Add(new CommandBinding(ViewModelLogics.AddModelCommand, Executed, CanExecuted));
            ViewModelLogics.Command.Add(new CommandBinding(ViewModelLogics.DelModelCommand, Executed, CanExecuted));            
        }

        ~ViewModelLogics()
        {
            Util.SaveData<ObservableCollection<Model>>("TEST.xml", this.MODELS);
        }

        private void CanExecuted(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }
    }
}