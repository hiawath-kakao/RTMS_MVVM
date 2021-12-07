using Mdev.Controls;
using System.ComponentModel;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Mdev.Mvvm.Models
{
    public abstract class ModelBase: INotifyPropertyChanged, IMoveThumb, IResizeThumb
    {
        public string NAME { get; set; }
        
        private double X_;
        public double X
        {
            get { return this.X_; }
            set
            {
                this.X_ = value;
                this.OnPropertyChanged("X");
            }
        }

        private double Y_;
        public double Y
        {
            get { return this.Y_; }
            set
            {
                this.Y_ = value;
                this.OnPropertyChanged("Y");
            }
        }

        private double WIDTH_;
        public double WIDTH
        {
            get { return this.WIDTH_; }
            set
            {
                this.WIDTH_ = value;
                this.OnPropertyChanged("WIDTH");
            }
        }

        private double HEIGHT_;
        public double HEIGHT
        {
            get { return this.HEIGHT_; }
            set
            {
                this.HEIGHT_ = value;
                this.OnPropertyChanged("HEIGHT");
            }
        }

        private Brush COLOR_ = Brushes.White;
        [XmlIgnore]
        public Brush COLOR
        {
            get { return this.COLOR_; }
            set
            {
                this.COLOR_ = value;
                this.STR_COLOR = value.ToString();
                this.OnPropertyChanged("COLOR");
            }
        }

        [XmlIgnore]
        private readonly BrushConverter ColorConverter = new BrushConverter();

        // 2021-08-09
        private string STR_COLOR_;
        public string STR_COLOR
        {
            get
            {
                return this.STR_COLOR_;
            }
            set
            {
                this.STR_COLOR_ = value;
                this.COLOR_ = (Brush)this.ColorConverter.ConvertFrom(value);
            }
        }


        /*
        public double XX
        {
            get { return this.X; }
            set
            {
                this.X = value;
            }
        }

        public double YY
        {
            get { return this.Y; }
            set
            {
                this.Y = value;
            }
        }
        */


        /*
        public double XX => X;
        public double YY => Y;
        */


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
                catch
                {
                }
            }
        }
    }
}
