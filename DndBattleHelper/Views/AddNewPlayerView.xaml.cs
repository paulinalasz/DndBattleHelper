using DndBattleHelper.Helpers.DialogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DndBattleHelper.Views
{
    /// <summary>
    /// Interaction logic for AddNewPlayerView.xaml
    /// </summary>
    public partial class AddNewPlayerView : Window, IDialog
    {
        public AddNewPlayerView()
        {
            InitializeComponent();
        }
    }
}
