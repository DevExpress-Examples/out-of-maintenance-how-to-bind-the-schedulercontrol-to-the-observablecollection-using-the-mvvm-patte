Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Xpf.Core.Commands
Imports System.Collections.ObjectModel

Namespace SchedulerBindToObservableCollectionWpf
	Public Class SchedulerViewModel
		Private privateAppointments As ObservableCollection(Of ModelAppointment)
		Public Property Appointments() As ObservableCollection(Of ModelAppointment)
			Get
				Return privateAppointments
			End Get
			Private Set(ByVal value As ObservableCollection(Of ModelAppointment))
				privateAppointments = value
			End Set
		End Property
		Private privateResources As ObservableCollection(Of ModelResource)
		Public Property Resources() As ObservableCollection(Of ModelResource)
			Get
				Return privateResources
			End Get
			Private Set(ByVal value As ObservableCollection(Of ModelResource))
				privateResources = value
			End Set
		End Property

		Private privateAddNewAppointmentCommand As ICommand
		Public Property AddNewAppointmentCommand() As ICommand
			Get
				Return privateAddNewAppointmentCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateAddNewAppointmentCommand = value
			End Set
		End Property
		Private privateGetSourceObjectCommand As ICommand
		Public Property GetSourceObjectCommand() As ICommand
			Get
				Return privateGetSourceObjectCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateGetSourceObjectCommand = value
			End Set
		End Property

		Public Sub New()
			Appointments = New ObservableCollection(Of ModelAppointment)()
			Resources = New ObservableCollection(Of ModelResource)()

			AddNewAppointmentCommand = New DevExpress.Xpf.Mvvm.DelegateCommand(Of Object)(AddressOf AddNewAppointmentCommandExecute)
			GetSourceObjectCommand = New DevExpress.Xpf.Mvvm.DelegateCommand(Of Object)(AddressOf GetSourceObjectCommandExecute)

			AddTestData()
		End Sub

		Private Sub AddNewAppointmentCommandExecute(ByVal parameter As Object)
			Dim baseTime As DateTime = DateTime.Today

			Dim apt As New ModelAppointment() With {.StartTime = baseTime.AddHours(3), .EndTime = baseTime.AddHours(4), .Subject = "Test3", .Location = "Office", .Description = "Test procedure", .Price = 20D}

			Appointments.Add(apt)
		End Sub

		Private Sub GetSourceObjectCommandExecute(ByVal parameter As Object)
			Dim storage As DevExpress.Xpf.Scheduler.SchedulerStorage = CType(parameter, DevExpress.Xpf.Scheduler.SchedulerStorage)

			If storage.AppointmentStorage.Count > 0 Then
				Dim apt As ModelAppointment = CType(storage.AppointmentStorage(0).GetSourceObject(storage.GetCoreStorage()), ModelAppointment)
				' Alternative: ModelAppointment apt = (ModelAppointment)storage.GetObjectRow(storage.AppointmentStorage[0]);
				MessageBox.Show("First Appointment Price: " & apt.Price.ToString())
			End If
		End Sub

		Private Sub AddTestData()
			Dim res1 As New ModelResource() With {.Id = 0, .Name = "Computer1", .Color = ToRgb(System.Drawing.Color.Yellow)}

			Dim res2 As New ModelResource() With {.Id = 1, .Name = "Computer2", .Color = ToRgb(System.Drawing.Color.Green)}

			Dim res3 As New ModelResource() With {.Id = 2, .Name = "Computer3", .Color = ToRgb(System.Drawing.Color.Blue)}

			Resources.Add(res1)
			Resources.Add(res2)
			Resources.Add(res3)

			Dim baseTime As DateTime = DateTime.Today

			Dim apt1 As New ModelAppointment() With {.StartTime = baseTime.AddHours(1), .EndTime = baseTime.AddHours(2), .Subject = "Test", .Location = "Office", .Description = "Test procedure", .Price = 10D}

			Dim apt2 As New ModelAppointment() With {.StartTime = baseTime.AddHours(2), .EndTime = baseTime.AddHours(3), .Subject = "Test2", .Location = "Office", .Description = "Test procedure", .ResourceId = "<ResourceIds>" & Constants.vbCrLf & "<ResourceId Type=""System.Int32"" Value=""0"" />" & Constants.vbCrLf & "<ResourceId Type=""System.Int32"" Value=""1"" />" & Constants.vbCrLf & "</ResourceIds>"}

			Appointments.Add(apt1)
			Appointments.Add(apt2)
		End Sub

		Private Function ToRgb(ByVal color As System.Drawing.Color) As Integer
			Return color.B << 16 Or color.G << 8 Or color.R
		End Function
	End Class
End Namespace