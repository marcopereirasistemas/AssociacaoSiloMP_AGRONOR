Public Class TagItem
    Private _opcItemID As Long
    Public Property OpcItemID() As Long
        Get
            Return _opcItemID
        End Get
        Set(ByVal value As Long)
            _opcItemID = value
        End Set
    End Property

    Private _opcItem As String
    Public Property OpcItem() As String
        Get
            Return _opcItem
        End Get
        Set(ByVal value As String)
            _opcItem = value
        End Set
    End Property

    Public Sub New(ByVal _parOpcItemID As Long, _parOpcItem As String)
        _opcItemID = _parOpcItemID
        _opcItem = _parOpcItem
    End Sub
End Class
