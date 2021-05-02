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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gizmo.Sourcerer.Structuring;

namespace Gizmo.Sourcerer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            pictureList.ItemsSource = new List<Node>()
            {
                new MyMediaItem()
                {
                    ChildNodes = {
                        new MyMediaItem()
                        {
                            ChildNodes = {
                                new MyMediaItem()
                            }
                        },
                        new MyMediaItem(),
                        new MyMediaItem()
                    }
                },
                new MyMediaItem()
            };
        }
    }
}
