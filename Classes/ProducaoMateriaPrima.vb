
Public Class ProducaoMateriaPrima

    Public Sub New(ByVal xproducaoid As Double,
                   ByVal xordemproducao As String,
                    ByVal xitem As Integer,
                    ByVal xitens As Integer,
                    ByVal xcodigoproduto As String,
                    ByVal xdescricaoproduto As String,
                    ByVal xcodigoformula As String,
                    ByVal xdescricaoformula As String,
                    ByVal xcodigomateriaprima As String,
                    ByVal xdescricaomateriaprima As String,
                    ByVal xdescricaoReduzidaMateriaPrima As String,
                    ByVal xqtdeFormula As Double,
                    ByVal xbalancaNumero As Integer,
                    ByVal xbalancadescricao As String,
                    ByVal xsiloID As Integer,
                    ByVal xsiloNumero As Integer,
                    ByVal xsiloDescricao As String,
                    ByVal xassociado As Integer,
                    ByVal xqtdeDesejada As Double,
                    ByVal xqtdeReal As Double,
                    ByVal xbatchNumero As Integer,
                    ByVal xtamanhoBatch As Double,
                    ByVal xbalancaIndice As Integer,
                    ByVal xloteAtual As String,
                    ByVal xop As String,
                    ByVal xpercentualErroDosagem As Double,
                    ByVal xtagIndice As Integer,
                    ByVal xtamanhoSaco As Double,
                    ByVal xnumeroSacos As Integer)

        _producaoID = xproducaoid
        _ordemProducao = xordemproducao
        _item = xitem
        _itens = xitens
        _codigoProduto = xcodigoproduto
        _descricaoProduto = xdescricaoproduto
        _codigoFormula = xcodigoformula
        _descricaoFormula = xdescricaoformula
        _codigoMateriaPrima = xcodigomateriaprima
        _descricaoMateriaPrima = xdescricaomateriaprima
        _descricaoReduzidaMateriaPrima = xdescricaoReduzidaMateriaPrima
        _qtdeFormula = xqtdeFormula
        _balancaNumero = xbalancaNumero
        _balancaDescricao = xbalancadescricao
        _siloID = xsiloID
        _siloNumero = xsiloNumero
        _siloDescricao = xsiloDescricao
        _associado = xassociado
        _qtdeDesejada = xqtdeDesejada
        _qtdeReal = xqtdeReal
        _batchNumero = xbatchNumero
        _tamanhoBatch = xtamanhoBatch
        _balancaIndice = xbalancaIndice
        _loteAtual = xloteAtual
        _op = xop
        _percentualErroDosagem = xpercentualErroDosagem
        _tagIndice = xtagIndice
        _tamanhoSaco = xtamanhoSaco
        _numeroSacos = xnumeroSacos

    End Sub

    Private _producaoID As Double
    Public Property ProducaoID() As Double
        Get
            Return _producaoID
        End Get
        Set(ByVal value As Double)
            _producaoID = value
        End Set
    End Property


    Private _ordemProducao As String
    Public Property OrdemProducao() As String
        Get
            Return _ordemProducao
        End Get
        Set(ByVal value As String)
            _ordemProducao = value
        End Set
    End Property

    Private _item As Integer
    Public Property Item() As Integer
        Get
            Return _item
        End Get
        Set(ByVal value As Integer)
            _item = value
        End Set
    End Property

    Private _itens As Integer
    Public Property Itens() As Integer
        Get
            Return _itens
        End Get
        Set(ByVal value As Integer)
            _itens = value
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

    Private _descricaoProduto As String
    Public Property DescricaoProduto() As String
        Get
            Return _descricaoProduto
        End Get
        Set(ByVal value As String)
            _descricaoProduto = value
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

    Private _descricaoReduzidaMateriaPrima As String
    Public Property DescricaoReduzidaMateriaPrima() As String
        Get
            Return _descricaoReduzidaMateriaPrima
        End Get
        Set(ByVal value As String)
            _descricaoReduzidaMateriaPrima = value
        End Set
    End Property

    Private _qtdeFormula As Double
    Public Property QtdeFormula() As Double
        Get
            Return _qtdeFormula
        End Get
        Set(ByVal value As Double)
            _qtdeFormula = value
        End Set
    End Property

    Private _balancaNumero As Integer
    Public Property BalancaNumero() As Integer
        Get
            Return _balancaNumero
        End Get
        Set(ByVal value As Integer)
            _balancaNumero = value
        End Set
    End Property

    Private _balancaDescricao As String
    Public Property BalancaDescricao() As String
        Get
            Return _balancaDescricao
        End Get
        Set(ByVal value As String)
            _balancaDescricao = value
        End Set
    End Property

    Private _siloID As Integer
    Public Property SiloID() As Integer
        Get
            Return _siloID
        End Get
        Set(ByVal value As Integer)
            _siloID = value
        End Set
    End Property

    Private _siloNumero As Integer
    Public Property SiloNumero() As Integer
        Get
            Return _siloNumero
        End Get
        Set(ByVal value As Integer)
            _siloNumero = value
        End Set
    End Property

    Private _siloDescricao As String
    Public Property SiloDesricao() As String
        Get
            Return _siloDescricao
        End Get
        Set(ByVal value As String)
            _siloDescricao = value
        End Set
    End Property

    Private _associado As Integer
    Public Property Associado() As Integer
        Get
            Return _associado
        End Get
        Set(ByVal value As Integer)
            _associado = value
        End Set
    End Property

    Private _qtdeDesejada As Double
    Public Property QtdeDesejada() As Double
        Get
            Return _qtdeDesejada
        End Get
        Set(ByVal value As Double)
            _qtdeDesejada = value
        End Set
    End Property

    Private _qtdeReal As Double
    Public Property QtdeReal() As Double
        Get
            Return _qtdeReal
        End Get
        Set(ByVal value As Double)
            _qtdeReal = value
        End Set
    End Property

    Private _batchNumero As Integer
    Public Property BatchNumero() As Integer
        Get
            Return _batchNumero
        End Get
        Set(ByVal value As Integer)
            _batchNumero = value
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


    Private _balancaIndice As Integer
    Public Property BalancaIndice() As Integer
        Get
            Return _balancaIndice
        End Get
        Set(ByVal value As Integer)
            _balancaIndice = value
        End Set
    End Property

    Private _loteAtual As String
    Public Property LoteAtual() As String
        Get
            Return _loteAtual
        End Get
        Set(ByVal value As String)
            _loteAtual = value
        End Set
    End Property

    Private _op As String
    Public Property OP() As String
        Get
            Return _op
        End Get
        Set(ByVal value As String)
            _op = value
        End Set
    End Property

    Private _percentualErroDosagem As Double
    Public Property PercentualErroDosagem() As Double
        Get
            Return _percentualErroDosagem
        End Get
        Set(ByVal value As Double)
            _percentualErroDosagem = value
        End Set
    End Property

    Private _tagIndice As Integer
    Public Property TagIndice() As Integer
        Get
            Return _tagIndice
        End Get
        Set(ByVal value As Integer)
            _tagIndice = value
        End Set
    End Property

    Private _tamanhoSaco As Double
    Public Property TamanhoSaco() As Double
        Get
            Return _tamanhoSaco
        End Get
        Set(ByVal value As Double)
            _tamanhoSaco = value
        End Set
    End Property

    Private _numeroSacos As Integer
    Public Property NumeroSacos() As Integer
        Get
            Return _numeroSacos
        End Get
        Set(ByVal value As Integer)
            _numeroSacos = value
        End Set
    End Property

End Class
