

Public Class Turno

    Public Sub New()
    End Sub

    Public Sub New(ByVal xid As Integer,
                   ByVal xdescricao As String,
                   ByVal xinicio As DateTime,
                   ByVal xfinal As DateTime,
                   ByVal xstatus As Integer)
        _id = xid
        _descricao = xdescricao
        _inicio = xinicio
        _final = xfinal
        _status = xstatus
    End Sub

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _descricao As String
    Public Property Descricao() As String
        Get
            Return _descricao
        End Get
        Set(ByVal value As String)
            _descricao = value
        End Set
    End Property

    Private _inicio As DateTime
    Public Property Inicio() As DateTime
        Get
            Return _inicio
        End Get
        Set(ByVal value As DateTime)
            _inicio = value
        End Set
    End Property

    Private _final As DateTime
    Public Property Final() As DateTime
        Get
            Return _final
        End Get
        Set(ByVal value As DateTime)
            _final = value
        End Set
    End Property

    Private _status As Integer
    Public Property Status() As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
        End Set
    End Property

End Class
