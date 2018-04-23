Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace SchedulerBindToObservableCollectionWpf
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()

			schedulerControl1.Start = DateTime.Today
		End Sub
	End Class
End Namespace
