Imports System.Collections.ObjectModel
Imports System.ComponentModel

Namespace VIEWMODEL
    Public Class vmPersona
        Implements System.ComponentModel.INotifyPropertyChanged

        Public Event PropertyChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs) Implements ComponentModel.INotifyPropertyChanged.PropertyChanged
        Private _obsPerson As New ObservableCollection(Of Persona)
        Public Property obsPerson As ObservableCollection(Of Persona)
            Get
                Return _obsPerson
            End Get
            Set(value As ObservableCollection(Of Persona))
                _obsPerson = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("obsPerson"))
            End Set
        End Property
        Private _name As String
        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = Name
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Name"))
            End Set
        End Property
        Private _ID1 As Integer
        Public Property ID1 As Integer
            Get
                Return _ID1
            End Get
            Set(value As Integer)
                _ID1 = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("ID1"))
            End Set
        End Property
        Private _ID2 As Integer
        Public Property ID2 As Integer
            Get
                Return _ID2
            End Get
            Set(value As Integer)
                _ID2 = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("ID2"))
            End Set
        End Property
        Private _ID3 As Integer
        Public Property ID3 As Integer
            Get
                Return _ID3
            End Get
            Set(value As Integer)
                _ID3 = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("ID3"))
            End Set
        End Property
        'Private _ID4 As Integer
        'Public Property ID4 As Integer
        '    Get
        '        Return _ID4
        '    End Get
        '    Set(value As Integer)
        '        _ID4 = value
        '        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("ID4"))
        '    End Set
        'End Property

        Sub New()
            obsPerson.Add(New Persona With {.ID = 1, .Name = "harden"})
            obsPerson.Add(New Persona With {.ID = 2, .Name = "jimmy"})
            obsPerson.Add(New Persona With {.ID = 3, .Name = "story"})
        End Sub
    End Class
End Namespace