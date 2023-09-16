Public Class Producao

    Private _OrdemProducao As String
    Public Property OrdemProducao() As String
        Get
            Return _OrdemProducao
        End Get
        Set(ByVal value As String)
            _OrdemProducao = value
        End Set
    End Property


    Private _id As Double
    Public Property ID() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _produtoID As Double
    Public Property ProdutoID() As Double
        Get
            Return _produtoID
        End Get
        Set(ByVal value As Double)
            _produtoID = value
        End Set
    End Property

    Private _produtoDescricao As String
    Public Property ProdutoDescricao() As String
        Get
            Return _produtoDescricao
        End Get
        Set(ByVal value As String)
            _produtoDescricao = value
        End Set
    End Property

    Private _formulaID As Double
    Public Property FormulaID() As Double
        Get
            Return _formulaID
        End Get
        Set(ByVal value As Double)
            _formulaID = value
        End Set
    End Property

    Private _numeroBatchsDesejados As Integer
    Public Property NumeroBatchsDesejados() As Integer
        Get
            Return _numeroBatchsDesejados
        End Get
        Set(ByVal value As Integer)
            _numeroBatchsDesejados = value
        End Set
    End Property

    Private _tamanhoCadaBatch As Double
    Public Property TamanhoCadaBatch() As Double
        Get
            Return _tamanhoCadaBatch
        End Get
        Set(ByVal value As Double)
            _tamanhoCadaBatch = value
        End Set
    End Property

    Private _destinoID As Integer
    Public Property DestinoID() As Integer
        Get
            Return _destinoID
        End Get
        Set(ByVal value As Integer)
            _destinoID = value
        End Set
    End Property

End Class
