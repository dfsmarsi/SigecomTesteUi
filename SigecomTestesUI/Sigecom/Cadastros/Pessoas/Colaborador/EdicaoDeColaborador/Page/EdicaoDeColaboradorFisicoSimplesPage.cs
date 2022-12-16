﻿using NUnit.Framework;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.CadastroDeColaborador.Model;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System.Collections.Generic;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page
{
    public class EdicaoDeColaboradorFisicoSimplesPage: IEdicaoDeColaboradorPage
    {
        private readonly DriverService _driverService;
        private static Dictionary<string, string> _dadosDoColaborador => new Dictionary<string, string>
        {
            {"TipoPessoa", "FÍSICA"},
            {"Nacionalidade", "BRASILEIRO(A)"},
            {"Nome", "COLABORADOR FISICO SIMPLES EDITAR TESTE"},
            {"Cidade", "JALES"},
            {"Estado", "SÃO PAULO"}
        };

        public EdicaoDeColaboradorFisicoSimplesPage(DriverService driverService) => _driverService = driverService;

        public void PesquisarColaboradorQueSeraEditado(EdicaoDeColaboradorBasePage edicaoDeColaboradorBasePage)
        {
            edicaoDeColaboradorBasePage.AbrirTelaDeCadastroDeColaborador();
            edicaoDeColaboradorBasePage.ClicarNoAtalhoDePesquisar();
            edicaoDeColaboradorBasePage.RetornarPesquisaDePessoa(out var pesquisaDePessoaPage);
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("colaborador", _dadosDoColaborador["Nome"]);
        }

        public void VerificarDadosDaPessoa()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoTipoPessoa), _dadosDoColaborador["TipoPessoa"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNacionalidade), _dadosDoColaborador["Nacionalidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNome), _dadosDoColaborador["Nome"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCidade), _dadosDoColaborador["Cidade"]);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEstado), _dadosDoColaborador["Estado"]);
        }

        public void PreencherAsInformacoesDaPessoasNaEdicao()
        {
            _driverService.DigitarNoCampoId(CadastroDeColaboradorModel.ElementoNome, EdicaoDeColaboradorFisicoSimplesModel.NomeDoColaboradorAlterado);
            _driverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoEstado, 1);
            _driverService.SelecionarItemComboBox(CadastroDeColaboradorModel.ElementoCidade, 1);
        }

        public void VerificarDadosDaPessoaEditados()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoNome), EdicaoDeColaboradorFisicoSimplesModel.NomeDoColaboradorAlterado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoEstado), EdicaoDeColaboradorFisicoSimplesModel.Estado);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeColaboradorModel.ElementoCidade), EdicaoDeColaboradorFisicoSimplesModel.Cidade);
        }

        public void FluxoDePesquisaDaPessoaEditado(EdicaoDeColaboradorBasePage edicaoDeColaboradorBasePage,
            PesquisaDePessoaPage pesquisaDePessoaPage)
        {
            edicaoDeColaboradorBasePage.ClicarNoAtalhoDePesquisar();
            pesquisaDePessoaPage.PesquisarPessoaComConfirmar("colaborador", EdicaoDeColaboradorFisicoSimplesModel.NomeDoColaboradorAlterado);
        }
    }
}
