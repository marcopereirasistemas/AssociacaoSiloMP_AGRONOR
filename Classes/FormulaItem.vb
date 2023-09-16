Public Class FormulaItem

    Public Sub New(ByVal xcodigoFormula As String, _
                    ByVal xcodigoMateriaPrima As String, _
                    ByVal xdescricaoMateriaPrima As String,
                    ByVal xquantidade As Double, _
                    ByVal xitemID As Integer)
        _codigoFormula = xcodigoFormula
        _codigoMateriaPrima = xcodigoFormula
        _descricaoMateriaPrima = xdescricaoMateriaPrima
        _quantidade = xquantidade
        _itemID = ItemID
    End Sub

    Private _codigoFormula As String
    Public Property CodigoFormula() As String
        Get
            Return _codigoFormula
        End Get
        Set(ByVal value As String)
            _codigoFormula = value
        End Set
    End Property

    Private _codigoMateriaPrima As String
    Public Property CodigoMateriaPrima() As String
        Get
            Return _codigoMateriaPrima
        End Get
        Set(ByVal value As String)
            _codigoMateriaPrima = value
        End Set
    End Property

    Private _descricaoMateriaPrima As String
    Public Property DescricaoMateriaPrima() As String
        Get
            Return _descricaoMateriaPrima
        End Get
        Set(ByVal value As String)
            _descricaoMateriaPrima = value
        End Set
    End Property

    Private _quantidade As String
    Public Property Quantidade() As String
        Get
            Return _quantidade
        End Get
        Set(ByVal value As String)
            _quantidade = value
        End Set
    End Property

    Private _itemID As String
    Public Property ItemID() As String
        Get
            Return _itemID
        End Get
        Set(ByVal value As String)
            _itemID = value
        End Set
    End Property

End Class

