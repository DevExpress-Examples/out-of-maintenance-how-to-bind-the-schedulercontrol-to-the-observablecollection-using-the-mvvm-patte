using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchedulerBindToObservableCollectionWpf {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            schedulerControl1.Start = DateTime.Today;
        }
    }
}
