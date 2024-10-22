using System.Windows;
using System.Windows.Controls;
using DndBattleHelper.Helpers;

namespace DndBattleHelper.Views
{
    /// <summary>
    /// Interaction logic for EnemyView.xaml
    /// </summary>
    public partial class EnemyView : UserControl
    {
        private bool _isResizing;
        public double previousMaxWidth1;
        public double previousMaxWidth2;

        public EnemyView()
        {
            InitializeComponent();
            //previousMaxWidth1 = 0;
            //previousMaxWidth2 = 0; 
            //ParentGrid.SizeChanged += MainGrid_SizeChanged; // Subscribe to SizeChanged event
        }

        //MAYBE TODO
        //private void MainGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    // Prevent recursive calls to the event handler
        //    if (_isResizing)
        //        return;

        //    try
        //    {
        //        _isResizing = true; // Set the flag to true to prevent further execution

        //        // Set columns to Auto
        //        FirstColumn.Width = new GridLength(1, GridUnitType.Auto);
        //        ActionColumn.Width = new GridLength(1, GridUnitType.Auto);

        //        // Force layout update to calculate the Auto width
        //        ParentGrid.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
        //        ParentGrid.Arrange(new Rect(0, 0, ParentGrid.DesiredSize.Width, ParentGrid.DesiredSize.Height));

        //        // Capture the calculated Auto widths

        //        if(Maths.AreAlmostEqual(previousMaxWidth1, First )

        //        previousMaxWidth1 = FirstColumn.ActualWidth;
        //        previousMaxWidth2 = ActionColumn.ActualWidth;

        //        // Set the MaxWidth based on the calculated Auto width
        //        FirstColumn.MaxWidth = previousMaxWidth1;
        //        ActionColumn.MaxWidth = previousMaxWidth2;

        //        // Restore columns to Star sizing
        //        FirstColumn.Width = new GridLength(1, GridUnitType.Star);
        //        ActionColumn.Width = new GridLength(1, GridUnitType.Star);

        //        // Force layout update again to reapply the sizing
        //        ParentGrid.Measure(new Size(Double.PositiveInfinity, Double.PositiveInfinity));
        //        ParentGrid.Arrange(new Rect(0, 0, ParentGrid.DesiredSize.Width, ParentGrid.DesiredSize.Height));
        //    }
        //    finally
        //    {
        //        _isResizing = false; // Reset the flag after layout processing is done
        //    }
        }
    }

        //private void MainGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    // Get the actual width of the second column (ActionColumn)
        //    var availableWidth = ParentGrid.ActualWidth - ActionColumn.ActualWidth;

        //    // Set the MaxWidth of the first column (AutoColumn) to match the available width
        //    FirstColumn.MaxWidth = availableWidth;
        //    //FirstColumn.Width = new GridLength(availableWidth);
        //}


