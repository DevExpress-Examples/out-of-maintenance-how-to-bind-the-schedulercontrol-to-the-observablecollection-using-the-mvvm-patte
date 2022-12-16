Imports System.Windows
Imports System.Windows.Input
Imports System.Collections.ObjectModel

Namespace SchedulerBindToObservableCollectionWpf

    Public Class SchedulerViewModel

        Private _Appointments As ObservableCollection(Of SchedulerBindToObservableCollectionWpf.ModelAppointment), _Resources As ObservableCollection(Of SchedulerBindToObservableCollectionWpf.ModelResource), _AddNewAppointmentCommand As ICommand, _GetSourceObjectCommand As ICommand

        Public Property Appointments As ObservableCollection(Of ModelAppointment)
            Get
                Return _Appointments
            End Get

            Private Set(ByVal value As ObservableCollection(Of ModelAppointment))
                _Appointments = value
            End Set
        End Property

        Public Property Resources As ObservableCollection(Of ModelResource)
            Get
                Return _Resources
            End Get

            Private Set(ByVal value As ObservableCollection(Of ModelResource))
                _Resources = value
            End Set
        End Property

        Public Property AddNewAppointmentCommand As ICommand
            Get
                Return _AddNewAppointmentCommand
            End Get

            Private Set(ByVal value As ICommand)
                _AddNewAppointmentCommand = value
            End Set
        End Property

        Public Property GetSourceObjectCommand As ICommand
            Get
                Return _GetSourceObjectCommand
            End Get

            Private Set(ByVal value As ICommand)
                _GetSourceObjectCommand = value
            End Set
        End Property

        Public Sub New()
            Appointments = New ObservableCollection(Of ModelAppointment)()
            Resources = New ObservableCollection(Of ModelResource)()
            AddNewAppointmentCommand = New DevExpress.Mvvm.DelegateCommand(Of Object)(AddressOf AddNewAppointmentCommandExecute)
            GetSourceObjectCommand = New DevExpress.Mvvm.DelegateCommand(Of Object)(AddressOf GetSourceObjectCommandExecute)
            AddTestData()
        End Sub

        Private Sub AddNewAppointmentCommandExecute(ByVal parameter As Object)
            Dim baseTime As Date = Date.Today
            Dim apt As ModelAppointment = New ModelAppointment() With {.StartTime = baseTime.AddHours(3), .EndTime = baseTime.AddHours(4), .Subject = "Test3", .Location = "Office", .Description = "Test procedure", .Price = 20D}
            Appointments.Add(apt)
        End Sub

        Private Sub GetSourceObjectCommandExecute(ByVal parameter As Object)
            Dim storage As DevExpress.Xpf.Scheduler.SchedulerStorage = CType(parameter, DevExpress.Xpf.Scheduler.SchedulerStorage)
            If storage.AppointmentStorage.Count > 0 Then
                Dim apt As ModelAppointment = CType(storage.AppointmentStorage(0).GetSourceObject(storage.GetCoreStorage()), ModelAppointment)
                ' Alternative: ModelAppointment apt = (ModelAppointment)storage.GetObjectRow(storage.AppointmentStorage[0]);
                Call MessageBox.Show("First Appointment Price: " & apt.Price.ToString())
            End If
        End Sub

        Private Sub AddTestData()
            Dim res1 As ModelResource = New ModelResource() With {.Id = 0, .Name = "Computer1", .Color = ToRgb(System.Drawing.Color.Yellow)}
            Dim res2 As ModelResource = New ModelResource() With {.Id = 1, .Name = "Computer2", .Color = ToRgb(System.Drawing.Color.Green)}
            Dim res3 As ModelResource = New ModelResource() With {.Id = 2, .Name = "Computer3", .Color = ToRgb(System.Drawing.Color.Blue)}
            Resources.Add(res1)
            Resources.Add(res2)
            Resources.Add(res3)
            Dim baseTime As Date = Date.Today
            Dim apt1 As ModelAppointment = New ModelAppointment() With {.StartTime = baseTime.AddHours(1), .EndTime = baseTime.AddHours(2), .Subject = "Test", .Location = "Office", .Description = "Test procedure", .Price = 10D}
            Dim apt2 As ModelAppointment = New ModelAppointment() With {.StartTime = baseTime.AddHours(2), .EndTime = baseTime.AddHours(3), .Subject = "Test2", .Location = "Office", .Description = "Test procedure", .ResourceId = "<ResourceIds>" & Microsoft.VisualBasic.Constants.vbCrLf & "<ResourceId Type=""System.Int32"" Value=""0"" />" & Microsoft.VisualBasic.Constants.vbCrLf & "<ResourceId Type=""System.Int32"" Value=""1"" />" & Microsoft.VisualBasic.Constants.vbCrLf & "</ResourceIds>"}
            Appointments.Add(apt1)
            Appointments.Add(apt2)
        End Sub

        Private Function ToRgb(ByVal color As System.Drawing.Color) As Integer
            Return color.B << 16 Or color.G << 8 Or color.R
        End Function
    End Class
End Namespace
