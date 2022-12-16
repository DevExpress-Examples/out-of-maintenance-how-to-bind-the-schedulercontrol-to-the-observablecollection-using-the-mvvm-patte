Imports System.Windows

Namespace SchedulerBindToObservableCollectionWpf

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.schedulerControl1.Start = Date.Today
        End Sub
    End Class
End Namespace
