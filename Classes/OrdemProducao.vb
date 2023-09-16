Public Class OrdemProducao
    Sub New()

    End Sub

    Sub New(ByVal xordem As String,
            ByVal xcodigoformula As String,
            ByVal xdescricaoformula As String,
            ByVal xcodigoproduto As String,
            ByVal xtotalformula As Double,
            ByVal xbatchsdesejados As Integer,
            ByVal xloteinicialdigitado As String)

        _ordem = xordem
        _codigoFormula = xcodigoformula
        _descricaoFormula = xdescricaoformula
        _codigoProduto = xcodigoproduto
        _totalFormula = xtotalformula
        _batchsDesejados = xbatchsdesejados
        _loteInicialDigitado = xloteinicialdigitado

    End Sub

    Private _ordem As String
    Public Property Ordem() As String
        Get
            Return _ordem
        End Get
        Set(ByVal value As String)
            _ordem = value
        End Set
    End Property

    Private _codigoFormula As String
    Public Property CodigoFormula() As String
        Get
            Return _codigoFormula
        End Get
        Set(ByVal value As String)
            _codigoFormula = value
        End Set
    End Property

    Private _descricaoFormula As String
    Public Property DescricaoFormula() As String
        Get
            Return _descricaoFormula
        End Get
        Set(ByVal value As String)
            _descricaoFormula = value
        End Set
    End Property

    Private _codigoProduto As String
    Public Property CodigoProduto() As String
        Get
            Return _codigoProduto
        End Get
        Set(ByVal value As String)
            _codigoProduto = value
        End Set
    End Property

    Private _totalFormula As Double
    Public Property TotalFormula() As Double
        Get
            Return _totalFormula
        End Get
        Set(ByVal value As Double)
            _totalFormula = value
        End Set
    End Property

    Private _tamanhoBatch As Double
    Public Property TamanhoBatch() As Double
        Get
            Return _tamanhoBatch
        End Get
        Set(ByVal value As Double)
            _tamanhoBatch = value
        End Set
    End Property

    Private _batchsDesejados As Integer
    Public Property BatchsDesejados() As Integer
        Get
            Return _batchsDesejados
        End Get
        Set(ByVal value As Integer)
            _batchsDesejados = value
        End Set
    End Property

    Private _loteInicialDigitado As String
    Public Property LoteInicialDigitado() As String
        Get
            Return _loteInicialDigitado
        End Get
        Set(ByVal value As String)
            _loteInicialDigitado = value
        End Set
    End Property

    Private _itens As List(Of ProducaoMateriaPrima)
    Public Property Itens() As List(Of ProducaoMateriaPrima)
        Get
            Return _itens
        End Get
        Set(ByVal value As List(Of ProducaoMateriaPrima))
            _itens = value
        End Set
    End Property

End Class
