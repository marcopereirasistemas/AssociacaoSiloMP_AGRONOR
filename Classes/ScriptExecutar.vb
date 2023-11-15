Public Class ScriptExecutar
    Private _id As Guid
    Public Property ID() As Guid
        Get
            Return _id
        End Get
        Set(ByVal value As Guid)
            _id = value
        End Set
    End Property
    Private _comando As String
    Public Property Comando() As String
        Get
            Return _comando
        End Get
        Set(ByVal value As String)
            _comando = value
        End Set
    End Property
    Public Sub New()
    End Sub
    Public Sub New(_script As String)
        _id = Guid.NewGuid()
        _comando = _script

    End Sub
End Class
