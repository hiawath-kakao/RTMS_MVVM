using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Mdev.Controls
{
    public interface IMoveThumb
    {
        double X { get; set; }
        double Y { get; set; }
    }
    public interface IResizeThumb
    {
        double WIDTH { get; set; }
        double HEIGHT { get; set; }
    }

    public class MoveThumb : Thumb
    {
        public MoveThumb()
        {
            DragDelta += new DragDeltaEventHandler(this.MoveThumb_DragDelta);
        }

        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (sender is Thumb)
            {
                Thumb thumb = (Thumb)sender;
                IMoveThumb myRectangle = (IMoveThumb)thumb.DataContext;
                myRectangle.X += e.HorizontalChange;
                myRectangle.Y += e.VerticalChange;
            }
        }              
    }
}