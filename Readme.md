# How to bind the SchedulerControl to the ObservableCollection using the MVVM pattern


<p>This example illustrates how to bind SchedulerControl appointment and resource storages to ObservableCollection instances in the context of the basic MVVM implementation. Custom appointment and resource objects are represented by the <strong>ModelAppointment</strong> and <strong>ModelResource</strong> class instances. The <strong>SchedulerViewModel</strong> class exposes the collections of these objects. Finally, the corresponding view model properties are specified in binding expressions in the MainWindow.xaml markup file. </p><p>In addition, this example illustrates how to access the underlying data objects of a certain appointment. Note that the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerPersistentObject_GetSourceObjecttopic"><u>PersistentObject.GetSourceObject Method</u></a> is used for this purpose.</p><p><strong>Note:</strong> Data formats, in which the <strong>ModelResource.Color</strong> and <strong>ModelAppointment.ResourceId</strong> property values are specified in the <strong>SchedulerViewModel.AddTestData()</strong> method, are described in the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerResourceStorageBase_ColorSavingtopic"><u>ResourceStorageBase.ColorSaving Property</u></a> and <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument4217"><u>How to: Enable Multi-resource Appointments</u></a> help sections correspondingly.</p>

<br/>


