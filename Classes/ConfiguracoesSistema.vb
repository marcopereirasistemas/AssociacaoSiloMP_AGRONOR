Public Class ConfiguracoesSistema

    Private _pesagemMaxCarrossel As Double
    Private _numeroMaximoBatchsSolicitar As Integer
    Private _habilitaDigitacaoPesoReal As Integer
    Private _exibirAlertaVerEquipamentos As Integer
    Private _balancaConferenciaAbastecimento As Integer
    Private _confirmarPesagemCarrossel As Integer
    Private _emitirAutomaticamentoTicketPesagem As Integer
    Private _enviarParaImpressoraAutomaticamente As Integer
    Private _numeroCopiaTicket As Integer
    Private _gerarTicketPDF As Integer
    Private _localGravacaoArquivoPDF As String
    Private _abastecimentoHabilitaDigitacao As Integer
    Private _nomeImpressoraPadrao As String

    Public Sub New(ByVal xpesagemMaxCarrossel As Double,
        ByVal xnumeroMaximoBatchsSolicitar As Integer,
        ByVal xhabilitaDigitacaoPesoReal As Integer,
        ByVal xexibirAlertaVerEquipamentos As Integer,
        ByVal xbalancaConferenciaAbastecimento As Integer,
        ByVal xconfirmarPesagemCarrossel As Integer,
        ByVal xemitirAutomaticamentoTicketPesagem As Integer,
        ByVal xenviarParaImpressoraAutomaticamente As Integer,
        ByVal xnumeroCopiaTicket As Integer,
        ByVal xgerarTicketPDF As Integer,
        ByVal xlocalGravacaoArquivoPDF As String,
        ByVal xabastecimentoHabilitaDigitacao As Integer,
        ByVal xnomeimpressorapadrao As String)

        _pesagemMaxCarrossel = xpesagemMaxCarrossel
        _numeroMaximoBatchsSolicitar = xnumeroMaximoBatchsSolicitar
        _habilitaDigitacaoPesoReal = xhabilitaDigitacaoPesoReal
        _exibirAlertaVerEquipamentos = xexibirAlertaVerEquipamentos
        _balancaConferenciaAbastecimento = xbalancaConferenciaAbastecimento
        _confirmarPesagemCarrossel = xconfirmarPesagemCarrossel
        _emitirAutomaticamentoTicketPesagem = xemitirAutomaticamentoTicketPesagem
        _enviarParaImpressoraAutomaticamente = xenviarParaImpressoraAutomaticamente
        _numeroCopiaTicket = xnumeroCopiaTicket
        _gerarTicketPDF = xgerarTicketPDF
        _localGravacaoArquivoPDF = xlocalGravacaoArquivoPDF
        _abastecimentoHabilitaDigitacao = xabastecimentoHabilitaDigitacao
        _nomeImpressoraPadrao = xnomeimpressorapadrao
    End Sub

    Public Sub New()
    End Sub

    Public Property PesagemMaxCarrossel() As Double
        Get
            Return _pesagemMaxCarrossel
        End Get
        Set(ByVal value As Double)
            _pesagemMaxCarrossel = value
        End Set
    End Property

    Public Property NumeroMaximoBatchsSolicitar() As Integer
        Get
            Return _numeroMaximoBatchsSolicitar
        End Get
        Set(ByVal value As Integer)
            _numeroMaximoBatchsSolicitar = value
        End Set
    End Property

    Public Property HabilitaDigitacaoPesoReal() As Integer
        Get
            Return _habilitaDigitacaoPesoReal
        End Get
        Set(ByVal value As Integer)
            _habilitaDigitacaoPesoReal = value
        End Set
    End Property

    Public Property ExibirAlertaVerEquipamentos() As Integer
        Get
            Return _exibirAlertaVerEquipamentos
        End Get
        Set(ByVal value As Integer)
            _exibirAlertaVerEquipamentos = value
        End Set
    End Property

    Public Property BalancaConferenciaAbastecimento() As Integer
        Get
            Return _balancaConferenciaAbastecimento
        End Get
        Set(ByVal value As Integer)
            _balancaConferenciaAbastecimento = value
        End Set
    End Property

    Public Property ConfirmarPesagemCarrossel() As Integer
        Get
            Return _confirmarPesagemCarrossel
        End Get
        Set(ByVal value As Integer)
            _confirmarPesagemCarrossel = value
        End Set
    End Property

    Public Property EmitirAutomaticamentoTicketPesagem() As Integer
        Get
            Return _emitirAutomaticamentoTicketPesagem
        End Get
        Set(ByVal value As Integer)
            _emitirAutomaticamentoTicketPesagem = value
        End Set
    End Property

    Public Property EnviarParaImpressoraAutomaticamente() As Integer
        Get
            Return _enviarParaImpressoraAutomaticamente
        End Get
        Set(ByVal value As Integer)
            _enviarParaImpressoraAutomaticamente = value
        End Set
    End Property

    Public Property NumeroCopiaTicket() As Integer
        Get
            Return _numeroCopiaTicket
        End Get
        Set(ByVal value As Integer)
            _numeroCopiaTicket = value
        End Set
    End Property

    Public Property GerarTicketPDF() As Integer
        Get
            Return _gerarTicketPDF
        End Get
        Set(ByVal value As Integer)
            _gerarTicketPDF = value
        End Set
    End Property

    Public Property LocalGravacaoArquivoPDF() As String
        Get
            Return _localGravacaoArquivoPDF
        End Get
        Set(ByVal value As String)
            _localGravacaoArquivoPDF = value
        End Set
    End Property

    Private _abrirFormularioModoMaximizado As Integer
    Public ReadOnly Property AbrirFormularioModoMaximizado() As Integer
        Get
            Return _abrirFormularioModoMaximizado
        End Get
        'Set(ByVal value As Boolean)
        '    _AbrirFormularioModoMaximizado = value
        'End Set
    End Property

    Private _logAtivado As Integer
    Public ReadOnly Property LogAtivado() As Integer
        Get
            Return _logAtivado
        End Get
        'Set(ByVal value As INTEGER)
        '    _logAtivado = value
        'End Set
    End Property

    Private _localGerarLog As String
    Public ReadOnly Property LocalGerarLog() As String
        Get
            Return _localGerarLog
        End Get
        'Set(ByVal value As String)
        '    _localGerarLog = value
        'End Set
    End Property


    Public Property AbastecimentoHabilitaDigitacao() As Integer
        Get
            Return _abastecimentoHabilitaDigitacao
        End Get
        Set(ByVal value As Integer)
            _abastecimentoHabilitaDigitacao = value
        End Set
    End Property

    Public Property NomeImpressoraPadrao() As String
        Get
            Return _nomeImpressoraPadrao
        End Get
        Set(ByVal value As String)
            _nomeImpressoraPadrao = value
        End Set
    End Property


End Class
