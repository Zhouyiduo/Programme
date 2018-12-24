Public Class uc_Person

    Private Sub uc_Person_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Me.DataContext = New VIEWMODEL.vmPersona
    End Sub
End Class
